using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;
using Guna.UI2.WinForms;

namespace DentistClinic_PresentationTier.Controls.MainUIControls
{
    public partial class ctrlDashBoard : UserControl
    {
        private int mainPanleHeight = 0;
        private enum enDropMode
        {
            down, up
        }

        private List<clsAppointmentsDetails> _todayAppointment;
        private int? _notConfirmedPayments;
        private int _patientsCount;

        private IAppointmentService _appointmentService;
        private IPaymentService _paymentService;
        private IPatientService _patientService; 
        public ctrlDashBoard(IPatientService patientService,IAppointmentService appointmentService, IPaymentService paymentService)
        {
            _appointmentService = appointmentService;
            _paymentService = paymentService;
            _patientService = patientService;
            InitializeComponent();
        }
        private async void ctrlDashBoard_Load(object sender, EventArgs e)
        {
            await _buildUI();
        }
        private void pnlTodayPatient_DoubleClick(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;
            MessageBox.Show(guna2Panel.Name);
        }
        private void pnlNotConfirmedPayments_DoubleClick(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;
            MessageBox.Show(guna2Panel.Name);
        }
        private void pnlTodayAppointments_DoubleClick(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;
            MessageBox.Show(guna2Panel.Name);
        }
        private void Panle_MouseEnter(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;

            guna2Panel.FillColor = Color.Gainsboro;

        }
        private void Panle_MouseLeave(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;
            guna2Panel.FillColor = Color.White;
        }
        private void btnDropCause_Click(object sender, EventArgs e)
        {
            Guna2CircleButton senderButton = sender as Guna2CircleButton;

            enDropMode senderDropMode = (enDropMode)senderButton.Tag;

            Guna2ShadowPanel senderAppointmentPanel = senderButton?.Parent as Guna2ShadowPanel;

            Control senderLableCause = senderAppointmentPanel.Controls["senderLableCause"];

            clsAppointmentsDetails appointmentDataFromSender = senderAppointmentPanel.Tag as clsAppointmentsDetails;

            if (senderDropMode == enDropMode.up)
            {
                senderLableCause.Text = "";
                senderAppointmentPanel.Height = mainPanleHeight;
                senderLableCause.Text = string.Empty;
                senderButton.Image = Properties.Resources.ArowDown;
                senderButton.Tag = enDropMode.down;
            }
            else
            {
                senderLableCause.Text = appointmentDataFromSender.Appointment.Cause;
                mainPanleHeight = senderAppointmentPanel.Height;
                senderAppointmentPanel.Height += senderLableCause.Height;
                senderButton.Image = Properties.Resources.ArowUp;
                senderButton.Tag = enDropMode.up;
            }
        }

        //Appointment Shadow Panel Events and Req

        private Color _appointmentShadowPanelDefaultColor;
        private void AppointmentShadowPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Guna2ShadowPanel senderShadowPanel = sender as Guna2ShadowPanel;

            clsAppointmentsDetails appointmentsDetails = senderShadowPanel.Tag as clsAppointmentsDetails;

            MessageBox.Show(appointmentsDetails.Appointment.AppointmentID.ToString());

        }

        private void AppointmentShadowPanel_MouseEnter(object sender, EventArgs e)
        {
            Guna2ShadowPanel senderShadowPanel = sender as Guna2ShadowPanel;
            _appointmentShadowPanelDefaultColor = senderShadowPanel.FillColor;
            senderShadowPanel.FillColor = Color.Gainsboro;
        }
        private void AppointmentShadowPanel_MouseLeave(object sender, EventArgs e)
        {
            Guna2ShadowPanel senderShadowPanel = sender as Guna2ShadowPanel;
            senderShadowPanel.FillColor = _appointmentShadowPanelDefaultColor;
        }
        //Helper Methods

