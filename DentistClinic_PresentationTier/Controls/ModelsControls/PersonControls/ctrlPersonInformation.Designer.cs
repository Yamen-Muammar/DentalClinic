namespace DentistClinic_PresentationTier.Controls.ModelsControls.PersonControls
{
    partial class ctrlPersonInformation
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
            this.MainContainerControl = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.btnEditePatientInfo = new Guna.UI2.WinForms.Guna2CircleButton();
            this.spPhoneNums = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.flpPhoneNumbers = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblLastUpdateDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.indecatorPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2WinProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.MainContainerControl.SuspendLayout();
            this.spPhoneNums.SuspendLayout();
            this.indecatorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContainerControl
            // 
            this.MainContainerControl.BackColor = System.Drawing.Color.Transparent;
            this.MainContainerControl.BorderColor = System.Drawing.Color.White;
            this.MainContainerControl.BorderRadius = 10;
            this.MainContainerControl.BorderThickness = 4;
            this.MainContainerControl.Controls.Add(this.indecatorPanel);
            this.MainContainerControl.Controls.Add(this.btnEditePatientInfo);
            this.MainContainerControl.Controls.Add(this.spPhoneNums);
            this.MainContainerControl.Controls.Add(this.label6);
            this.MainContainerControl.Controls.Add(this.lblNationalNo);
            this.MainContainerControl.Controls.Add(this.lblDateOfBirth);
            this.MainContainerControl.Controls.Add(this.lblLastUpdateDate);
            this.MainContainerControl.Controls.Add(this.lblCreatedDate);
            this.MainContainerControl.Controls.Add(this.label5);
            this.MainContainerControl.Controls.Add(this.label4);
            this.MainContainerControl.Controls.Add(this.label3);
            this.MainContainerControl.Controls.Add(this.label2);
            this.MainContainerControl.Controls.Add(this.lblGender);
            this.MainContainerControl.Controls.Add(this.lblFullName);
            this.MainContainerControl.Controls.Add(this.label1);
            this.MainContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainerControl.FillColor = System.Drawing.Color.SteelBlue;
            this.MainContainerControl.ForeColor = System.Drawing.Color.Gainsboro;
            this.MainContainerControl.Location = new System.Drawing.Point(0, 0);
            this.MainContainerControl.Name = "MainContainerControl";
            this.MainContainerControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MainContainerControl.Size = new System.Drawing.Size(1085, 540);
            this.MainContainerControl.TabIndex = 0;
            this.MainContainerControl.Text = "PersonInformation";
            // 
            // btnEditePatientInfo
            // 
            this.btnEditePatientInfo.BorderColor = System.Drawing.Color.Transparent;
            this.btnEditePatientInfo.BorderThickness = 2;
            this.btnEditePatientInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditePatientInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditePatientInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditePatientInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditePatientInfo.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditePatientInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditePatientInfo.ForeColor = System.Drawing.Color.White;
            this.btnEditePatientInfo.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnEditePatientInfo.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnEditePatientInfo.Image = global::DentistClinic_PresentationTier.Properties.Resources.EditePatientInfo;
            this.btnEditePatientInfo.ImageSize = new System.Drawing.Size(50, 50);
            this.btnEditePatientInfo.Location = new System.Drawing.Point(13, 449);
            this.btnEditePatientInfo.Name = "btnEditePatientInfo";
            this.btnEditePatientInfo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEditePatientInfo.Size = new System.Drawing.Size(77, 76);
            this.btnEditePatientInfo.TabIndex = 2;
            this.btnEditePatientInfo.UseTransparentBackground = true;
            this.btnEditePatientInfo.Click += new System.EventHandler(this.btnEditePatientInfo_Click);
            // 
            // spPhoneNums
            // 
            this.spPhoneNums.BackColor = System.Drawing.Color.Transparent;
            this.spPhoneNums.Controls.Add(this.flpPhoneNumbers);
            this.spPhoneNums.FillColor = System.Drawing.Color.White;
            this.spPhoneNums.Location = new System.Drawing.Point(13, 31);
            this.spPhoneNums.Margin = new System.Windows.Forms.Padding(0);
            this.spPhoneNums.Name = "spPhoneNums";
            this.spPhoneNums.Radius = 10;
            this.spPhoneNums.ShadowColor = System.Drawing.Color.Black;
            this.spPhoneNums.Size = new System.Drawing.Size(547, 409);
            this.spPhoneNums.TabIndex = 1;
            // 
            // flpPhoneNumbers
            // 
            this.flpPhoneNumbers.AutoScroll = true;
            this.flpPhoneNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPhoneNumbers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPhoneNumbers.Location = new System.Drawing.Point(0, 0);
            this.flpPhoneNumbers.Margin = new System.Windows.Forms.Padding(0);
            this.flpPhoneNumbers.Name = "flpPhoneNumbers";
            this.flpPhoneNumbers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flpPhoneNumbers.Size = new System.Drawing.Size(547, 409);
            this.flpPhoneNumbers.TabIndex = 0;
            this.flpPhoneNumbers.WrapContents = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Simplified Arabic Fixed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(841, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "تاريخ اخر تعديل :";
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Font = new System.Drawing.Font("Simplified Arabic Fixed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNationalNo.ForeColor = System.Drawing.Color.White;
            this.lblNationalNo.Location = new System.Drawing.Point(671, 109);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(138, 27);
            this.lblNationalNo.TabIndex = 0;
            this.lblNationalNo.Text = "420271999";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Simplified Arabic Fixed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.White;
            this.lblDateOfBirth.Location = new System.Drawing.Point(635, 165);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(152, 27);
            this.lblDateOfBirth.TabIndex = 0;
            this.lblDateOfBirth.Text = "20/12/2026";
            // 
            // lblLastUpdateDate
            // 
            this.lblLastUpdateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdateDate.AutoSize = true;
            this.lblLastUpdateDate.Font = new System.Drawing.Font("Simplified Arabic Fixed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLastUpdateDate.ForeColor = System.Drawing.Color.White;
            this.lblLastUpdateDate.Location = new System.Drawing.Point(693, 488);
            this.lblLastUpdateDate.Name = "lblLastUpdateDate";
            this.lblLastUpdateDate.Size = new System.Drawing.Size(142, 27);
            this.lblLastUpdateDate.TabIndex = 0;
            this.lblLastUpdateDate.Text = "20/12/2026";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Simplified Arabic Fixed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCreatedDate.ForeColor = System.Drawing.Color.White;
            this.lblCreatedDate.Location = new System.Drawing.Point(732, 449);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(142, 27);
            this.lblCreatedDate.TabIndex = 0;
            this.lblCreatedDate.Text = "20/12/2026";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Simplified Arabic Fixed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(880, 449);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "تاريخ الاضافة :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Simplified Arabic Fixed", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(924, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 33);
            this.label4.TabIndex = 0;
            this.label4.Text = "الجنـس :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Simplified Arabic Fixed", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(822, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "تاريخ الميلاد :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic Fixed", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(856, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "رقم الهوية :";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Akhbar MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGender.ForeColor = System.Drawing.Color.White;
            this.lblGender.Location = new System.Drawing.Point(856, 202);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(62, 58);
            this.lblGender.TabIndex = 0;
            this.lblGender.Text = "ذكر";
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Akhbar MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFullName.ForeColor = System.Drawing.Color.White;
            this.lblFullName.Location = new System.Drawing.Point(714, 31);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(126, 58);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "يامن معمر";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic Fixed", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(856, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم المريض :";
            // 
            // indecatorPanel
            // 
            this.indecatorPanel.Controls.Add(this.guna2WinProgressIndicator1);
            this.indecatorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indecatorPanel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.indecatorPanel.FillColor2 = System.Drawing.Color.WhiteSmoke;
            this.indecatorPanel.Location = new System.Drawing.Point(0, 0);
            this.indecatorPanel.Name = "indecatorPanel";
            this.indecatorPanel.Size = new System.Drawing.Size(1085, 540);
            this.indecatorPanel.TabIndex = 3;
            // 
            // guna2WinProgressIndicator1
            // 
            this.guna2WinProgressIndicator1.AnimationSpeed = 90;
            this.guna2WinProgressIndicator1.AutoStart = true;
            this.guna2WinProgressIndicator1.CircleSize = 3F;
            this.guna2WinProgressIndicator1.Location = new System.Drawing.Point(455, 165);
            this.guna2WinProgressIndicator1.Name = "guna2WinProgressIndicator1";
            this.guna2WinProgressIndicator1.NumberOfCircles = 12;
            this.guna2WinProgressIndicator1.ProgressColor = System.Drawing.Color.SteelBlue;
            this.guna2WinProgressIndicator1.Size = new System.Drawing.Size(145, 136);
            this.guna2WinProgressIndicator1.TabIndex = 0;
            // 
            // ctrlPersonInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MainContainerControl);
            this.Name = "ctrlPersonInformation";
            this.Size = new System.Drawing.Size(1085, 540);
            this.Load += new System.EventHandler(this.ctrlPersonInformation_Load);
            this.MainContainerControl.ResumeLayout(false);
            this.MainContainerControl.PerformLayout();
            this.spPhoneNums.ResumeLayout(false);
            this.indecatorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl MainContainerControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblGender;
        private Guna.UI2.WinForms.Guna2ShadowPanel spPhoneNums;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblLastUpdateDate;
        private System.Windows.Forms.FlowLayoutPanel flpPhoneNumbers;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2CircleButton btnEditePatientInfo;
        private Guna.UI2.WinForms.Guna2GradientPanel indecatorPanel;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator guna2WinProgressIndicator1;
    }
}
