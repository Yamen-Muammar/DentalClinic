using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    partial class frmMedicalFile
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tblContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.flpAppointments = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddAppointment = new Guna.UI2.WinForms.Guna2Button();
            this.lblAppointmentsTitle = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.flpProblems = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddProblem = new Guna.UI2.WinForms.Guna2Button();
            this.lblProblemsTitle = new System.Windows.Forms.Label();
            this.patientCard = new DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls.ctrlPatientCard();
            this.tblMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tblContent.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.pnlHeader, 0, 0);
            this.tblMain.Controls.Add(this.tblContent, 0, 1);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(1800, 1154);
            this.tblMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(6, 6);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1788, 103);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1788, 103);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "الملف الطبي";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblContent
            // 
            this.tblContent.ColumnCount = 2;
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblContent.Controls.Add(this.pnlLeft, 0, 0);
            this.tblContent.Controls.Add(this.pnlRight, 1, 0);
            this.tblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContent.Location = new System.Drawing.Point(6, 121);
            this.tblContent.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tblContent.Name = "tblContent";
            this.tblContent.RowCount = 1;
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.Size = new System.Drawing.Size(1788, 1027);
            this.tblContent.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.flpAppointments);
            this.pnlLeft.Controls.Add(this.btnAddAppointment);
            this.pnlLeft.Controls.Add(this.lblAppointmentsTitle);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(1079, 6);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.pnlLeft.Size = new System.Drawing.Size(703, 1015);
            this.pnlLeft.TabIndex = 0;
            // 
            // flpAppointments
            // 
            this.flpAppointments.AutoScroll = true;
            this.flpAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAppointments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAppointments.Location = new System.Drawing.Point(20, 86);
            this.flpAppointments.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flpAppointments.Name = "flpAppointments";
            this.flpAppointments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flpAppointments.Size = new System.Drawing.Size(661, 841);
            this.flpAppointments.TabIndex = 0;
            this.flpAppointments.WrapContents = false;
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.BorderRadius = 5;
            this.btnAddAppointment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddAppointment.Enabled = false;
            this.btnAddAppointment.FillColor = System.Drawing.Color.SteelBlue;
            this.btnAddAppointment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAddAppointment.Location = new System.Drawing.Point(20, 927);
            this.btnAddAppointment.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(661, 67);
            this.btnAddAppointment.TabIndex = 1;
            this.btnAddAppointment.Text = "+ إضافة موعد";
            // 
            // lblAppointmentsTitle
            // 
            this.lblAppointmentsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppointmentsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppointmentsTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAppointmentsTitle.Location = new System.Drawing.Point(20, 19);
            this.lblAppointmentsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAppointmentsTitle.Name = "lblAppointmentsTitle";
            this.lblAppointmentsTitle.Size = new System.Drawing.Size(661, 67);
            this.lblAppointmentsTitle.TabIndex = 2;
            this.lblAppointmentsTitle.Text = "المواعيد";
            this.lblAppointmentsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.flpProblems);
            this.pnlRight.Controls.Add(this.btnAddProblem);
            this.pnlRight.Controls.Add(this.lblProblemsTitle);
            this.pnlRight.Controls.Add(this.patientCard);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(6, 6);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.pnlRight.Size = new System.Drawing.Size(1061, 1015);
            this.pnlRight.TabIndex = 1;
            // 
            // flpProblems
            // 
            this.flpProblems.AutoScroll = true;
            this.flpProblems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProblems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpProblems.Location = new System.Drawing.Point(20, 432);
            this.flpProblems.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flpProblems.Name = "flpProblems";
            this.flpProblems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flpProblems.Size = new System.Drawing.Size(1021, 497);
            this.flpProblems.TabIndex = 0;
            this.flpProblems.WrapContents = false;
            // 
            // btnAddProblem
            // 
            this.btnAddProblem.BorderRadius = 5;
            this.btnAddProblem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddProblem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddProblem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddProblem.ForeColor = System.Drawing.Color.White;
            this.btnAddProblem.Location = new System.Drawing.Point(20, 929);
            this.btnAddProblem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddProblem.Name = "btnAddProblem";
            this.btnAddProblem.Size = new System.Drawing.Size(1021, 67);
            this.btnAddProblem.TabIndex = 1;
            this.btnAddProblem.Text = "+ إضافة مشكلة";
            // 
            // lblProblemsTitle
            // 
            this.lblProblemsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProblemsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProblemsTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblProblemsTitle.Location = new System.Drawing.Point(20, 365);
            this.lblProblemsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProblemsTitle.Name = "lblProblemsTitle";
            this.lblProblemsTitle.Size = new System.Drawing.Size(1021, 67);
            this.lblProblemsTitle.TabIndex = 2;
            this.lblProblemsTitle.Text = "المشاكل الطبية";
            this.lblProblemsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // patientCard
            // 
            this.patientCard.BackColor = System.Drawing.Color.White;
            this.patientCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientCard.Location = new System.Drawing.Point(20, 19);
            this.patientCard.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.patientCard.Name = "patientCard";
            this.patientCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.patientCard.Size = new System.Drawing.Size(1021, 346);
            this.patientCard.TabIndex = 3;
            // 
            // frmMedicalFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1800, 1154);
            this.Controls.Add(this.tblMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmMedicalFile";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الملف الطبي";
            this.tblMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tblContent.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TableLayoutPanel tblMain;
        private Panel pnlHeader;
        private Label lblTitle;
        private TableLayoutPanel tblContent;
        private Panel pnlLeft;
        private Label lblAppointmentsTitle;
        private FlowLayoutPanel flpAppointments;
        private Guna2Button btnAddAppointment;
        private Panel pnlRight;
        private ctrlPatientCard patientCard;
        private Label lblProblemsTitle;
        private FlowLayoutPanel flpProblems;
        private Guna2Button btnAddProblem;
    }
}
