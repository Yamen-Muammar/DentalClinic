using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    public partial class frmAddAppointment : Form
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private int _problemId;
        
        public event EventHandler OnAppointmentAdded;

        public frmAddAppointment(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            InitializeComponent();
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            this.Load += FrmAddAppointment_Load;
            this.cbStartTime.SelectedIndexChanged += TimeSelection_Changed;
            this.cbAmPm.SelectedIndexChanged += TimeSelection_Changed;
        }

        public void LoadData(int problemId)
        {
            _problemId = problemId;
        }

        private async void FrmAddAppointment_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Owner == null && Form.ActiveForm != null && Form.ActiveForm != this)
                {
                    this.Owner = Form.ActiveForm;
                }

                _populateTimeSlots();

                dtpDate.MinDate = DateTime.Today;
                if (dtpDate.Value.Date < DateTime.Today)
                    dtpDate.Value = DateTime.Today;

                var doctors = await _doctorService.GetAllDoctorsListInformationAsync();
                var doctorsList = doctors?.ToList() ?? new System.Collections.Generic.List<DentalClinic_CoreTier.ViewModels.clsDoctorListInformation>();

                cbDoctors.DisplayMember = "FullName";
                cbDoctors.ValueMember = "DoctorID";
                cbDoctors.DataSource = doctorsList;
                cbDoctors.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل بيانات الأطباء: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _populateTimeSlots()
        {
            cbStartTime.Items.Clear();
            cbStartTime.Items.AddRange(new object[]
            {
                "01:00", "01:30", "02:00", "02:30", "03:00", "03:30",
                "04:00", "04:30", "05:00", "05:30", "06:00", "06:30",
                "07:00", "07:30", "08:00", "08:30", "09:00", "09:30",
                "10:00", "10:30", "11:00", "11:30", "12:00", "12:30"
            });

            cbAmPm.Items.Clear();
            cbAmPm.Items.AddRange(new object[]
            {
                "صباحاً (AM)",
                "مساءً (PM)"
            });

            cbStartTime.SelectedIndex = -1;
            cbAmPm.SelectedIndex = -1;
            txtEndTime.Text = "تلقائي (+1 ساعة)";
        }

        private void TimeSelection_Changed(object sender, EventArgs e)
        {
            UpdateCalculatedEndTime();
        }

        private void UpdateCalculatedEndTime()
        {
            if (TryGetSelectedTimes(out TimeSpan _, out TimeSpan endTime))
            {
                txtEndTime.Text = FormatTime12Hour(endTime);
            }
            else
            {
                txtEndTime.Text = "تلقائي (+1 ساعة)";
            }
        }

        private bool TryGetSelectedTimes(out TimeSpan startTime, out TimeSpan endTime)
        {
            startTime = TimeSpan.Zero;
            endTime = TimeSpan.Zero;

            if (cbStartTime.SelectedIndex == -1 || cbAmPm.SelectedIndex == -1)
                return false;

            string timeStr = cbStartTime.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(timeStr))
                return false;

            string[] parts = timeStr.Split(':');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int hour) || !int.TryParse(parts[1], out int minute))
                return false;

            bool isPm = cbAmPm.SelectedIndex == 1 || (cbAmPm.SelectedItem?.ToString().Contains("PM") ?? false);

            if (isPm)
            {
                if (hour < 12)
                    hour += 12;
            }
            else
            {
                if (hour == 12)
                    hour = 0;
            }

            startTime = new TimeSpan(hour, minute, 0);
            endTime = startTime.Add(TimeSpan.FromHours(1));
            return true;
        }

        private string FormatTime12Hour(TimeSpan time)
        {
            int hours = time.Hours;
            int minutes = time.Minutes;
            string period = hours >= 12 ? "مساءً (PM)" : "صباحاً (AM)";
            int displayHour = hours % 12;
            if (displayHour == 0) displayHour = 12;
            return $"{displayHour:00}:{minutes:00} {period}";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Doctor Selection Validation
            if (cbDoctors.SelectedValue == null || !int.TryParse(cbDoctors.SelectedValue.ToString(), out int doctorId) || doctorId <= 0)
            {
                MessageBox.Show("الرجاء اختيار الطبيب أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbDoctors.Focus();
                return;
            }

            // 2. Date Validation (not in the past)
            if (dtpDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("لا يمكن حجز موعد في تاريخ ماضٍ، الرجاء اختيار تاريخ اليوم أو تاريخ قادم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Focus();
                return;
            }

            // 3. Start Time Selection Validation
            if (cbStartTime.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء اختيار وقت بداية الموعد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbStartTime.Focus();
                return;
            }

            // 4. AM/PM Selection Validation
            if (cbAmPm.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء تحديد الفترة (صباحاً أو مساءً)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbAmPm.Focus();
                return;
            }

            if (!TryGetSelectedTimes(out TimeSpan startTime, out TimeSpan endTime))
            {
                MessageBox.Show("صيغة الوقت المحددة غير صالحة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Past Time Validation for Same-Day Appointments
            DateTime appointmentDate = dtpDate.Value.Date + startTime;
            if (appointmentDate <= DateTime.Now)
            {
                MessageBox.Show("الوقت المحدد قد مضى، الرجاء اختيار وقت قادم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 6. Cause/Reason Validation
            if (string.IsNullOrWhiteSpace(txtCause.Text))
            {
                MessageBox.Show("الرجاء كتابة سبب الزيارة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCause.Focus();
                return;
            }

            // 7. Doctor Schedule Conflict Validation (Overlapping Appointments)
            try
            {
                var existingAppointments = await _appointmentService.GetAppointmentsByDoctorAndDateAsync(doctorId, dtpDate.Value.Date);
                if (existingAppointments != null)
                {
                    var conflict = existingAppointments.FirstOrDefault(a =>
                        a.Status != myEnums.enAppointmentStatus.Cancelled &&
                        startTime < a.EndTime &&
                        endTime > a.StartTime);

                    if (conflict != null)
                    {
                        MessageBox.Show(
                            $"الطبيب لديه موعد آخر محجوز في هذا الوقت ({conflict.StartTime:hh\\:mm} - {conflict.EndTime:hh\\:mm}). الرجاء اختيار وقت آخر.",
                            "تعارض في المواعيد",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                // If conflict check query fails, continue to save or inform
            }

            var appointment = new clsAppointment
            {
                Problem_ID = _problemId,
                Doctor_ID = doctorId,
                AppointmentDate = appointmentDate,
                StartTime = startTime,
                EndTime = endTime,
                Status = myEnums.enAppointmentStatus.Scheduled,
                Cause = txtCause.Text.Trim(),
                CreatedAt = DateTime.Now
            };

            try
            {
                var id = await _appointmentService.InsertAsync(appointment);
                if (id.HasValue && id.Value > 0)
                {
                    MessageBox.Show("تمت إضافة الموعد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnAppointmentAdded?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشلت عملية إضافة الموعد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء حفظ الموعد: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
