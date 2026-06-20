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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbMainBox = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnAddPhoneNumber = new Guna.UI2.WinForms.Guna2Button();
            this.dgvPhoneNumbers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIsPrimary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tbHealthProblems = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbBloodType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbNationalNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.tbLastName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbSecondName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.chbIsNumberPrimary = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gbMainBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMainBox
            // 
            this.gbMainBox.BackColor = System.Drawing.SystemColors.Control;
            this.gbMainBox.BorderColor = System.Drawing.Color.SlateGray;
            this.gbMainBox.BorderRadius = 10;
            this.gbMainBox.BorderThickness = 5;
            this.gbMainBox.Controls.Add(this.label14);
            this.gbMainBox.Controls.Add(this.label13);
            this.gbMainBox.Controls.Add(this.label12);
            this.gbMainBox.Controls.Add(this.label11);
            this.gbMainBox.Controls.Add(this.chbIsNumberPrimary);
            this.gbMainBox.Controls.Add(this.btnAddPhoneNumber);
            this.gbMainBox.Controls.Add(this.dgvPhoneNumbers);
            this.gbMainBox.Controls.Add(this.tbHealthProblems);
            this.gbMainBox.Controls.Add(this.label8);
            this.gbMainBox.Controls.Add(this.dtpDateOfBirth);
            this.gbMainBox.Controls.Add(this.cbBloodType);
            this.gbMainBox.Controls.Add(this.cbGender);
            this.gbMainBox.Controls.Add(this.tbPhoneNumber);
            this.gbMainBox.Controls.Add(this.tbNationalNo);
            this.gbMainBox.Controls.Add(this.label6);
            this.gbMainBox.Controls.Add(this.btnCancel);
            this.gbMainBox.Controls.Add(this.btnSave);
            this.gbMainBox.Controls.Add(this.tbLastName);
            this.gbMainBox.Controls.Add(this.tbSecondName);
            this.gbMainBox.Controls.Add(this.label10);
            this.gbMainBox.Controls.Add(this.label9);
            this.gbMainBox.Controls.Add(this.label7);
            this.gbMainBox.Controls.Add(this.tbFirstName);
            this.gbMainBox.Controls.Add(this.label5);
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
            // btnAddPhoneNumber
            // 
            this.btnAddPhoneNumber.BorderRadius = 12;
            this.btnAddPhoneNumber.CustomizableEdges.BottomRight = false;
            this.btnAddPhoneNumber.CustomizableEdges.TopRight = false;
            this.btnAddPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPhoneNumber.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPhoneNumber.Enabled = false;
            this.btnAddPhoneNumber.FillColor = System.Drawing.Color.SteelBlue;
            this.btnAddPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPhoneNumber.ForeColor = System.Drawing.Color.White;
            this.btnAddPhoneNumber.Image = global::DentistClinic_PresentationTier.Properties.Resources.Add;
            this.btnAddPhoneNumber.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddPhoneNumber.Location = new System.Drawing.Point(970, 604);
            this.btnAddPhoneNumber.Name = "btnAddPhoneNumber";
            this.btnAddPhoneNumber.Size = new System.Drawing.Size(99, 84);
            this.btnAddPhoneNumber.TabIndex = 10;
            this.btnAddPhoneNumber.Click += new System.EventHandler(this.btnAddPhoneNumber_Click);
            // 
            // dgvPhoneNumbers
            // 
            this.dgvPhoneNumbers.AllowUserToAddRows = false;
            this.dgvPhoneNumbers.AllowUserToDeleteRows = false;
            this.dgvPhoneNumbers.AllowUserToResizeColumns = false;
            this.dgvPhoneNumbers.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhoneNumbers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPhoneNumbers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhoneNumbers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPhoneNumbers.ColumnHeadersHeight = 52;
            this.dgvPhoneNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPhoneNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clIsPrimary,
            this.clDelete});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhoneNumbers.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPhoneNumbers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhoneNumbers.Location = new System.Drawing.Point(496, 455);
            this.dgvPhoneNumbers.MultiSelect = false;
            this.dgvPhoneNumbers.Name = "dgvPhoneNumbers";
            this.dgvPhoneNumbers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhoneNumbers.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPhoneNumbers.RowHeadersVisible = false;
            this.dgvPhoneNumbers.RowHeadersWidth = 62;
            this.dgvPhoneNumbers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPhoneNumbers.RowTemplate.Height = 36;
            this.dgvPhoneNumbers.Size = new System.Drawing.Size(378, 233);
            this.dgvPhoneNumbers.TabIndex = 14;
            this.dgvPhoneNumbers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhoneNumbers.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhoneNumbers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvPhoneNumbers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhoneNumbers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhoneNumbers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhoneNumbers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhoneNumbers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            this.dgvPhoneNumbers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPhoneNumbers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvPhoneNumbers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhoneNumbers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPhoneNumbers.ThemeStyle.HeaderStyle.Height = 52;
            this.dgvPhoneNumbers.ThemeStyle.ReadOnly = false;
            this.dgvPhoneNumbers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhoneNumbers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhoneNumbers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvPhoneNumbers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhoneNumbers.ThemeStyle.RowsStyle.Height = 36;
            this.dgvPhoneNumbers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhoneNumbers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhoneNumbers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhoneNumbers_CellContentClick);
            // 
            // clNumber
            // 
            this.clNumber.HeaderText = "رقم الهاتف";
            this.clNumber.MinimumWidth = 8;
            this.clNumber.Name = "clNumber";
            this.clNumber.ReadOnly = true;
            // 
            // clIsPrimary
            // 
            this.clIsPrimary.HeaderText = "الرقم الرئيسي";
            this.clIsPrimary.MinimumWidth = 8;
            this.clIsPrimary.Name = "clIsPrimary";
            this.clIsPrimary.ReadOnly = true;
            // 
            // clDelete
            // 
            this.clDelete.HeaderText = "حذف";
            this.clDelete.MinimumWidth = 8;
            this.clDelete.Name = "clDelete";
            this.clDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDelete.Text = "حذف";
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
            this.tbHealthProblems.Name = "tbHealthProblems";
            this.tbHealthProblems.PlaceholderText = "المشاكل الصحية";
            this.tbHealthProblems.SelectedText = "";
            this.tbHealthProblems.Size = new System.Drawing.Size(378, 84);
            this.tbHealthProblems.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(746, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 38);
            this.label8.TabIndex = 12;
            this.label8.Text = "المـشاكل الصحية";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.BackColor = System.Drawing.Color.Transparent;
            this.dtpDateOfBirth.BorderColor = System.Drawing.Color.SteelBlue;
            this.dtpDateOfBirth.BorderRadius = 16;
            this.dtpDateOfBirth.BorderThickness = 2;
            this.dtpDateOfBirth.Checked = true;
            this.dtpDateOfBirth.FillColor = System.Drawing.Color.SteelBlue;
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dtpDateOfBirth.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(13, 297);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(378, 84);
            this.dtpDateOfBirth.TabIndex = 6;
            this.dtpDateOfBirth.Value = new System.DateTime(2026, 6, 20, 0, 0, 0, 0);
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
            this.cbBloodType.Location = new System.Drawing.Point(13, 455);
            this.cbBloodType.MaxDropDownItems = 3;
            this.cbBloodType.Name = "cbBloodType";
            this.cbBloodType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbBloodType.Size = new System.Drawing.Size(378, 82);
            this.cbBloodType.TabIndex = 8;
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
            this.cbGender.Location = new System.Drawing.Point(970, 455);
            this.cbGender.Name = "cbGender";
            this.cbGender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbGender.Size = new System.Drawing.Size(378, 82);
            this.cbGender.StartIndex = 0;
            this.cbGender.TabIndex = 7;
            this.cbGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.BorderColor = System.Drawing.Color.SteelBlue;
            this.tbPhoneNumber.BorderRadius = 16;
            this.tbPhoneNumber.BorderThickness = 2;
            this.tbPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPhoneNumber.CustomizableEdges.BottomLeft = false;
            this.tbPhoneNumber.CustomizableEdges.TopLeft = false;
            this.tbPhoneNumber.DefaultText = "";
            this.tbPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPhoneNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPhoneNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbPhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.tbPhoneNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPhoneNumber.Location = new System.Drawing.Point(1070, 604);
            this.tbPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.PlaceholderText = "ادخل رقم الهاتف";
            this.tbPhoneNumber.SelectedText = "";
            this.tbPhoneNumber.Size = new System.Drawing.Size(278, 84);
            this.tbPhoneNumber.TabIndex = 9;
            this.tbPhoneNumber.TextChanged += new System.EventHandler(this.tbPhoneNumber_TextChanged);
            this.tbPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPhoneNumber_KeyPress);
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
            this.btnCancel.Location = new System.Drawing.Point(699, 746);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(315, 62);
            this.btnCancel.TabIndex = 11;
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
            this.btnSave.Location = new System.Drawing.Point(334, 746);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(315, 62);
            this.btnSave.TabIndex = 12;
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
            this.tbLastName.Location = new System.Drawing.Point(13, 127);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.PlaceholderText = "إسم العائلة";
            this.tbLastName.SelectedText = "";
            this.tbLastName.Size = new System.Drawing.Size(378, 84);
            this.tbLastName.TabIndex = 3;
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
            this.label9.Location = new System.Drawing.Point(1254, 560);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 38);
            this.label9.TabIndex = 0;
            this.label9.Text = "رقم الهاتف";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(302, 414);
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
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(1281, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "الجنس";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(276, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 38);
            this.label4.TabIndex = 0;
            this.label4.Text = "تاريخ الميلاد";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(283, 78);
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
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 16;
            this.guna2Elipse2.TargetControl = this.dgvPhoneNumbers;
            // 
            // chbIsNumberPrimary
            // 
            this.chbIsNumberPrimary.CheckedState.BorderColor = System.Drawing.Color.White;
            this.chbIsNumberPrimary.CheckedState.BorderRadius = 2;
            this.chbIsNumberPrimary.CheckedState.BorderThickness = 0;
            this.chbIsNumberPrimary.CheckedState.FillColor = System.Drawing.Color.SteelBlue;
            this.chbIsNumberPrimary.Location = new System.Drawing.Point(1310, 697);
            this.chbIsNumberPrimary.Name = "chbIsNumberPrimary";
            this.chbIsNumberPrimary.Size = new System.Drawing.Size(31, 38);
            this.chbIsNumberPrimary.TabIndex = 15;
            this.chbIsNumberPrimary.Text = "guna2CustomCheckBox1";
            this.chbIsNumberPrimary.UncheckedState.BorderColor = System.Drawing.Color.Red;
            this.chbIsNumberPrimary.UncheckedState.BorderRadius = 2;
            this.chbIsNumberPrimary.UncheckedState.BorderThickness = 2;
            this.chbIsNumberPrimary.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(1168, 697);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 38);
            this.label10.TabIndex = 0;
            this.label10.Text = "هل الرقم رئيسي؟";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(251, 78);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 38);
            this.label12.TabIndex = 16;
            this.label12.Text = "*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(1252, 414);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 38);
            this.label13.TabIndex = 16;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(1222, 560);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 38);
            this.label14.TabIndex = 16;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddOrEditePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 850);
            this.Controls.Add(this.gbMainBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddOrEditePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOrEditePatient";
            this.Load += new System.EventHandler(this.frmAddOrEditePatient_Load);
            this.gbMainBox.ResumeLayout(false);
            this.gbMainBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneNumbers)).EndInit();
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
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private Guna.UI2.WinForms.Guna2TextBox tbNationalNo;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateOfBirth;
        private Guna.UI2.WinForms.Guna2ComboBox cbBloodType;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox tbHealthProblems;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox tbPhoneNumber;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPhoneNumbers;
        private Guna.UI2.WinForms.Guna2Button btnAddPhoneNumber;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsPrimary;
        private System.Windows.Forms.DataGridViewButtonColumn clDelete;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chbIsNumberPrimary;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}