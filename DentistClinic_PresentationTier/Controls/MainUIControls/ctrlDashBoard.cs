using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;
using DentistClinic_PresentationTier.Forms.PatientsForms;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;

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
            // Enable double buffering on the flow layout panel
            typeof(FlowLayoutPanel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                flpTodayAppointmentList,
                new object[] { true }
            );

            // Also enable it for this UserControl
            this.DoubleBuffered = true;
            WireEventsForQuickActionsPanel();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private async void ctrlDashBoard_Load(object sender, EventArgs e)
        {
            await _buildUI();
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
            Guna2Button senderButton = sender as Guna2Button;

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
            Guna2ShadowPanel senderShadowPanel = new Guna2ShadowPanel();

            if (sender is Guna2ShadowPanel shadowPanel)
            {
                senderShadowPanel = shadowPanel;
            }
            if (sender is System.Windows.Forms.Label label)
            {
                if (label.Parent is TableLayoutPanel lblParent)
                {
                    senderShadowPanel = lblParent?.Parent as Guna2ShadowPanel;
                }
                else if (label.Parent is Guna2ShadowPanel guna2Shadow)
                {
                    senderShadowPanel = guna2Shadow;
                }
            }
            if (sender is TableLayoutPanel tableLayoutPanel )
            {               
                senderShadowPanel = tableLayoutPanel?.Parent as Guna2ShadowPanel;
            }

            clsAppointmentsDetails appointmentsDetails = senderShadowPanel.Tag as clsAppointmentsDetails;

            MessageBox.Show(appointmentsDetails.Appointment.AppointmentID.ToString());

        }

        private void AppointmentShadowPanel_MouseEnter(object sender, EventArgs e)
        {
            Guna2ShadowPanel senderShadowPanel = new Guna2ShadowPanel();

            if(sender is Guna2ShadowPanel shadowPanel)
            {
                senderShadowPanel = shadowPanel;
            }

            if (sender is System.Windows.Forms.Label label)
            {
                if (label.Parent is TableLayoutPanel lblParent)
                {
                    senderShadowPanel = lblParent?.Parent as Guna2ShadowPanel;
                }
                else if (label.Parent is Guna2ShadowPanel guna2Shadow)
                {
                    senderShadowPanel = guna2Shadow;
                }
            }
            if (sender is TableLayoutPanel tableLayoutPanel)
            {
                senderShadowPanel = tableLayoutPanel?.Parent as Guna2ShadowPanel;
            }
            _appointmentShadowPanelDefaultColor = senderShadowPanel.FillColor;
            senderShadowPanel.FillColor = Color.Gainsboro;
        }
        private void AppointmentShadowPanel_MouseLeave(object sender, EventArgs e)
        {

            Guna2ShadowPanel senderShadowPanel = new Guna2ShadowPanel();
            if (sender is Guna2ShadowPanel shadowPanel)
            {
                senderShadowPanel = shadowPanel;
            }
            if (sender is System.Windows.Forms.Label label)
            {
                if (label.Parent is TableLayoutPanel lblParent)
                {
                    senderShadowPanel = lblParent?.Parent as Guna2ShadowPanel;
                }
                else if (label.Parent is Guna2ShadowPanel guna2Shadow)
                {
                    senderShadowPanel = guna2Shadow;
                }
            }
            if (sender is TableLayoutPanel tableLayoutPanel)
            {
                senderShadowPanel = tableLayoutPanel?.Parent as Guna2ShadowPanel;
            }
            senderShadowPanel.FillColor = _appointmentShadowPanelDefaultColor;
        }
        //Helper Methods

        private async Task _buildUI()
        {
            await _loadTodaysAppointments();
            await _getNotConfirmedPayments();
            await _getPatientsCount();
              
            lblTodayAppoinmentsCount.Text = _todayAppointment?.Count.ToString() ?? "??";
            lblunConfirmedPayments.Text = _notConfirmedPayments?.ToString() ?? "??";
            lblPatientsCount.Text = _patientsCount==-1? "??":_patientsCount.ToString();

            await Task.Delay(200);

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
            
            //await _getTodaysAppointments();
            _loadMockAppointments();
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
                    AttachHoverRecursive(shadowPanel, AppointmentShadowPanel_MouseEnter, AppointmentShadowPanel_MouseLeave);
                    AttachDoubleClickRecursive(shadowPanel, AppointmentShadowPanel_MouseDoubleClick);
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
            this.tlpAppointment = new System.Windows.Forms.TableLayoutPanel();
            this.lblPatientName1 = new System.Windows.Forms.Label();
            this.lblAppointmentTime = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblAppointmentStatus = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblDoctorName1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblPatientPhoneNo1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAppointmentDetails = new Guna.UI2.WinForms.Guna2Button();
            this.lblCause = new System.Windows.Forms.Label();
            this.tlpAppointment.SuspendLayout();
            shadowPanel.SuspendLayout();
            // 
            // tlpAppointment
            // 
            this.tlpAppointment.ColumnCount = 2;
            this.tlpAppointment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.55142F));
            this.tlpAppointment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.44858F));
            this.tlpAppointment.Controls.Add(this.lblPatientName1, 0, 0);
            this.tlpAppointment.Controls.Add(this.lblAppointmentTime, 1, 4);
            this.tlpAppointment.Controls.Add(this.lblTime, 0, 4);
            this.tlpAppointment.Controls.Add(this.label24, 1, 3);
            this.tlpAppointment.Controls.Add(this.lblAppointmentStatus, 0, 3);
            this.tlpAppointment.Controls.Add(this.label22, 1, 2);
            this.tlpAppointment.Controls.Add(this.lblDoctorName1, 0, 2);
            this.tlpAppointment.Controls.Add(this.label20, 1, 1);
            this.tlpAppointment.Controls.Add(this.lblPatientPhoneNo1, 0, 1);
            this.tlpAppointment.Controls.Add(this.label17, 1, 0);
            this.tlpAppointment.Location = new System.Drawing.Point(0, 0);
            this.tlpAppointment.Name = "tlpAppointment";
            this.tlpAppointment.RowCount = 6;
            this.tlpAppointment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.08642F));
            this.tlpAppointment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.91358F));
            this.tlpAppointment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tlpAppointment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpAppointment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));            
            this.tlpAppointment.Size = new System.Drawing.Size(914, 430);
            this.tlpAppointment.TabIndex = 0;
            this.tlpAppointment.Dock = DockStyle.Top;  
            // 
            // lblPatientName1
            // 
            this.lblPatientName1.AutoSize = true;
            this.lblPatientName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatientName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName1.Location = new System.Drawing.Point(3, 0);
            this.lblPatientName1.Name = "lblPatientName1";
            this.lblPatientName1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPatientName1.Size = new System.Drawing.Size(584, 54);
            this.lblPatientName1.TabIndex = 10;
            this.lblPatientName1.Text = appointment.PatientFullName??"???";
            this.lblPatientName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppointmentTime
            // 
            this.lblAppointmentTime.AutoSize = true;
            this.lblAppointmentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppointmentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentTime.Location = new System.Drawing.Point(593, 262);
            this.lblAppointmentTime.Name = "lblAppointmentTime";
            this.lblAppointmentTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAppointmentTime.Size = new System.Drawing.Size(318, 80);
            this.lblAppointmentTime.TabIndex = 9;           
            this.lblAppointmentTime.Text = appointment.Appointment.AppointmentDate.ToString("D")??"???";
            this.lblAppointmentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(3, 262);
            this.lblTime.Name = "lblTime";
            this.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTime.Size = new System.Drawing.Size(584, 80);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = appointment.Appointment.StartTime.ToString()??"???";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(593, 182);
            this.label24.Name = "label24";
            this.label24.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label24.Size = new System.Drawing.Size(318, 80);
            this.label24.TabIndex = 7;
            this.label24.Text = "حالة الموعد :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblAppointmentStatus
            // 
            this.lblAppointmentStatus.AutoSize = true;
            this.lblAppointmentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppointmentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentStatus.Location = new System.Drawing.Point(3, 182);
            this.lblAppointmentStatus.Name = "lblAppointmentStatus";
            this.lblAppointmentStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAppointmentStatus.Size = new System.Drawing.Size(584, 80);
            this.lblAppointmentStatus.TabIndex = 6;
            this.lblAppointmentStatus.Text = clsUtilities.GetAppointmentStatusText(appointment.Appointment.Status);
            this.lblAppointmentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(593, 101);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(318, 81);
            this.label22.TabIndex = 5;
            this.label22.Text = "الدكتور المكلف :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDoctorName1
            // 
            this.lblDoctorName1.AutoSize = true;
            this.lblDoctorName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoctorName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorName1.Location = new System.Drawing.Point(3, 101);
            this.lblDoctorName1.Name = "lblDoctorName1";
            this.lblDoctorName1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDoctorName1.Size = new System.Drawing.Size(584, 81);
            this.lblDoctorName1.TabIndex = 4;
            this.lblDoctorName1.Text = appointment.DoctorFullName??"???";
            this.lblDoctorName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(593, 54);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(318, 47);
            this.label20.TabIndex = 3;
            this.label20.Text = "رقم هاتف المريض:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientPhoneNo1
            // 
            this.lblPatientPhoneNo1.AutoSize = true;
            this.lblPatientPhoneNo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatientPhoneNo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientPhoneNo1.Location = new System.Drawing.Point(3, 54);
            this.lblPatientPhoneNo1.Name = "lblPatientPhoneNo1";
            this.lblPatientPhoneNo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPatientPhoneNo1.Size = new System.Drawing.Size(584, 47);
            this.lblPatientPhoneNo1.TabIndex = 2;
            this.lblPatientPhoneNo1.Text = appointment.PatientPhone??"???";
            this.lblPatientPhoneNo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(593, 0);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(318, 54);
            this.label17.TabIndex = 0;
            this.label17.Text = "اسم المريض :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAppointmentDetails
            // 
            this.btnAppointmentDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAppointmentDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAppointmentDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAppointmentDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAppointmentDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppointmentDetails.FillColor = System.Drawing.Color.Transparent;
            this.btnAppointmentDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppointmentDetails.ForeColor = System.Drawing.Color.Black;
            this.btnAppointmentDetails.Image = global::DentistClinic_PresentationTier.Properties.Resources.ArowDown;
            this.btnAppointmentDetails.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAppointmentDetails.ImageOffset = new System.Drawing.Point(200, 0);
            this.btnAppointmentDetails.ImageSize = new System.Drawing.Size(50, 50);
            this.btnAppointmentDetails.Location = new System.Drawing.Point(0, 363);
            this.btnAppointmentDetails.Name = "btnAppointmentDetails";
            this.btnAppointmentDetails.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.btnAppointmentDetails.Size = new System.Drawing.Size(914, 78);
            this.btnAppointmentDetails.TabIndex = 2;
            this.btnAppointmentDetails.Text = "تفاصيل الموعد";
            this.btnAppointmentDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAppointmentDetails.Click += new System.EventHandler(this.btnDropCause_Click);
            this.btnAppointmentDetails.Tag = enDropMode.down;
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
            this.lblCause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCause.Dock = DockStyle.Top;
            this.lblCause.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // AppointmentShadowPanel
            //
            shadowPanel.BackColor = System.Drawing.Color.White;
            shadowPanel.Controls.Add(this.lblCause);
            shadowPanel.Controls.Add(this.btnAppointmentDetails);
            shadowPanel.Controls.Add(this.tlpAppointment);          
            shadowPanel.FillColor = System.Drawing.Color.White;
            shadowPanel.Location = new System.Drawing.Point(3, 3);
            shadowPanel.Name = "AppointmentShadowPanel";
            shadowPanel.Radius = 8;
            shadowPanel.ShadowColor = System.Drawing.Color.Black;
            shadowPanel.Size = new System.Drawing.Size(914, 531);
            shadowPanel.TabIndex = 0;
            shadowPanel.Tag = appointment;
            shadowPanel.MouseDoubleClick += AppointmentShadowPanel_MouseDoubleClick;
            shadowPanel.MouseEnter += AppointmentShadowPanel_MouseEnter;
            shadowPanel.MouseLeave += AppointmentShadowPanel_MouseLeave;
            shadowPanel.Width = (flpTodayAppointmentList.Width - shadowPanel.Margin.Horizontal)-100;
            flpTodayAppointmentList.Controls.Add(shadowPanel);
            tlpAppointment.ResumeLayout(false);
            tlpAppointment.PerformLayout();
            shadowPanel.ResumeLayout(false);
            shadowPanel.PerformLayout();
        }
        private void _loadMockAppointments()
        {
            IEnumerable<clsAppointmentsDetails> todayAppointment = new List<clsAppointmentsDetails>();
            todayAppointment = clsGenrateMockData._loadMockAppointments();
            _todayAppointment = (List<clsAppointmentsDetails>)todayAppointment;
        }


        // Quick Actions Panel Events
        private void WireEventsForQuickActionsPanel()
        {
            AttachHoverRecursive(spAddInvoice, ShadowPanels_Hover, shadowPanels_Leave);
            AttachHoverRecursive(spAddPatient, ShadowPanels_Hover, shadowPanels_Leave);
            AttachHoverRecursive(spAddAppointment, ShadowPanels_Hover, shadowPanels_Leave);
            AttachHoverRecursive(spAddProblem, ShadowPanels_Hover, shadowPanels_Leave);
            AttachDoubleClickRecursive(spAddPatient, QuickActionsShadowPanel_DoubleClick);
            AttachDoubleClickRecursive(spAddAppointment, QuickActionsShadowPanel_DoubleClick);
            AttachDoubleClickRecursive(spAddInvoice, QuickActionsShadowPanel_DoubleClick);
            AttachDoubleClickRecursive(spAddProblem, QuickActionsShadowPanel_DoubleClick);
        }
        private void ShadowPanels_Hover(object sender, EventArgs e)
        {
            if(sender is PictureBox pictureBox)
            {
                Guna2ShadowPanel guna2ShadowPanel = pictureBox?.Parent as Guna2ShadowPanel;
                guna2ShadowPanel.FillColor = Color.SteelBlue;
            }

            if (sender is System.Windows.Forms.Label label)
            {
                Guna2ShadowPanel guna2ShadowPanel = label?.Parent as Guna2ShadowPanel;
                guna2ShadowPanel.FillColor = Color.SteelBlue;
            }
        }
        private void shadowPanels_Leave(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                Guna2ShadowPanel guna2ShadowPanel = pictureBox?.Parent as Guna2ShadowPanel;
                guna2ShadowPanel.FillColor = Color.LightSlateGray;
            }

            if (sender is System.Windows.Forms.Label label)
            {
                Guna2ShadowPanel guna2ShadowPanel = label?.Parent as Guna2ShadowPanel;
                guna2ShadowPanel.FillColor = Color.LightSlateGray;
            }
        }
        private void AttachHoverRecursive(Control parent, EventHandler onEnter, EventHandler onLeave)
        {
            foreach (Control child in parent.Controls)
            {
                child.MouseEnter += onEnter;
                child.MouseLeave += onLeave;
                if (child.HasChildren)
                    AttachHoverRecursive(child, onEnter, onLeave);
            }
        }
        private void AttachDoubleClickRecursive(Control parent, MouseEventHandler onDoubleClick)
        {
            foreach (Control child in parent.Controls)
            {
                child.MouseDoubleClick += onDoubleClick;
                if (child.HasChildren)
                    AttachDoubleClickRecursive(child, onDoubleClick);
            }
        }
        private void QuickActionsShadowPanel_DoubleClick(object sender, MouseEventArgs e)
        {
            Guna2ShadowPanel PanelInfo = new Guna2ShadowPanel();
            if (sender is System.Windows.Forms.Label label)
            {
                 PanelInfo = label?.Parent as Guna2ShadowPanel;
            }
            else if(sender is System.Windows.Forms.PictureBox pictureBox)
            {
                 PanelInfo = pictureBox?.Parent as Guna2ShadowPanel;
            }

            switch (PanelInfo.Name)
            {
                case "spAddPatient":
                    var frmAddPatient = Program.ServiceProvider.GetRequiredService<frmAddOrEditePatientInformation>();
                    frmAddPatient.ShowDialog();
                    break;
                case "spAddAppointment":
                    MessageBox.Show("Add Appointment");
                    break;
                case "spAddProblem":
                    MessageBox.Show("add Problem");
                    break;
                case "spAddInvoice":
                    MessageBox.Show("Add Invoice");
                    break;
                default:
                    break;
            }   
        }

    }
}
