using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls
{
    partial class ctrlProblemCard
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
            this.pnlCard = new Guna.UI2.WinForms.Guna2Panel();
            this.tblCard = new System.Windows.Forms.TableLayoutPanel();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.tblCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlCard.BorderRadius = 8;
            this.pnlCard.BorderThickness = 1;
            this.pnlCard.Controls.Add(this.tblCard);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.FillColor = System.Drawing.Color.White;
            this.pnlCard.Location = new System.Drawing.Point(6, 6);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(662, 196);
            this.pnlCard.TabIndex = 0;
            // 
            // tblCard
            // 
            this.tblCard.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tblCard.ColumnCount = 2;
            this.tblCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblCard.Controls.Add(this.lblDiagnosis, 0, 0);
            this.tblCard.Controls.Add(this.lblStatus, 1, 0);
            this.tblCard.Controls.Add(this.lblDate, 0, 1);
            this.tblCard.Controls.Add(this.lblCost, 1, 1);
            this.tblCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCard.Location = new System.Drawing.Point(0, 0);
            this.tblCard.Margin = new System.Windows.Forms.Padding(6);
            this.tblCard.Name = "tblCard";
            this.tblCard.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.tblCard.RowCount = 2;
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCard.Size = new System.Drawing.Size(662, 196);
            this.tblCard.TabIndex = 0;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.BackColor = System.Drawing.Color.Transparent;
            this.lblDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblDiagnosis.Location = new System.Drawing.Point(277, 29);
            this.lblDiagnosis.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(349, 69);
            this.lblDiagnosis.TabIndex = 0;
            this.lblDiagnosis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(36, 29);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(229, 69);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(277, 98);
            this.lblDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(349, 69);
            this.lblDate.TabIndex = 2;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCost
            // 
            this.lblCost.BackColor = System.Drawing.Color.Transparent;
            this.lblCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCost.ForeColor = System.Drawing.Color.DimGray;
            this.lblCost.Location = new System.Drawing.Point(36, 98);
            this.lblCost.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(229, 69);
            this.lblCost.TabIndex = 3;
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlProblemCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlCard);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "ctrlProblemCard";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(674, 208);
            this.pnlCard.ResumeLayout(false);
            this.tblCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna2Panel pnlCard;
        private TableLayoutPanel tblCard;
        private Label lblDiagnosis;
        private Label lblDate;
        private Label lblCost;
        private Label lblStatus;
    }
}
