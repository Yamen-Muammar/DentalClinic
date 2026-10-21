using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;
using DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    public partial class frmMedicalFile : Form
    {
        private readonly IPatientService _patientService;
        private readonly IMedicalFileService _medicalFileService;
        private readonly IProblemService _problemService;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        
        private int _patientId;
        private clsMedicalFile _currentMedicalFile;
        private clsProblem _selectedProblem;
        private List<clsProblem> _problems;

        public frmMedicalFile()
        {
            InitializeComponent();
            
            _patientService = Program.ServiceProvider.GetRequiredService<IPatientService>();
            _medicalFileService = Program.ServiceProvider.GetRequiredService<IMedicalFileService>();
            _problemService = Program.ServiceProvider.GetRequiredService<IProblemService>();
            _appointmentService = Program.ServiceProvider.GetRequiredService<IAppointmentService>();
            _doctorService = Program.ServiceProvider.GetRequiredService<IDoctorService>();

            this.btnAddProblem.Click += BtnAddProblem_Click;
            this.btnAddAppointment.Click += BtnAddAppointment_Click;
        }

        public async Task LoadDataAsync(int patientId)
        {
            _patientId = patientId;
            await LoadPatientDataAsync();
            await LoadMedicalFileAsync();
            await LoadProblemsAsync();
            _fillProblemData(_problems);
        }

        private async Task LoadPatientDataAsync()
        {
            try
            {
                var patientView = await _patientService.GetPatientDetailsViewByIDAsync(_patientId);
                if (patientView != null)
                {
                    patientCard.LoadPatientData(patientView);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطأ أثناء تحميل بيانات المريض: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private async Task LoadMedicalFileAsync()
        {
            try
            {
                _currentMedicalFile = await _medicalFileService.GetMedicalFilesByPatientIDAsync(_patientId);
            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطأ أثناء تحميل بيانات ملف المريض: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
        private async Task LoadProblemsAsync()
        {
            if (_currentMedicalFile == null) return;
            try
            {
                _problems = (await _problemService.GetProblemsByMedicalFileIdAsync(_currentMedicalFile.MedicalFileID)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل المشاكل: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _fillProblemData(List<clsProblem> problems)
        {
            flpProblems.Controls.Clear();

            foreach (var problem in problems.OrderByDescending(p => p.CreationDate))
            {
                var card = new ctrlProblemCard();
                card.Width = flpProblems.Width - 65; // Leave room for scrollbar
                card.LoadProblemData(problem);
                card.OnProblemClicked += Card_OnProblemClicked;
                flpProblems.Controls.Add(card);
            }
        }
        private async void Card_OnProblemClicked(object sender, clsProblem problem)
        {
            _selectedProblem = problem;
            btnAddAppointment.Enabled = true;
            await LoadAppointmentsForProblemAsync(problem.ProblemID);
        }

        private async Task LoadAppointmentsForProblemAsync(int problemId)
        {
            flpAppointments.Controls.Clear();
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByProblemIdAsync(problemId);

                if (appointments == null || !appointments.Any())
                {
                    Label lblNoApps = new Label
                    {
                        Text = "لا توجد مواعيد مرتبطة بهذه المشكلة.",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Margin = new Padding(10)
                    };
                    flpAppointments.Controls.Add(lblNoApps);
                    return;
                }
                await _BuildAppointmentItem(appointments.ToList());

            }
            catch (Exception)
            {

                MessageBox.Show("حدث خطأ أثناء تحميل المواعيد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task _BuildAppointmentItem(List<clsAppointment> appointments)
        {
            foreach (var app in appointments.OrderBy(a => a.AppointmentDate).ThenBy(a => a.StartTime))
            {
                var doc = await _doctorService.GetByIdAsync(app.Doctor_ID);
                // Creating a simple appointment item view directly here since it's small
                Guna2Panel pnlApp = new Guna2Panel
                {
                    Size = new Size(flpAppointments.Width - 25, 150),
                    BackColor = Color.White,
                    BorderRadius = 5,
                    FillColor = Color.White,
                    BorderColor = Color.LightGray,
                    BorderThickness = 1,
                    Margin = new Padding(5)
                };

                Label lblDate = new Label
                {
                    Text = app.AppointmentDate.ToString("yyyy-MM-dd") + " | " + app.StartTime.ToString(@"hh\:mm"),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true,
                    Dock = DockStyle.Top
                };

                Label lblStatus = new Label
                {
                    Text = app.Status.ToString(),
                    ForeColor = Color.SteelBlue,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Location = new Point(10, 35),
                    AutoSize = true,
                    Dock = DockStyle.Top
                };

                Label lblDoc = new Label
                {
                    Text = "الطبيب ID: " + app.Doctor_ID.ToString(),
                    ForeColor = Color.DimGray,
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(10, 55),
                    AutoSize = true,
                    Dock = DockStyle.Top
                };

                pnlApp.Controls.Add(lblDate);
                pnlApp.Controls.Add(lblStatus);
                pnlApp.Controls.Add(lblDoc);

                flpAppointments.Controls.Add(pnlApp);
            }
        }
        private async void BtnAddProblem_Click(object sender, EventArgs e)
        {
            if (_currentMedicalFile == null) return;

            var addProblemForm = Program.ServiceProvider.GetRequiredService<frmAddProblem>();
            addProblemForm.LoadData(_currentMedicalFile.MedicalFileID);
            addProblemForm.OnProblemAdded += async (s, ev) => 
            {
                await LoadMedicalFileAsync();
                await LoadProblemsAsync();
                _fillProblemData(_problems);
            }; 
            addProblemForm.ShowDialog(this);
        }
        private void BtnAddAppointment_Click(object sender, EventArgs e)
        {
            if (_selectedProblem == null)
            {
                MessageBox.Show("الرجاء اختيار مشكلة أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addAppointmentForm = Program.ServiceProvider.GetRequiredService<frmAddAppointment>();
            addAppointmentForm.LoadData(_selectedProblem.ProblemID);
            addAppointmentForm.OnAppointmentAdded += async (s, ev) =>
            {
                await LoadAppointmentsForProblemAsync(_selectedProblem.ProblemID);
            };
            addAppointmentForm.ShowDialog(this);
        }
    }
}