        private async Task _buildUI()
        {
            await Task.Delay(200);

            await _loadTodaysAppointments();
            await _getNotConfirmedPayments();
            await _getPatientsCount();
              
            lblTodayAppoinmentsCount.Text = _todayAppointment?.Count.ToString() ?? "??";
            lblunConfirmedPayments.Text = _notConfirmedPayments?.ToString() ?? "??";
            lblPatientsCount.Text = _patientsCount==-1? "??":_patientsCount.ToString();

            _handleProgressIndicator(false);
        }
        private async Task _getNotConfirmedPayments()
        {
            try
            {
                _notConfirmedPayments = await _getNotApprovaedPaymentsCount();
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ في جلب بيانات عدد الحوالات المالية غير الؤكـدة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task _getPatientsCount()
        {
            try
            {
                _patientsCount = await _patientService.GetPatientCountAsync();
            }
            catch (Exception ex)
            {

                MessageBox.Show("خطأ في جلب بيانات عدد المرضـى", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task _getTodaysAppointments()
        {
            try
            {
                _todayAppointment = (List<clsAppointmentsDetails>)(await _appointmentService.GetAppointmentsByDateAsync(DateTime.Now, DateTime.Now));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task _loadTodaysAppointments()
        {
            _loadMockAppointments();
            //await _getTodaysAppointments();
            try
            {
                if (_todayAppointment.Count == 0)
                {
                    return;
                }

                foreach (var appointment in _todayAppointment)
                {
                    Guna2ShadowPanel shadowPanel = new Guna2ShadowPanel();
                    shadowPanel.Name = appointment.Appointment.AppointmentID.ToString();
                    _buildAppointmentPanle(appointment, shadowPanel);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("مشكلة في بناء مواعيـد اليوم\n الرجاء الاتصال بـ آدمن", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        private async Task<int?> _getNotApprovaedPaymentsCount()
        {
            try
            {
                return await _paymentService.GetNotApprovedPaymentsCount();
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ في جلب بيانات عدد الحوالات المالية غير الؤكـدة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        //Create View For Req Information
        private void _handleProgressIndicator(bool enable)
        {
            if (enable)
            {
                this.guna2WinProgressIndicator.Start();
            }
            else
            {                
                this.guna2WinProgressIndicator.Stop();
                //this.guna2WinProgressIndicator.Dispose();
                //this.Controls.Remove(this.indecatorPanel);
                indecatorPanel.Visible = false;
            }
        }
        private void _buildAppointmentPanle(clsAppointmentsDetails appointment, Guna2ShadowPanel shadowPanel)
        {
            btnDropCause = new Guna.UI2.WinForms.Guna2CircleButton();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblPatientName = new System.Windows.Forms.Label();
            lblPatientPhoneNo = new System.Windows.Forms.Label();
            lblDoctorName = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            lblCause = new System.Windows.Forms.Label();
            shadowPanel.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Akhbar MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.ForeColor = System.Drawing.Color.SlateGray;
            this.label10.Location = new System.Drawing.Point(192, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 49);
            this.label10.TabIndex = 0;
            this.label10.Text = "وصف الموعـد";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Akhbar MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.SlateGray;
            this.label8.Location = new System.Drawing.Point(322, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 49);
            this.label8.TabIndex = 0;
            this.label8.Text = ":حالة المـوعد";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Akhbar MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.SlateGray;
            this.label7.Location = new System.Drawing.Point(81, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 49);
            this.label7.TabIndex = 0;
            this.label7.Text = ":توقـيت الموعد";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Akhbar MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.SlateGray;
            this.label5.Location = new System.Drawing.Point(302, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 49);
            this.label5.TabIndex = 0;
            this.label5.Text = ":الدكتور المكلف";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Akhbar MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.SlateGray;
            this.label9.Location = new System.Drawing.Point(274, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 49);
            this.label9.TabIndex = 0;
            this.label9.Text = ":رقم هاتف المريـض";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Akhbar MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(324, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = ":اسم المريـض";
            // 
            // btnDropCause
            // 
            this.btnDropCause.Animated = true;
            this.btnDropCause.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDropCause.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDropCause.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDropCause.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDropCause.FillColor = System.Drawing.Color.Transparent;
            this.btnDropCause.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDropCause.ForeColor = System.Drawing.Color.White;
            this.btnDropCause.Image = global::DentistClinic_PresentationTier.Properties.Resources.ArowDown;
            this.btnDropCause.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDropCause.Location = new System.Drawing.Point(147, 233);
            this.btnDropCause.Name = "btnDropCause";
            this.btnDropCause.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnDropCause.Size = new System.Drawing.Size(39, 35);
            this.btnDropCause.TabIndex = 2;
            this.btnDropCause.UseTransparentBackground = true;
            this.btnDropCause.Click += new System.EventHandler(this.btnDropCause_Click);
            this.btnDropCause.Tag = enDropMode.down;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Akhbar MT", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientName.ForeColor = System.Drawing.Color.Black;
            this.lblPatientName.Location = new System.Drawing.Point(213, 14);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(109, 53);
            this.lblPatientName.TabIndex = 0;
            this.lblPatientName.Text = appointment.PatientFullName;
            // 
            // lblPatientPhoneNo
            // 
            this.lblPatientPhoneNo.AutoSize = true;
            this.lblPatientPhoneNo.Font = new System.Drawing.Font("Akhbar MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientPhoneNo.ForeColor = System.Drawing.Color.Black;
            this.lblPatientPhoneNo.Location = new System.Drawing.Point(122, 90);
            this.lblPatientPhoneNo.Name = "lblPatientPhoneNo";
            this.lblPatientPhoneNo.Size = new System.Drawing.Size(145, 33);
            this.lblPatientPhoneNo.TabIndex = 0;
            this.lblPatientPhoneNo.Text = appointment.PatientPhone ?? "N/A";
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new System.Drawing.Font("Akhbar MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDoctorName.ForeColor = System.Drawing.Color.Black;
            this.lblDoctorName.Location = new System.Drawing.Point(179, 134);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDoctorName.Size = new System.Drawing.Size(117, 39);
            this.lblDoctorName.TabIndex = 0;
            this.lblDoctorName.Text = appointment.DoctorFullName;
            this.lblDoctorName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("72 Monospace", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(14, 186);
            this.label11.Name = "lblAppoitmentTime";
            this.label11.Size = new System.Drawing.Size(70, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = appointment.Appointment.StartTime.ToString();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Akhbar MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(243, 179);
            this.label12.Name = "lblAppointmentStatus";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(73, 39);
            this.label12.TabIndex = 0;
            this.label12.Text = clsUtilities.GetAppointmentStatusText(appointment.Appointment.Status);
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // senderLableCause
            // 
            this.lblCause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCause.AutoSize = true;
            this.lblCause.Font = new System.Drawing.Font("Akhbar MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCause.ForeColor = System.Drawing.Color.Black;
            this.lblCause.Location = new System.Drawing.Point(20, 300);
            this.lblCause.MaximumSize = new System.Drawing.Size(440, 0);
            this.lblCause.Name = "senderLableCause";
            this.lblCause.Size = new System.Drawing.Size(411, 245);
            this.lblCause.TabIndex = 0;
            this.lblCause.Text = "";
            this.lblCause.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AppointmetPanle
            // 
            shadowPanel.BackColor = System.Drawing.Color.Transparent;
            shadowPanel.Controls.Add(this.btnDropCause);
            shadowPanel.Controls.Add(this.label10);
            shadowPanel.Controls.Add(this.label8);
            shadowPanel.Controls.Add(this.label7);
            shadowPanel.Controls.Add(this.label5);
            shadowPanel.Controls.Add(this.label9);
            shadowPanel.Controls.Add(this.label11);
            shadowPanel.Controls.Add(this.lblPatientPhoneNo);
            shadowPanel.Controls.Add(this.label12);
            shadowPanel.Controls.Add(this.lblDoctorName);
            shadowPanel.Controls.Add(this.lblCause);
            shadowPanel.Controls.Add(this.lblPatientName);
            shadowPanel.Controls.Add(this.label1);
            shadowPanel.FillColor = System.Drawing.Color.GhostWhite;
            shadowPanel.Location = new System.Drawing.Point(3, 3);
            shadowPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            shadowPanel.Name = appointment.Appointment.AppointmentID.ToString();
            shadowPanel.Radius = 10;
            shadowPanel.ShadowColor = System.Drawing.Color.Black;
            shadowPanel.Size = new System.Drawing.Size(450, 325);
            shadowPanel.TabIndex = 0;
            shadowPanel.Tag = appointment;
            shadowPanel.MouseDoubleClick += AppointmentShadowPanel_MouseDoubleClick;
            shadowPanel.MouseEnter += AppointmentShadowPanel_MouseEnter;
            shadowPanel.MouseLeave += AppointmentShadowPanel_MouseLeave;

            this.flpTodayAppointmentList.Controls.Add(shadowPanel);
            shadowPanel.ResumeLayout(false);
            shadowPanel.PerformLayout();
        }
        private void _loadMockAppointments()
        {
            IEnumerable<clsAppointmentsDetails> todayAppointment = new List<clsAppointmentsDetails>();
            clsGenrateMockData._loadMockAppointments(ref todayAppointment);
            _todayAppointment = (List<clsAppointmentsDetails>)todayAppointment;
        }
        
    }
}
