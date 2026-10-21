using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    partial class frmAddProblem
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
            this.tblMain = new TableLayoutPanel();
            this.lblTitle = new Label();
            this.lblDiagnosis = new Label();
            this.txtDiagnosis = new Guna2TextBox();
            this.lblCost = new Label();
            this.txtCost = new Guna2TextBox();
            this.pnlButtons = new FlowLayoutPanel();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();
            this.tblMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain — 1 column, 6 rows
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tblMain.RowCount = 6;
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  // title
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));  // lblDiagnosis
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // txtDiagnosis (fill)
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));  // lblCost
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // txtCost
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  // buttons
            this.tblMain.Dock = DockStyle.Fill;
            this.tblMain.Padding = new Padding(15);
            this.tblMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblMain.Controls.Add(this.lblDiagnosis, 0, 1);
            this.tblMain.Controls.Add(this.txtDiagnosis, 0, 2);
            this.tblMain.Controls.Add(this.lblCost, 0, 3);
            this.tblMain.Controls.Add(this.txtCost, 0, 4);
            this.tblMain.Controls.Add(this.pnlButtons, 0, 5);
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "إضافة مشكلة طبية";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.SteelBlue;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.Text = "التشخيص:";
            this.lblDiagnosis.Font = new Font("Segoe UI", 10F);
            this.lblDiagnosis.Dock = DockStyle.Fill;
            this.lblDiagnosis.TextAlign = ContentAlignment.BottomRight;
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Dock = DockStyle.Fill;
            // 
            // lblCost
            // 
            this.lblCost.Text = "التكلفة الكلية:";
            this.lblCost.Font = new Font("Segoe UI", 10F);
            this.lblCost.Dock = DockStyle.Fill;
            this.lblCost.TextAlign = ContentAlignment.BottomRight;
            // 
            // txtCost
            // 
            this.txtCost.Dock = DockStyle.Fill;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Dock = DockStyle.Fill;
            this.pnlButtons.FlowDirection = FlowDirection.RightToLeft;
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            // 
            // btnSave
            // 
            this.btnSave.Text = "حفظ";
            this.btnSave.FillColor = Color.SteelBlue;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.Size = new Size(100, 35);
            this.btnSave.BorderRadius = 5;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.FillColor = Color.LightGray;
            this.btnCancel.ForeColor = Color.Black;
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.Size = new Size(100, 35);
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddProblem
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(400, 340);
            this.Controls.Add(this.tblMain);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddProblem";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "إضافة مشكلة طبية";
            this.tblMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private Label lblDiagnosis;
        private Guna2TextBox txtDiagnosis;
        private Label lblCost;
        private Guna2TextBox txtCost;
        private FlowLayoutPanel pnlButtons;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
    }
}
