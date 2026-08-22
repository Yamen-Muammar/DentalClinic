using System.Web.UI;
using DentistClinic_PresentationTier.Controls.ModelsControls.PersonControls;
using Microsoft.Extensions.DependencyInjection;

namespace DentistClinic_PresentationTier.Controls.MainUIControls
{
    partial class ctrlManagePatients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2spnlHedder = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.dgvIndecatorPanel = new System.Windows.Forms.Panel();
            this.dgvProgressIndericator = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.dgvPatient = new Guna.UI2.WinForms.Guna2DataGridView();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.cbSearchFilters = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddPatient = new Guna.UI2.WinForms.Guna2Button();
            this.shourcutsPatientPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeletePatient = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowMedicalFile = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditePatient = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddNewAppointment = new Guna.UI2.WinForms.Guna2Button();
            this.MedicalAlertPanel = new System.Windows.Forms.Panel();
            this.shpMedicalAlert = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHealthProblem = new System.Windows.Forms.TextBox();
            this.ShortInfoPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPatientPhoneNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.headerQuickPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PatientShortcutsInformation = new System.Windows.Forms.Panel();
            this.guna2WinProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2spnlHedder.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.dataGridPanel.SuspendLayout();
            this.dgvIndecatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.actionPanel.SuspendLayout();
            this.shourcutsPatientPanel.SuspendLayout();
            this.btnsTableLayout.SuspendLayout();
            this.MedicalAlertPanel.SuspendLayout();
            this.shpMedicalAlert.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.ShortInfoPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.headerQuickPanel.SuspendLayout();
            this.PatientShortcutsInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.74172F));
            this.tableLayoutPanel1.Controls.Add(this.guna2spnlHedder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpContent, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2892, 1867);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // guna2spnlHedder
            // 
            this.guna2spnlHedder.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.guna2spnlHedder, 2);
            this.guna2spnlHedder.Controls.Add(this.tableLayoutPanel4);
            this.guna2spnlHedder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2spnlHedder.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2spnlHedder.Location = new System.Drawing.Point(0, 0);
            this.guna2spnlHedder.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.guna2spnlHedder.Name = "guna2spnlHedder";
            this.guna2spnlHedder.ShadowColor = System.Drawing.Color.Black;
            this.guna2spnlHedder.ShadowDepth = 40;
            this.guna2spnlHedder.ShadowShift = 7;
            this.guna2spnlHedder.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2spnlHedder.Size = new System.Drawing.Size(2892, 217);
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
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(2892, 217);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblPageTitle);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1450, 4);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1438, 209);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(1078, 0);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(356, 73);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "إدارة المرضـى";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tlpContent
            // 
            this.tlpContent.BackColor = System.Drawing.Color.AliceBlue;
            this.tlpContent.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tlpContent, 2);
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.32051F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.6795F));
            this.tlpContent.Controls.Add(this.dataGridPanel, 1, 1);
            this.tlpContent.Controls.Add(this.actionPanel, 0, 0);
            this.tlpContent.Controls.Add(this.shourcutsPatientPanel, 0, 1);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(4, 246);
            this.tlpContent.Margin = new System.Windows.Forms.Padding(4);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 2;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tlpContent.Size = new System.Drawing.Size(2884, 1617);
            this.tlpContent.TabIndex = 7;
            // 
            // dataGridPanel
            // 
            this.dataGridPanel.BackColor = System.Drawing.Color.Transparent;
            this.dataGridPanel.Controls.Add(this.dgvIndecatorPanel);
            this.dataGridPanel.Controls.Add(this.dgvPatient);
            this.dataGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPanel.FillColor = System.Drawing.Color.White;
            this.dataGridPanel.Location = new System.Drawing.Point(907, 214);
            this.dataGridPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridPanel.Name = "dataGridPanel";
            this.dataGridPanel.Padding = new System.Windows.Forms.Padding(24, 23, 24, 23);
            this.dataGridPanel.Radius = 1;
            this.dataGridPanel.ShadowColor = System.Drawing.Color.Black;
            this.dataGridPanel.ShadowShift = 10;
            this.dataGridPanel.Size = new System.Drawing.Size(1973, 1399);
            this.dataGridPanel.TabIndex = 0;
            // 
            // dgvIndecatorPanel
            // 
            this.dgvIndecatorPanel.BackColor = System.Drawing.Color.White;
            this.dgvIndecatorPanel.Controls.Add(this.dgvProgressIndericator);
            this.dgvIndecatorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIndecatorPanel.Location = new System.Drawing.Point(24, 23);
            this.dgvIndecatorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dgvIndecatorPanel.Name = "dgvIndecatorPanel";
            this.dgvIndecatorPanel.Padding = new System.Windows.Forms.Padding(873, 521, 545, 521);
            this.dgvIndecatorPanel.Size = new System.Drawing.Size(1925, 1353);
            this.dgvIndecatorPanel.TabIndex = 1;
            // 
            // dgvProgressIndericator
            // 
            this.dgvProgressIndericator.AnimationSpeed = 90;
            this.dgvProgressIndericator.AutoStart = true;
            this.dgvProgressIndericator.BackColor = System.Drawing.Color.Transparent;
            this.dgvProgressIndericator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProgressIndericator.Location = new System.Drawing.Point(873, 521);
            this.dgvProgressIndericator.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProgressIndericator.Name = "dgvProgressIndericator";
            this.dgvProgressIndericator.NumberOfCircles = 13;
            this.dgvProgressIndericator.ProgressColor = System.Drawing.Color.SteelBlue;
            this.dgvProgressIndericator.Size = new System.Drawing.Size(507, 311);
            this.dgvProgressIndericator.TabIndex = 0;
            this.dgvProgressIndericator.UseTransparentBackground = true;
            // 
            // dgvPatient
            // 
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AllowUserToDeleteRows = false;
            this.dgvPatient.AllowUserToResizeColumns = false;
            this.dgvPatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvPatient.ColumnHeadersHeight = 77;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatient.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPatient.Location = new System.Drawing.Point(24, 23);
            this.dgvPatient.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPatient.MultiSelect = false;
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            this.dgvPatient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPatient.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvPatient.RowHeadersVisible = false;
            this.dgvPatient.RowHeadersWidth = 62;
            this.dgvPatient.RowTemplate.Height = 61;
            this.dgvPatient.Size = new System.Drawing.Size(1925, 1353);
            this.dgvPatient.TabIndex = 0;
            this.dgvPatient.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPatient.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPatient.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvPatient.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPatient.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPatient.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPatient.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPatient.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            this.dgvPatient.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPatient.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPatient.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPatient.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPatient.ThemeStyle.HeaderStyle.Height = 77;
            this.dgvPatient.ThemeStyle.ReadOnly = true;
            this.dgvPatient.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPatient.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPatient.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPatient.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPatient.ThemeStyle.RowsStyle.Height = 61;
            this.dgvPatient.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPatient.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPatient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellClick);
            // 
            // actionPanel
            // 
            this.actionPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.tlpContent.SetColumnSpan(this.actionPanel, 2);
            this.actionPanel.Controls.Add(this.cbSearchFilters);
            this.actionPanel.Controls.Add(this.tbSearchBox);
            this.actionPanel.Controls.Add(this.btnAddPatient);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionPanel.Location = new System.Drawing.Point(4, 4);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Padding = new System.Windows.Forms.Padding(10, 50, 10, 50);
            this.actionPanel.Size = new System.Drawing.Size(2876, 202);
            this.actionPanel.TabIndex = 2;
            // 
            // cbSearchFilters
            // 
            this.cbSearchFilters.BackColor = System.Drawing.Color.Transparent;
            this.cbSearchFilters.BorderRadius = 10;
            this.cbSearchFilters.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbSearchFilters.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSearchFilters.DropDownHeight = 200;
            this.cbSearchFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchFilters.FillColor = System.Drawing.Color.SteelBlue;
            this.cbSearchFilters.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSearchFilters.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSearchFilters.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSearchFilters.ForeColor = System.Drawing.Color.White;
            this.cbSearchFilters.IntegralHeight = false;
            this.cbSearchFilters.ItemHeight = 60;
            this.cbSearchFilters.Items.AddRange(new object[] {
            "الإسم",
            "رقم الهاتف"});
            this.cbSearchFilters.Location = new System.Drawing.Point(1897, 50);
            this.cbSearchFilters.Margin = new System.Windows.Forms.Padding(4);
            this.cbSearchFilters.MaxDropDownItems = 3;
            this.cbSearchFilters.Name = "cbSearchFilters";
            this.cbSearchFilters.Size = new System.Drawing.Size(401, 66);
            this.cbSearchFilters.StartIndex = 0;
            this.cbSearchFilters.TabIndex = 2;
            this.cbSearchFilters.SelectedIndexChanged += new System.EventHandler(this.cbSearchFilters_SelectedIndexChanged);
            // 
            // tbSearchBox
            // 
            this.tbSearchBox.BorderColor = System.Drawing.Color.SteelBlue;
            this.tbSearchBox.BorderRadius = 15;
            this.tbSearchBox.BorderThickness = 4;
            this.tbSearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearchBox.DefaultText = "";
            this.tbSearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbSearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchBox.ForeColor = System.Drawing.Color.Black;
            this.tbSearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchBox.Location = new System.Drawing.Point(2298, 50);
            this.tbSearchBox.Margin = new System.Windows.Forms.Padding(10, 7, 5, 7);
            this.tbSearchBox.Name = "tbSearchBox";
            this.tbSearchBox.PlaceholderForeColor = System.Drawing.Color.SteelBlue;
            this.tbSearchBox.PlaceholderText = "بحث";
            this.tbSearchBox.SelectedText = "";
            this.tbSearchBox.Size = new System.Drawing.Size(568, 102);
            this.tbSearchBox.TabIndex = 1;
            this.tbSearchBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSearchBox.TextChanged += new System.EventHandler(this.tbSearchBox_TextChanged);
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.BorderRadius = 10;
            this.btnAddPatient.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPatient.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPatient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPatient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPatient.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddPatient.FillColor = System.Drawing.Color.SteelBlue;
            this.btnAddPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddPatient.ForeColor = System.Drawing.Color.White;
            this.btnAddPatient.Image = global::DentistClinic_PresentationTier.Properties.Resources.Add;
            this.btnAddPatient.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddPatient.Location = new System.Drawing.Point(10, 50);
            this.btnAddPatient.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(876, 102);
            this.btnAddPatient.TabIndex = 0;
            this.btnAddPatient.Text = "اضافة مريـض جديد";
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // shourcutsPatientPanel
            // 
            this.shourcutsPatientPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.shourcutsPatientPanel.BorderColor = System.Drawing.Color.SteelBlue;
            this.shourcutsPatientPanel.BorderRadius = 20;
            this.shourcutsPatientPanel.BorderThickness = 3;
            this.shourcutsPatientPanel.Controls.Add(this.btnsTableLayout);
            this.shourcutsPatientPanel.Controls.Add(this.MedicalAlertPanel);
            this.shourcutsPatientPanel.Controls.Add(this.ShortInfoPanel);
            this.shourcutsPatientPanel.Controls.Add(this.headerQuickPanel);
            this.shourcutsPatientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shourcutsPatientPanel.FillColor = System.Drawing.Color.White;
            this.shourcutsPatientPanel.FillColor2 = System.Drawing.Color.White;
            this.shourcutsPatientPanel.Location = new System.Drawing.Point(13, 222);
            this.shourcutsPatientPanel.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.shourcutsPatientPanel.Name = "shourcutsPatientPanel";
            this.shourcutsPatientPanel.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.shourcutsPatientPanel.Size = new System.Drawing.Size(877, 1383);
            this.shourcutsPatientPanel.TabIndex = 3;
            this.shourcutsPatientPanel.Visible = false;
            // 
            // btnsTableLayout
            // 
            this.btnsTableLayout.BackColor = System.Drawing.Color.White;
            this.btnsTableLayout.ColumnCount = 1;
            this.btnsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.btnsTableLayout.Controls.Add(this.btnDeletePatient, 0, 3);
            this.btnsTableLayout.Controls.Add(this.btnShowMedicalFile, 0, 2);
            this.btnsTableLayout.Controls.Add(this.btnEditePatient, 0, 1);
            this.btnsTableLayout.Controls.Add(this.btnAddNewAppointment, 0, 0);
            this.btnsTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnsTableLayout.Location = new System.Drawing.Point(2, 588);
            this.btnsTableLayout.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnsTableLayout.Name = "btnsTableLayout";
            this.btnsTableLayout.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnsTableLayout.RowCount = 4;
            this.btnsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.btnsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.btnsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.btnsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.btnsTableLayout.Size = new System.Drawing.Size(873, 404);
            this.btnsTableLayout.TabIndex = 5;
            // 
            // btnDeletePatient
            // 
            this.btnDeletePatient.BorderRadius = 10;
            this.btnDeletePatient.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeletePatient.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeletePatient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeletePatient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeletePatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeletePatient.FillColor = System.Drawing.Color.Red;
            this.btnDeletePatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeletePatient.ForeColor = System.Drawing.Color.White;
            this.btnDeletePatient.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeletePatient.Image = global::DentistClinic_PresentationTier.Properties.Resources.Delete;
            this.btnDeletePatient.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDeletePatient.Location = new System.Drawing.Point(19, 309);
            this.btnDeletePatient.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.btnDeletePatient.Name = "btnDeletePatient";
            this.btnDeletePatient.Size = new System.Drawing.Size(835, 91);
            this.btnDeletePatient.TabIndex = 0;
            this.btnDeletePatient.Text = "حذف المريض";
            this.btnDeletePatient.Click += new System.EventHandler(this.btnDeletePatient_Click);
            // 
            // btnShowMedicalFile
            // 
            this.btnShowMedicalFile.BorderRadius = 10;
            this.btnShowMedicalFile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowMedicalFile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowMedicalFile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowMedicalFile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowMedicalFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowMedicalFile.FillColor = System.Drawing.Color.SteelBlue;
            this.btnShowMedicalFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowMedicalFile.ForeColor = System.Drawing.Color.White;
            this.btnShowMedicalFile.Image = global::DentistClinic_PresentationTier.Properties.Resources.view;
            this.btnShowMedicalFile.ImageSize = new System.Drawing.Size(30, 30);
            this.btnShowMedicalFile.Location = new System.Drawing.Point(19, 214);
            this.btnShowMedicalFile.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.btnShowMedicalFile.Name = "btnShowMedicalFile";
            this.btnShowMedicalFile.Size = new System.Drawing.Size(835, 85);
            this.btnShowMedicalFile.TabIndex = 0;
            this.btnShowMedicalFile.Text = "عرض ملف المريض الصحـي";
            this.btnShowMedicalFile.Click += new System.EventHandler(this.btnViewMedicalFile_Click);
            // 
            // btnEditePatient
            // 
            this.btnEditePatient.BorderRadius = 10;
            this.btnEditePatient.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditePatient.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditePatient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditePatient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditePatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditePatient.FillColor = System.Drawing.Color.SteelBlue;
            this.btnEditePatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditePatient.ForeColor = System.Drawing.Color.White;
            this.btnEditePatient.Image = global::DentistClinic_PresentationTier.Properties.Resources.Edite;
            this.btnEditePatient.ImageSize = new System.Drawing.Size(30, 30);
            this.btnEditePatient.Location = new System.Drawing.Point(19, 113);
            this.btnEditePatient.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.btnEditePatient.Name = "btnEditePatient";
            this.btnEditePatient.Size = new System.Drawing.Size(835, 85);
            this.btnEditePatient.TabIndex = 0;
            this.btnEditePatient.Text = "تعديل بيانات المريض";
            this.btnEditePatient.Click += new System.EventHandler(this.btnEditePatient_Click);
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.BorderRadius = 10;
            this.btnAddNewAppointment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewAppointment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewAppointment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewAppointment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewAppointment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddNewAppointment.FillColor = System.Drawing.Color.SteelBlue;
            this.btnAddNewAppointment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNewAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAddNewAppointment.Image = global::DentistClinic_PresentationTier.Properties.Resources.Add;
            this.btnAddNewAppointment.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddNewAppointment.Location = new System.Drawing.Point(19, 12);
            this.btnAddNewAppointment.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(835, 85);
            this.btnAddNewAppointment.TabIndex = 0;
            this.btnAddNewAppointment.Text = "إضـافة موعد جديد للمريض";
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // MedicalAlertPanel
            // 
            this.MedicalAlertPanel.BackColor = System.Drawing.Color.White;
            this.MedicalAlertPanel.Controls.Add(this.shpMedicalAlert);
            this.MedicalAlertPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MedicalAlertPanel.Location = new System.Drawing.Point(2, 387);
            this.MedicalAlertPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MedicalAlertPanel.Name = "MedicalAlertPanel";
            this.MedicalAlertPanel.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.MedicalAlertPanel.Size = new System.Drawing.Size(873, 201);
            this.MedicalAlertPanel.TabIndex = 3;
            // 
            // shpMedicalAlert
            // 
            this.shpMedicalAlert.BackColor = System.Drawing.Color.Transparent;
            this.shpMedicalAlert.Controls.Add(this.tableLayoutPanel3);
            this.shpMedicalAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shpMedicalAlert.FillColor = System.Drawing.Color.LightCoral;
            this.shpMedicalAlert.ForeColor = System.Drawing.Color.Maroon;
            this.shpMedicalAlert.Location = new System.Drawing.Point(13, 12);
            this.shpMedicalAlert.Margin = new System.Windows.Forms.Padding(4);
            this.shpMedicalAlert.Name = "shpMedicalAlert";
            this.shpMedicalAlert.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.shpMedicalAlert.Radius = 10;
            this.shpMedicalAlert.ShadowColor = System.Drawing.Color.SteelBlue;
            this.shpMedicalAlert.ShadowShift = 10;
            this.shpMedicalAlert.Size = new System.Drawing.Size(847, 177);
            this.shpMedicalAlert.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblHealthProblem, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(15, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.46328F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.53672F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(812, 177);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(645, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(163, 41);
            this.label2.TabIndex = 0;
            this.label2.Text = "مشاكل صحية:";
            // 
            // lblHealthProblem
            // 
            this.lblHealthProblem.AcceptsReturn = true;
            this.lblHealthProblem.BackColor = System.Drawing.Color.LightCoral;
            this.lblHealthProblem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblHealthProblem.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHealthProblem.Font = new System.Drawing.Font("Simplified Arabic", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHealthProblem.ForeColor = System.Drawing.Color.Black;
            this.lblHealthProblem.Location = new System.Drawing.Point(25, 65);
            this.lblHealthProblem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 15);
            this.lblHealthProblem.Multiline = true;
            this.lblHealthProblem.Name = "lblHealthProblem";
            this.lblHealthProblem.ReadOnly = true;
            this.lblHealthProblem.Size = new System.Drawing.Size(783, 97);
            this.lblHealthProblem.TabIndex = 2;
            this.lblHealthProblem.Text = "؟؟؟";
            this.lblHealthProblem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ShortInfoPanel
            // 
            this.ShortInfoPanel.BackColor = System.Drawing.Color.White;
            this.ShortInfoPanel.Controls.Add(this.tableLayoutPanel2);
            this.ShortInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShortInfoPanel.Location = new System.Drawing.Point(2, 89);
            this.ShortInfoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ShortInfoPanel.Name = "ShortInfoPanel";
            this.ShortInfoPanel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.ShortInfoPanel.Size = new System.Drawing.Size(873, 298);
            this.ShortInfoPanel.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel2.Controls.Add(this.lblPatientName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNationalNo, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPatientPhoneNumber, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(833, 298);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblPatientName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.lblPatientName, 2);
            this.lblPatientName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatientName.Font = new System.Drawing.Font("Simplified Arabic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientName.Location = new System.Drawing.Point(4, 0);
            this.lblPatientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPatientName.Size = new System.Drawing.Size(825, 99);
            this.lblPatientName.TabIndex = 0;
            this.lblPatientName.Text = "???";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNationalNo.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNationalNo.Location = new System.Drawing.Point(568, 198);
            this.lblNationalNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNationalNo.Size = new System.Drawing.Size(77, 100);
            this.lblNationalNo.TabIndex = 0;
            this.lblNationalNo.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(684, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(145, 99);
            this.label4.TabIndex = 0;
            this.label4.Text = "رقم الهاتف:";
            // 
            // lblPatientPhoneNumber
            // 
            this.lblPatientPhoneNumber.AutoSize = true;
            this.lblPatientPhoneNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPatientPhoneNumber.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientPhoneNumber.Location = new System.Drawing.Point(568, 99);
            this.lblPatientPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPatientPhoneNumber.Name = "lblPatientPhoneNumber";
            this.lblPatientPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPatientPhoneNumber.Size = new System.Drawing.Size(77, 99);
            this.lblPatientPhoneNumber.TabIndex = 0;
            this.lblPatientPhoneNumber.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(692, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(137, 100);
            this.label5.TabIndex = 0;
            this.label5.Text = "رقم الهوية:";
            // 
            // headerQuickPanel
            // 
            this.headerQuickPanel.BorderRadius = 20;
            this.headerQuickPanel.Controls.Add(this.label1);
            this.headerQuickPanel.CustomizableEdges.BottomLeft = false;
            this.headerQuickPanel.CustomizableEdges.BottomRight = false;
            this.headerQuickPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerQuickPanel.FillColor = System.Drawing.Color.SteelBlue;
            this.headerQuickPanel.FillColor2 = System.Drawing.Color.SteelBlue;
            this.headerQuickPanel.Location = new System.Drawing.Point(2, 1);
            this.headerQuickPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerQuickPanel.Name = "headerQuickPanel";
            this.headerQuickPanel.Padding = new System.Windows.Forms.Padding(273, 0, 0, 0);
            this.headerQuickPanel.Size = new System.Drawing.Size(873, 88);
            this.headerQuickPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(273, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "اختصارات المريض";
            // 
            // PatientShortcutsInformation
            // 
            this.PatientShortcutsInformation.BackColor = System.Drawing.Color.Transparent;
            this.PatientShortcutsInformation.Controls.Add(this.guna2WinProgressIndicator1);
            this.PatientShortcutsInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientShortcutsInformation.Location = new System.Drawing.Point(1, 719);
            this.PatientShortcutsInformation.Name = "PatientShortcutsInformation";
            this.PatientShortcutsInformation.Size = new System.Drawing.Size(450, 12);
            this.PatientShortcutsInformation.TabIndex = 5;
            // 
            // guna2WinProgressIndicator1
            // 
            this.guna2WinProgressIndicator1.AnimationSpeed = 90;
            this.guna2WinProgressIndicator1.AutoStart = true;
            this.guna2WinProgressIndicator1.Location = new System.Drawing.Point(412, 253);
            this.guna2WinProgressIndicator1.Name = "guna2WinProgressIndicator1";
            this.guna2WinProgressIndicator1.NumberOfCircles = 13;
            this.guna2WinProgressIndicator1.Size = new System.Drawing.Size(185, 180);
            this.guna2WinProgressIndicator1.TabIndex = 0;
            // 
            // ctrlManagePatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlManagePatients";
            this.Size = new System.Drawing.Size(2892, 1867);
            this.Load += new System.EventHandler(this.ctrlManagePatients_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.guna2spnlHedder.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.dataGridPanel.ResumeLayout(false);
            this.dgvIndecatorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.actionPanel.ResumeLayout(false);
            this.shourcutsPatientPanel.ResumeLayout(false);
            this.btnsTableLayout.ResumeLayout(false);
            this.MedicalAlertPanel.ResumeLayout(false);
            this.shpMedicalAlert.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ShortInfoPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.headerQuickPanel.ResumeLayout(false);
            this.headerQuickPanel.PerformLayout();
            this.PatientShortcutsInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2spnlHedder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblPageTitle;
        private ctrlPersonInformation ctrlPersonInformation1;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private Guna.UI2.WinForms.Guna2ShadowPanel dataGridPanel;
        private System.Windows.Forms.Panel actionPanel;
        private Guna.UI2.WinForms.Guna2TextBox tbSearchBox;
        private Guna.UI2.WinForms.Guna2Button btnAddPatient;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPatient;
        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchFilters;
        private System.Windows.Forms.Panel dgvIndecatorPanel;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator dgvProgressIndericator;
        private System.Windows.Forms.Panel PatientShortcutsInformation;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator guna2WinProgressIndicator1;
        private Guna.UI2.WinForms.Guna2GradientPanel shourcutsPatientPanel;
        private Guna.UI2.WinForms.Guna2Button btnAddNewAppointment;
        private Guna.UI2.WinForms.Guna2Button btnEditePatient;
        private Guna.UI2.WinForms.Guna2Button btnDeletePatient;
        private System.Windows.Forms.Panel MedicalAlertPanel;
        private Guna.UI2.WinForms.Guna2ShadowPanel shpMedicalAlert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel ShortInfoPanel;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label lblPatientPhoneNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPatientName;
        private Guna.UI2.WinForms.Guna2GradientPanel headerQuickPanel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnShowMedicalFile;
        private System.Windows.Forms.TextBox lblHealthProblem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel btnsTableLayout;
    }
}
