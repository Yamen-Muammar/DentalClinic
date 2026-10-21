using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    partial class frmAddAppointment
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cbDoctors = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tblTime = new System.Windows.Forms.TableLayoutPanel();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.cbStartTime = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbAmPm = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.txtEndTime = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCause = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblCause = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.tblTime.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblMain.Controls.Add(this.lblDoctor, 0, 1);
            this.tblMain.Controls.Add(this.cbDoctors, 0, 2);
            this.tblMain.Controls.Add(this.lblDate, 0, 3);
            this.tblMain.Controls.Add(this.dtpDate, 0, 4);
            this.tblMain.Controls.Add(this.tblTime, 0, 5);
            this.tblMain.Controls.Add(this.txtCause, 0, 6);
            this.tblMain.Controls.Add(this.pnlButtons, 0, 7);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(6);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.tblMain.RowCount = 8;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.253623F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.449907F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.062384F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.992141F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.742633F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.23576F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.84479F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25912F));
            this.tblMain.Size = new System.Drawing.Size(1095, 1058);
            this.tblMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(36, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1023, 84);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "إضافة موعد";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDoctor
            // 
            this.lblDoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDoctor.Location = new System.Drawing.Point(36, 104);
            this.lblDoctor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(1023, 65);
            this.lblDoctor.TabIndex = 1;
            this.lblDoctor.Text = "الطبيب:";
            this.lblDoctor.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // cbDoctors
            // 
            this.cbDoctors.BackColor = System.Drawing.Color.Transparent;
            this.cbDoctors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDoctors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctors.FocusedColor = System.Drawing.Color.Empty;
            this.cbDoctors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbDoctors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDoctors.ItemHeight = 60;
            this.cbDoctors.Location = new System.Drawing.Point(36, 175);
            this.cbDoctors.Margin = new System.Windows.Forms.Padding(6);
            this.cbDoctors.Name = "cbDoctors";
            this.cbDoctors.Size = new System.Drawing.Size(1023, 66);
            this.cbDoctors.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Location = new System.Drawing.Point(36, 251);
            this.lblDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(1023, 61);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "التاريخ:";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(36, 318);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(6);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(1023, 57);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.Value = new System.DateTime(2026, 10, 21, 0, 52, 26, 906);
            // 
            // tblTime
            // 
            this.tblTime.ColumnCount = 5;
            this.tblTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTime.Controls.Add(this.lblStartTime, 0, 0);
            this.tblTime.Controls.Add(this.cbStartTime, 1, 0);
            this.tblTime.Controls.Add(this.cbAmPm, 2, 0);
            this.tblTime.Controls.Add(this.lblEndTime, 3, 0);
            this.tblTime.Controls.Add(this.txtEndTime, 4, 0);
            this.tblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTime.Location = new System.Drawing.Point(36, 407);
            this.tblTime.Margin = new System.Windows.Forms.Padding(6);
            this.tblTime.Name = "tblTime";
            this.tblTime.RowCount = 1;
            this.tblTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTime.Size = new System.Drawing.Size(1023, 194);
            this.tblTime.TabIndex = 5;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStartTime.Location = new System.Drawing.Point(876, 0);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(141, 194);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "وقت البداية:";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbStartTime
            // 
            this.cbStartTime.BackColor = System.Drawing.Color.Transparent;
            this.cbStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStartTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartTime.FocusedColor = System.Drawing.Color.Empty;
            this.cbStartTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbStartTime.ItemHeight = 36;
            this.cbStartTime.Location = new System.Drawing.Point(621, 6);
            this.cbStartTime.Margin = new System.Windows.Forms.Padding(6);
            this.cbStartTime.Name = "cbStartTime";
            this.cbStartTime.Size = new System.Drawing.Size(243, 42);
            this.cbStartTime.TabIndex = 1;
            // 
            // cbAmPm
            // 
            this.cbAmPm.BackColor = System.Drawing.Color.Transparent;
            this.cbAmPm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAmPm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAmPm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAmPm.FocusedColor = System.Drawing.Color.Empty;
            this.cbAmPm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbAmPm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbAmPm.ItemHeight = 36;
            this.cbAmPm.Location = new System.Drawing.Point(417, 6);
            this.cbAmPm.Margin = new System.Windows.Forms.Padding(6);
            this.cbAmPm.Name = "cbAmPm";
            this.cbAmPm.Size = new System.Drawing.Size(192, 42);
            this.cbAmPm.TabIndex = 2;
            // 
            // lblEndTime
            // 
            this.lblEndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEndTime.Location = new System.Drawing.Point(264, 0);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(141, 194);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = "وقت النهاية:";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEndTime.DefaultText = "تلقائي (+1 ساعة)";
            this.txtEndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEndTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtEndTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtEndTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.txtEndTime.Location = new System.Drawing.Point(6, 6);
            this.txtEndTime.Margin = new System.Windows.Forms.Padding(6);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.PlaceholderText = "";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.SelectedText = "";
            this.txtEndTime.Size = new System.Drawing.Size(246, 182);
            this.txtEndTime.TabIndex = 4;
            this.txtEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCause
            // 
            this.txtCause.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCause.DefaultText = "";
            this.txtCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCause.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCause.Location = new System.Drawing.Point(36, 613);
            this.txtCause.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtCause.Multiline = true;
            this.txtCause.Name = "txtCause";
            this.txtCause.PlaceholderText = "سبب الزيارة...";
            this.txtCause.SelectedText = "";
            this.txtCause.Size = new System.Drawing.Size(1023, 302);
            this.txtCause.TabIndex = 6;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(36, 927);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(6);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1023, 105);
            this.pnlButtons.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.FillColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(6, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 91);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.FillColor = System.Drawing.Color.LightGray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(178, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 91);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCause
            // 
            this.lblCause.Location = new System.Drawing.Point(0, 0);
            this.lblCause.Name = "lblCause";
            this.lblCause.Size = new System.Drawing.Size(100, 23);
            this.lblCause.TabIndex = 0;
            // 
            // frmAddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1095, 1058);
            this.Controls.Add(this.tblMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddAppointment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة موعد";
            this.tblMain.ResumeLayout(false);
            this.tblTime.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private Label lblDoctor;
        private Guna2ComboBox cbDoctors;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private TableLayoutPanel tblTime;
        private Label lblStartTime;
        private Guna2ComboBox cbStartTime;
        private Guna2ComboBox cbAmPm;
        private Label lblEndTime;
        private Guna2TextBox txtEndTime;
        private Label lblCause;
        private Guna2TextBox txtCause;
        private FlowLayoutPanel pnlButtons;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
    }
}
