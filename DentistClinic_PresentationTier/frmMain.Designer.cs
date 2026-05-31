namespace DentistClinic_PresentationTier
{
    partial class frmMain
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
            this.dgvBloodTypes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloodTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBloodTypes
            // 
            this.dgvBloodTypes.AllowUserToAddRows = false;
            this.dgvBloodTypes.AllowUserToDeleteRows = false;
            this.dgvBloodTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBloodTypes.Location = new System.Drawing.Point(82, 12);
            this.dgvBloodTypes.Name = "dgvBloodTypes";
            this.dgvBloodTypes.ReadOnly = true;
            this.dgvBloodTypes.RowHeadersWidth = 62;
            this.dgvBloodTypes.RowTemplate.Height = 28;
            this.dgvBloodTypes.Size = new System.Drawing.Size(992, 523);
            this.dgvBloodTypes.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 645);
            this.Controls.Add(this.dgvBloodTypes);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloodTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBloodTypes;
    }
}