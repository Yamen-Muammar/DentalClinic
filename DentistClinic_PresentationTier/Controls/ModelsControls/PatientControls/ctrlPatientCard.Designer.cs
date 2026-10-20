using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls
{
    partial class ctrlPatientCard
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
            this.pnlCard = new Guna2Panel();
            this.tblMain = new TableLayoutPanel();
            this.lblTitleName = new Label();
            this.lblFullName = new Label();
            this.lblTitlePhone = new Label();
            this.lblPhone = new Label();
            this.lblTitleGender = new Label();
            this.lblGender = new Label();
            this.lblTitleAge = new Label();
            this.lblAge = new Label();
            this.lblTitleBlood = new Label();
            this.lblBlood = new Label();
            this.pnlCard.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCard
            //
            this.pnlCard.BorderRadius = 8;
            this.pnlCard.FillColor = Color.White;
            this.pnlCard.BorderColor = Color.FromArgb(200, 200, 200);
            this.pnlCard.BorderThickness = 1;
            this.pnlCard.Dock = DockStyle.Fill;
            this.pnlCard.Padding = new Padding(5);
            this.pnlCard.Controls.Add(this.tblMain);
            // 
            // tblMain — 2 columns (label 30%, value 70%), 5 rows
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tblMain.Dock = DockStyle.Fill;
            this.tblMain.Padding = new Padding(5);
            // Row 0
            this.tblMain.Controls.Add(this.lblTitleName, 0, 0);
            this.tblMain.Controls.Add(this.lblFullName, 1, 0);
            // Row 1
            this.tblMain.Controls.Add(this.lblTitlePhone, 0, 1);
            this.tblMain.Controls.Add(this.lblPhone, 1, 1);
            // Row 2
            this.tblMain.Controls.Add(this.lblTitleGender, 0, 2);
            this.tblMain.Controls.Add(this.lblGender, 1, 2);
            // Row 3
            this.tblMain.Controls.Add(this.lblTitleAge, 0, 3);
            this.tblMain.Controls.Add(this.lblAge, 1, 3);
            // Row 4
            this.tblMain.Controls.Add(this.lblTitleBlood, 0, 4);
            this.tblMain.Controls.Add(this.lblBlood, 1, 4);
            // 
            // Title labels
            // 
            this.lblTitleName.Text = "الاسم:";
            this.lblTitleName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitleName.Dock = DockStyle.Fill;
            this.lblTitleName.TextAlign = ContentAlignment.MiddleRight;

            this.lblTitlePhone.Text = "الهاتف:";
            this.lblTitlePhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitlePhone.Dock = DockStyle.Fill;
            this.lblTitlePhone.TextAlign = ContentAlignment.MiddleRight;

            this.lblTitleGender.Text = "الجنس:";
            this.lblTitleGender.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitleGender.Dock = DockStyle.Fill;
            this.lblTitleGender.TextAlign = ContentAlignment.MiddleRight;

            this.lblTitleAge.Text = "العمر:";
            this.lblTitleAge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitleAge.Dock = DockStyle.Fill;
            this.lblTitleAge.TextAlign = ContentAlignment.MiddleRight;

            this.lblTitleBlood.Text = "فصيلة الدم:";
            this.lblTitleBlood.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitleBlood.Dock = DockStyle.Fill;
            this.lblTitleBlood.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Value labels
            // 
            this.lblFullName.Font = new Font("Segoe UI", 10F);
            this.lblFullName.Dock = DockStyle.Fill;
            this.lblFullName.TextAlign = ContentAlignment.MiddleRight;

            this.lblPhone.Font = new Font("Segoe UI", 10F);
            this.lblPhone.Dock = DockStyle.Fill;
            this.lblPhone.TextAlign = ContentAlignment.MiddleRight;

            this.lblGender.Font = new Font("Segoe UI", 10F);
            this.lblGender.Dock = DockStyle.Fill;
            this.lblGender.TextAlign = ContentAlignment.MiddleRight;

            this.lblAge.Font = new Font("Segoe UI", 10F);
            this.lblAge.Dock = DockStyle.Fill;
            this.lblAge.TextAlign = ContentAlignment.MiddleRight;

            this.lblBlood.Font = new Font("Segoe UI", 10F);
            this.lblBlood.Dock = DockStyle.Fill;
            this.lblBlood.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ctrlPatientCard
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.pnlCard);
            this.Name = "ctrlPatientCard";
            this.RightToLeft = RightToLeft.Yes;
            this.Size = new Size(400, 180);
            this.pnlCard.ResumeLayout(false);
            this.tblMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Guna2Panel pnlCard;
        private TableLayoutPanel tblMain;
        private Label lblTitleName;
        private Label lblFullName;
        private Label lblTitlePhone;
        private Label lblPhone;
        private Label lblTitleGender;
        private Label lblGender;
        private Label lblTitleAge;
        private Label lblAge;
        private Label lblTitleBlood;
        private Label lblBlood;
    }
}
