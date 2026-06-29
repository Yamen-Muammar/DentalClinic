namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    partial class frmAddOrEditePatient
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbMainBox = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbDay = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbHealthProblems = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbBloodType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbGeneralAllergies = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbNationalNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.tbLastName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbSecondName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCharactersCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PhoneNumberErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.NationalNumberErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbMainBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneNumberErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalNumberErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMainBox
            // 
            this.gbMainBox.BackColor = System.Drawing.Color.AliceBlue;
            this.gbMainBox.BorderColor = System.Drawing.Color.SlateGray;
            this.gbMainBox.BorderRadius = 3;
            this.gbMainBox.BorderThickness = 5;
            this.gbMainBox.Controls.Add(this.cbDay);
            this.gbMainBox.Controls.Add(this.cbMonth);
            this.gbMainBox.Controls.Add(this.cbYear);
            this.gbMainBox.Controls.Add(this.label10);
            this.gbMainBox.Controls.Add(this.label13);
            this.gbMainBox.Controls.Add(this.label12);
            this.gbMainBox.Controls.Add(this.label11);
            this.gbMainBox.Controls.Add(this.tbHealthProblems);
            this.gbMainBox.Controls.Add(this.label8);
            this.gbMainBox.Controls.Add(this.cbBloodType);
            this.gbMainBox.Controls.Add(this.cbGender);
            this.gbMainBox.Controls.Add(this.tbGeneralAllergies);
            this.gbMainBox.Controls.Add(this.tbPhoneNumber);
            this.gbMainBox.Controls.Add(this.tbNationalNo);
            this.gbMainBox.Controls.Add(this.label15);
            this.gbMainBox.Controls.Add(this.label6);
            this.gbMainBox.Controls.Add(this.btnCancel);
            this.gbMainBox.Controls.Add(this.btnSave);
            this.gbMainBox.Controls.Add(this.tbLastName);
            this.gbMainBox.Controls.Add(this.tbSecondName);
            this.gbMainBox.Controls.Add(this.label9);
            this.gbMainBox.Controls.Add(this.label14);
            this.gbMainBox.Controls.Add(this.label7);
            this.gbMainBox.Controls.Add(this.tbFirstName);
            this.gbMainBox.Controls.Add(this.label5);
            this.gbMainBox.Controls.Add(this.lblCharactersCount);
            this.gbMainBox.Controls.Add(this.label4);
            this.gbMainBox.Controls.Add(this.label3);
            this.gbMainBox.Controls.Add(this.label2);
            this.gbMainBox.Controls.Add(this.label1);
            this.gbMainBox.CustomBorderColor = System.Drawing.Color.SlateGray;
            this.gbMainBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMainBox.FillColor = System.Drawing.Color.AliceBlue;
            this.gbMainBox.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gbMainBox.ForeColor = System.Drawing.Color.White;
            this.gbMainBox.Location = new System.Drawing.Point(0, 0);
            this.gbMainBox.Name = "gbMainBox";
            this.gbMainBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbMainBox.Size = new System.Drawing.Size(1361, 850);
            this.gbMainBox.TabIndex = 0;
            this.gbMainBox.Text = "اضافة مريض";
            this.gbMainBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbDay
            // 
            this.cbDay.BackColor = System.Drawing.Color.Transparent;
            this.cbDay.BorderColor = System.Drawing.Color.SteelBlue;
            this.cbDay.BorderRadius = 4;
            this.cbDay.BorderThickness = 2;
            this.cbDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDay.DropDownHeight = 400;
            this.cbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDay.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDay.ForeColor = System.Drawing.Color.SteelBlue;
            this.cbDay.IntegralHeight = false;
            this.cbDay.ItemHeight = 50;
            this.cbDay.Items.AddRange(new object[] {
            "اليوم",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cbDay.Location = new System.Drawing.Point(13, 297);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(132, 56);
            this.cbDay.StartIndex = 0;
            this.cbDay.TabIndex = 8;
            this.cbDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbMonth
            // 
            this.cbMonth.BackColor = System.Drawing.Color.AliceBlue;
            this.cbMonth.BorderColor = System.Drawing.Color.SteelBlue;
            this.cbMonth.BorderRadius = 4;
            this.cbMonth.BorderThickness = 2;
            this.cbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMonth.DropDownHeight = 400;
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonth.ForeColor = System.Drawing.Color.SteelBlue;
            this.cbMonth.IntegralHeight = false;
            this.cbMonth.ItemHeight = 50;
            this.cbMonth.Items.AddRange(new object[] {
            "الشهر",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbMonth.Location = new System.Drawing.Point(157, 297);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(132, 56);
            this.cbMonth.StartIndex = 0;
            this.cbMonth.TabIndex = 7;
            this.cbMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbYear
            // 
            this.cbYear.BackColor = System.Drawing.Color.AliceBlue;
            this.cbYear.BorderColor = System.Drawing.Color.SteelBlue;
            this.cbYear.BorderRadius = 4;
            this.cbYear.BorderThickness = 2;
            this.cbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYear.DropDownHeight = 400;
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbYear.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYear.ForeColor = System.Drawing.Color.SteelBlue;
            this.cbYear.IntegralHeight = false;
            this.cbYear.ItemHeight = 50;
            this.cbYear.Items.AddRange(new object[] {
            "السنة"});
            this.cbYear.Location = new System.Drawing.Point(301, 297);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(153, 56);
            this.cbYear.StartIndex = 0;
            this.cbYear.TabIndex = 6;
            this.cbYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(749, 463);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 38);
            this.label10.TabIndex = 16;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(1252, 463);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 38);
            this.label13.TabIndex = 16;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(270, 78);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 38);
            this.label12.TabIndex = 16;
            this.label12.Text = "*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(1220, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 38);
            this.label11.TabIndex = 16;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbHealthProblems
            // 
            this.tbHealthProblems.BorderColor = System.Drawing.Color.Red;
            this.tbHealthProblems.BorderRadius = 16;
            this.tbHealthProblems.BorderThickness = 2;
            this.tbHealthProblems.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbHealthProblems.DefaultText = "";
            this.tbHealthProblems.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbHealthProblems.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbHealthProblems.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbHealthProblems.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbHealthProblems.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbHealthProblems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbHealthProblems.ForeColor = System.Drawing.Color.Black;
            this.tbHealthProblems.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbHealthProblems.Location = new System.Drawing.Point(496, 297);
            this.tbHealthProblems.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbHealthProblems.MaxLength = 45;
            this.tbHealthProblems.Name = "tbHealthProblems";
            this.tbHealthProblems.PlaceholderText = "المشاكل الصحية";
            this.tbHealthProblems.SelectedText = "";
            this.tbHealthProblems.Size = new System.Drawing.Size(378, 84);
            this.tbHealthProblems.TabIndex = 5;
            this.tbHealthProblems.TextChanged += new System.EventHandler(this.tbHealthProblems_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(739, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 38);
            this.label8.TabIndex = 12;
            this.label8.Text = "المـشاكل الصحية";
            // 
            // cbBloodType
            // 
            this.cbBloodType.BackColor = System.Drawing.Color.Transparent;
            this.cbBloodType.BorderColor = System.Drawing.Color.SteelBlue;
            this.cbBloodType.BorderRadius = 16;
            this.cbBloodType.BorderThickness = 3;
            this.cbBloodType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBloodType.DropDownHeight = 200;
            this.cbBloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBloodType.FillColor = System.Drawing.Color.AliceBlue;
            this.cbBloodType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbBloodType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbBloodType.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.cbBloodType.ForeColor = System.Drawing.Color.Black;
            this.cbBloodType.IntegralHeight = false;
            this.cbBloodType.ItemHeight = 76;
            this.cbBloodType.Location = new System.Drawing.Point(32, 502);
            this.cbBloodType.MaxDropDownItems = 3;
            this.cbBloodType.Name = "cbBloodType";
            this.cbBloodType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbBloodType.Size = new System.Drawing.Size(378, 82);
            this.cbBloodType.TabIndex = 11;
            this.cbBloodType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbGender
            // 
            this.cbGender.BackColor = System.Drawing.Color.Transparent;
            this.cbGender.BorderColor = System.Drawing.Color.SteelBlue;
            this.cbGender.BorderRadius = 16;
            this.cbGender.BorderThickness = 3;
            this.cbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FillColor = System.Drawing.Color.AliceBlue;
            this.cbGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGender.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.cbGender.ForeColor = System.Drawing.Color.Black;
            this.cbGender.ItemHeight = 76;
            this.cbGender.Items.AddRange(new object[] {
            "حدد الجنس",
            "ذكر",
            "انثى"});
            this.cbGender.Location = new System.Drawing.Point(970, 504);
            this.cbGender.Name = "cbGender";
            this.cbGender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbGender.Size = new System.Drawing.Size(378, 82);
            this.cbGender.StartIndex = 0;
            this.cbGender.TabIndex = 9;
            this.cbGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbGeneralAllergies
            // 
            this.tbGeneralAllergies.BorderColor = System.Drawing.Color.Red;
            this.tbGeneralAllergies.BorderRadius = 16;
            this.tbGeneralAllergies.BorderThickness = 2;
            this.tbGeneralAllergies.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbGeneralAllergies.DefaultText = "";
            this.tbGeneralAllergies.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbGeneralAllergies.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbGeneralAllergies.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbGeneralAllergies.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbGeneralAllergies.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbGeneralAllergies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbGeneralAllergies.ForeColor = System.Drawing.Color.Black;
            this.tbGeneralAllergies.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbGeneralAllergies.Location = new System.Drawing.Point(13, 623);
            this.tbGeneralAllergies.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbGeneralAllergies.Name = "tbGeneralAllergies";
            this.tbGeneralAllergies.PlaceholderText = "هل المريض يعاني من حساسية ؟";
            this.tbGeneralAllergies.SelectedText = "";
            this.tbGeneralAllergies.Size = new System.Drawing.Size(1071, 84);
            this.tbGeneralAllergies.TabIndex = 12;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.BorderColor = System.Drawing.Color.SteelBlue;
            this.tbPhoneNumber.BorderRadius = 16;
            this.tbPhoneNumber.BorderThickness = 2;
            this.tbPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPhoneNumber.DefaultText = "";
            this.tbPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPhoneNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPhoneNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbPhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.tbPhoneNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPhoneNumber.Location = new System.Drawing.Point(496, 502);
            this.tbPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbPhoneNumber.MaxLength = 10;
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.PlaceholderText = "ادخل رقم الهاتف";
            this.tbPhoneNumber.SelectedText = "";
            this.tbPhoneNumber.Size = new System.Drawing.Size(378, 84);
            this.tbPhoneNumber.TabIndex = 10;
            this.tbPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPhoneNumber_KeyPress);
            this.tbPhoneNumber.Leave += new System.EventHandler(this.tbPhoneNumber_Leave);
            // 
            // tbNationalNo
            // 
            this.tbNationalNo.BorderColor = System.Drawing.Color.SteelBlue;
            this.tbNationalNo.BorderRadius = 16;
            this.tbNationalNo.BorderThickness = 2;
            this.tbNationalNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNationalNo.DefaultText = "";
            this.tbNationalNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNationalNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNationalNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNationalNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNationalNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNationalNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbNationalNo.ForeColor = System.Drawing.Color.Black;
            this.tbNationalNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNationalNo.Location = new System.Drawing.Point(970, 297);
            this.tbNationalNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.PlaceholderText = "رقم الهوية";
            this.tbNationalNo.SelectedText = "";
            this.tbNationalNo.Size = new System.Drawing.Size(378, 84);
            this.tbNationalNo.TabIndex = 4;
            this.tbNationalNo.Leave += new System.EventHandler(this.tbNationalNo_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(335, 248);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 38);
            this.label15.TabIndex = 3;
            this.label15.Text = "تاريخ المـيلاد";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(1252, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 38);
            this.label6.TabIndex = 3;
            this.label6.Text = "رقم الهوية";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Location = new System.Drawing.Point(749, 747);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(315, 62);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "إلغـاء";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(384, 747);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(315, 62);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "حفـظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbLastName
            // 
            this.tbLastName.BorderColor = System.Drawing.Color.SteelBlue;
            this.tbLastName.BorderRadius = 16;
            this.tbLastName.BorderThickness = 2;
            this.tbLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbLastName.DefaultText = "";
            this.tbLastName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbLastName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbLastName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbLastName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbLastName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbLastName.ForeColor = System.Drawing.Color.Black;
            this.tbLastName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbLastName.Location = new System.Drawing.Point(32, 127);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.PlaceholderText = "إسم العائلة";
            this.tbLastName.SelectedText = "";
            this.tbLastName.Size = new System.Drawing.Size(378, 84);
            this.tbLastName.TabIndex = 3;
            this.tbLastName.Leave += new System.EventHandler(this.FullNameCheck);
            // 
            // tbSecondName
            // 
            this.tbSecondName.BorderColor = System.Drawing.Color.SteelBlue;
            this.tbSecondName.BorderRadius = 16;
            this.tbSecondName.BorderThickness = 2;
            this.tbSecondName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSecondName.DefaultText = "";
            this.tbSecondName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSecondName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSecondName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSecondName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSecondName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSecondName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbSecondName.ForeColor = System.Drawing.Color.Black;
            this.tbSecondName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSecondName.Location = new System.Drawing.Point(496, 127);
            this.tbSecondName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.PlaceholderText = "إسم الاب";
            this.tbSecondName.SelectedText = "";
            this.tbSecondName.Size = new System.Drawing.Size(378, 84);
            this.tbSecondName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(770, 463);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 38);
            this.label9.TabIndex = 0;
            this.label9.Text = "رقم الهاتف";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(1091, 645);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(229, 38);
            this.label14.TabIndex = 0;
            this.label14.Text = "حساسية المريـض يعاني منها:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(321, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 38);
            this.label7.TabIndex = 0;
            this.label7.Text = "فصيلة الـدم";
            // 
            // tbFirstName
            // 
            this.tbFirstName.BorderColor = System.Drawing.Color.SteelBlue;
            this.tbFirstName.BorderRadius = 16;
            this.tbFirstName.BorderThickness = 2;
            this.tbFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFirstName.DefaultText = "";
            this.tbFirstName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFirstName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFirstName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFirstName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFirstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbFirstName.ForeColor = System.Drawing.Color.Black;
            this.tbFirstName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFirstName.Location = new System.Drawing.Point(970, 127);
            this.tbFirstName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.PlaceholderText = "اسم المريض";
            this.tbFirstName.SelectedText = "";
            this.tbFirstName.Size = new System.Drawing.Size(378, 84);
            this.tbFirstName.TabIndex = 1;
            this.tbFirstName.Leave += new System.EventHandler(this.FullNameCheck);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(1275, 463);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "الجنس";
            // 
            // lblCharactersCount
            // 
            this.lblCharactersCount.AutoSize = true;
            this.lblCharactersCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCharactersCount.Font = new System.Drawing.Font("Simplified Arabic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCharactersCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblCharactersCount.Location = new System.Drawing.Point(731, 387);
            this.lblCharactersCount.Name = "lblCharactersCount";
            this.lblCharactersCount.Size = new System.Drawing.Size(35, 28);
            this.lblCharactersCount.TabIndex = 0;
            this.lblCharactersCount.Text = "0/0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Simplified Arabic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(790, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "عدد الأحرف: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(302, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 38);
            this.label3.TabIndex = 0;
            this.label3.Text = "اسم العائلة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(784, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "اسم الأب";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(1252, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم الأول";
            // 
            // PhoneNumberErrorProvider
            // 
            this.PhoneNumberErrorProvider.ContainerControl = this;
            // 
            // NationalNumberErrorProvider
            // 
            this.NationalNumberErrorProvider.ContainerControl = this;
            this.NationalNumberErrorProvider.RightToLeft = true;
            // 
            // frmAddOrEditePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1361, 850);
            this.Controls.Add(this.gbMainBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddOrEditePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOrEditePatient";
            this.Load += new System.EventHandler(this.frmAddOrEditePatient_Load);
            this.gbMainBox.ResumeLayout(false);
            this.gbMainBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneNumberErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalNumberErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbMainBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbLastName;
        private Guna.UI2.WinForms.Guna2TextBox tbSecondName;
        private Guna.UI2.WinForms.Guna2TextBox tbFirstName;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private Guna.UI2.WinForms.Guna2TextBox tbNationalNo;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cbBloodType;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox tbHealthProblems;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox tbPhoneNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCharactersCount;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox tbGeneralAllergies;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2ComboBox cbDay;
        private Guna.UI2.WinForms.Guna2ComboBox cbMonth;
        private Guna.UI2.WinForms.Guna2ComboBox cbYear;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider PhoneNumberErrorProvider;
        private System.Windows.Forms.ErrorProvider NationalNumberErrorProvider;
    }
}