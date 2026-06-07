namespace DentistClinic_PresentationTier.Controls.MainUIControls
{
    partial class ctrlDashBoard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTodayPatient = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblThisMonthPatients = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlNotConfirmedPayments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblunConfirmedPayments = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTodayAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblTodayAppoinmentsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2spnlHedder = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlTodayPatient.SuspendLayout();
            this.pnlNotConfirmedPayments.SuspendLayout();
            this.pnlTodayAppointments.SuspendLayout();
            this.guna2spnlHedder.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.74172F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.guna2spnlHedder, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1920, 857);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlTodayPatient);
            this.flowLayoutPanel1.Controls.Add(this.pnlNotConfirmedPayments);
            this.flowLayoutPanel1.Controls.Add(this.pnlTodayAppointments);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(603, 114);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1314, 740);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // pnlTodayPatient
            // 
            this.pnlTodayPatient.BackColor = System.Drawing.Color.Transparent;
            this.pnlTodayPatient.Controls.Add(this.lblThisMonthPatients);
            this.pnlTodayPatient.Controls.Add(this.label6);
            this.pnlTodayPatient.FillColor = System.Drawing.Color.White;
            this.pnlTodayPatient.Location = new System.Drawing.Point(803, 3);
            this.pnlTodayPatient.Name = "pnlTodayPatient";
            this.pnlTodayPatient.Radius = 10;
            this.pnlTodayPatient.ShadowColor = System.Drawing.Color.Black;
            this.pnlTodayPatient.ShadowDepth = 70;
            this.pnlTodayPatient.ShadowShift = 7;
            this.pnlTodayPatient.Size = new System.Drawing.Size(508, 144);
            this.pnlTodayPatient.TabIndex = 10;
            this.pnlTodayPatient.DoubleClick += new System.EventHandler(this.pnlTodayPatient_DoubleClick);
            this.pnlTodayPatient.MouseEnter += new System.EventHandler(this.Panle_MouseEnter);
            this.pnlTodayPatient.MouseLeave += new System.EventHandler(this.Panle_MouseLeave);
            // 
            // lblThisMonthPatients
            // 
            this.lblThisMonthPatients.AutoSize = true;
            this.lblThisMonthPatients.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThisMonthPatients.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblThisMonthPatients.Location = new System.Drawing.Point(400, 60);
            this.lblThisMonthPatients.Name = "lblThisMonthPatients";
            this.lblThisMonthPatients.Size = new System.Drawing.Size(84, 65);
            this.lblThisMonthPatients.TabIndex = 3;
            this.lblThisMonthPatients.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(239, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "عدد المرضى هذا الشهر؛";
            // 
            // pnlNotConfirmedPayments
            // 
            this.pnlNotConfirmedPayments.BackColor = System.Drawing.Color.Transparent;
            this.pnlNotConfirmedPayments.Controls.Add(this.lblunConfirmedPayments);
            this.pnlNotConfirmedPayments.Controls.Add(this.label4);
            this.pnlNotConfirmedPayments.FillColor = System.Drawing.Color.White;
            this.pnlNotConfirmedPayments.Location = new System.Drawing.Point(289, 3);
            this.pnlNotConfirmedPayments.Name = "pnlNotConfirmedPayments";
            this.pnlNotConfirmedPayments.Radius = 10;
            this.pnlNotConfirmedPayments.ShadowColor = System.Drawing.Color.Black;
            this.pnlNotConfirmedPayments.ShadowDepth = 70;
            this.pnlNotConfirmedPayments.ShadowShift = 7;
            this.pnlNotConfirmedPayments.Size = new System.Drawing.Size(508, 144);
            this.pnlNotConfirmedPayments.TabIndex = 9;
            this.pnlNotConfirmedPayments.DoubleClick += new System.EventHandler(this.pnlNotConfirmedPayments_DoubleClick);
            this.pnlNotConfirmedPayments.MouseEnter += new System.EventHandler(this.Panle_MouseEnter);
            this.pnlNotConfirmedPayments.MouseLeave += new System.EventHandler(this.Panle_MouseLeave);
            // 
            // lblunConfirmedPayments
            // 
            this.lblunConfirmedPayments.AutoSize = true;
            this.lblunConfirmedPayments.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblunConfirmedPayments.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblunConfirmedPayments.Location = new System.Drawing.Point(394, 60);
            this.lblunConfirmedPayments.Name = "lblunConfirmedPayments";
            this.lblunConfirmedPayments.Size = new System.Drawing.Size(84, 65);
            this.lblunConfirmedPayments.TabIndex = 3;
            this.lblunConfirmedPayments.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(213, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "عدد الحولات الغير مؤكدة؛";
            // 
            // pnlTodayAppointments
            // 
            this.pnlTodayAppointments.BackColor = System.Drawing.Color.Transparent;
            this.pnlTodayAppointments.Controls.Add(this.lblTodayAppoinmentsCount);
            this.pnlTodayAppointments.Controls.Add(this.label3);
            this.pnlTodayAppointments.FillColor = System.Drawing.Color.White;
            this.pnlTodayAppointments.Location = new System.Drawing.Point(803, 190);
            this.pnlTodayAppointments.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.pnlTodayAppointments.Name = "pnlTodayAppointments";
            this.pnlTodayAppointments.Radius = 10;
            this.pnlTodayAppointments.ShadowColor = System.Drawing.Color.Black;
            this.pnlTodayAppointments.ShadowDepth = 70;
            this.pnlTodayAppointments.ShadowShift = 7;
            this.pnlTodayAppointments.Size = new System.Drawing.Size(508, 144);
            this.pnlTodayAppointments.TabIndex = 3;
            this.pnlTodayAppointments.DoubleClick += new System.EventHandler(this.pnlTodayPatient_DoubleClick);
            this.pnlTodayAppointments.MouseEnter += new System.EventHandler(this.Panle_MouseEnter);
            this.pnlTodayAppointments.MouseLeave += new System.EventHandler(this.Panle_MouseLeave);
            // 
            // lblTodayAppoinmentsCount
            // 
            this.lblTodayAppoinmentsCount.AutoSize = true;
            this.lblTodayAppoinmentsCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayAppoinmentsCount.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTodayAppoinmentsCount.Location = new System.Drawing.Point(395, 60);
            this.lblTodayAppoinmentsCount.Name = "lblTodayAppoinmentsCount";
            this.lblTodayAppoinmentsCount.Size = new System.Drawing.Size(84, 65);
            this.lblTodayAppoinmentsCount.TabIndex = 3;
            this.lblTodayAppoinmentsCount.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(277, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "عدد المواعيد اليوم؛";
            // 
            // guna2spnlHedder
            // 
            this.guna2spnlHedder.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.guna2spnlHedder, 2);
            this.guna2spnlHedder.Controls.Add(this.tableLayoutPanel4);
            this.guna2spnlHedder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2spnlHedder.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2spnlHedder.Location = new System.Drawing.Point(0, 0);
            this.guna2spnlHedder.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.guna2spnlHedder.Name = "guna2spnlHedder";
            this.guna2spnlHedder.ShadowColor = System.Drawing.Color.Black;
            this.guna2spnlHedder.ShadowDepth = 40;
            this.guna2spnlHedder.ShadowShift = 7;
            this.guna2spnlHedder.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2spnlHedder.Size = new System.Drawing.Size(1920, 91);
            this.guna2spnlHedder.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1920, 91);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblPageTitle);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(963, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(954, 85);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Akhbar MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(750, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(201, 81);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "لوحة التحكم";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ctrlDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctrlDashBoard";
            this.Size = new System.Drawing.Size(1920, 857);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlTodayPatient.ResumeLayout(false);
            this.pnlTodayPatient.PerformLayout();
            this.pnlNotConfirmedPayments.ResumeLayout(false);
            this.pnlNotConfirmedPayments.PerformLayout();
            this.pnlTodayAppointments.ResumeLayout(false);
            this.pnlTodayAppointments.PerformLayout();
            this.guna2spnlHedder.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2spnlHedder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTodayPatient;
        private System.Windows.Forms.Label lblThisMonthPatients;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlNotConfirmedPayments;
        private System.Windows.Forms.Label lblunConfirmedPayments;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTodayAppointments;
        private System.Windows.Forms.Label lblTodayAppoinmentsCount;
        private System.Windows.Forms.Label label3;
    }
}
