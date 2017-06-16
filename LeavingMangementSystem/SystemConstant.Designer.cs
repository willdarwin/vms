namespace LeavingManagementSystem
{
    partial class SystemConstant
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
            this.SystemConstantDataGridView = new System.Windows.Forms.DataGridView();
            this.SystemConstantReturnButton = new System.Windows.Forms.Button();
            this.SystemConstantTitleLabel = new System.Windows.Forms.Label();
            this.SystemConstantDateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.SystemConstantDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SystemConstantDataGridView
            // 
            this.SystemConstantDataGridView.AllowUserToAddRows = false;
            this.SystemConstantDataGridView.AllowUserToDeleteRows = false;
            this.SystemConstantDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemConstantDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SystemConstantDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SystemConstantDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.SystemConstantDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.SystemConstantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SystemConstantDataGridView.Location = new System.Drawing.Point(28, 56);
            this.SystemConstantDataGridView.MultiSelect = false;
            this.SystemConstantDataGridView.Name = "SystemConstantDataGridView";
            this.SystemConstantDataGridView.RowHeadersVisible = false;
            this.SystemConstantDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SystemConstantDataGridView.Size = new System.Drawing.Size(516, 420);
            this.SystemConstantDataGridView.TabIndex = 2;
            this.SystemConstantDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SystemConstantDataGridView_CellContentClick);
            this.SystemConstantDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.SystemConstantDataGridView_CellValidating);
            // 
            // SystemConstantReturnButton
            // 
            this.SystemConstantReturnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemConstantReturnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SystemConstantReturnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemConstantReturnButton.ForeColor = System.Drawing.Color.Blue;
            this.SystemConstantReturnButton.Location = new System.Drawing.Point(440, 497);
            this.SystemConstantReturnButton.Name = "SystemConstantReturnButton";
            this.SystemConstantReturnButton.Size = new System.Drawing.Size(100, 37);
            this.SystemConstantReturnButton.TabIndex = 4;
            this.SystemConstantReturnButton.Text = "Return";
            this.SystemConstantReturnButton.UseVisualStyleBackColor = false;
            this.SystemConstantReturnButton.Visible = false;
            // 
            // SystemConstantTitleLabel
            // 
            this.SystemConstantTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SystemConstantTitleLabel.AutoSize = true;
            this.SystemConstantTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemConstantTitleLabel.ForeColor = System.Drawing.Color.DimGray;
            this.SystemConstantTitleLabel.Location = new System.Drawing.Point(125, 17);
            this.SystemConstantTitleLabel.Name = "SystemConstantTitleLabel";
            this.SystemConstantTitleLabel.Size = new System.Drawing.Size(285, 24);
            this.SystemConstantTitleLabel.TabIndex = 5;
            this.SystemConstantTitleLabel.Text = "SystemConstant      Management";
            // 
            // SystemConstantDateTimePicker
            // 
            this.SystemConstantDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SystemConstantDateTimePicker.CustomFormat = "MM-dd";
            this.SystemConstantDateTimePicker.Location = new System.Drawing.Point(262, 89);
            this.SystemConstantDateTimePicker.Name = "SystemConstantDateTimePicker";
            this.SystemConstantDateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.SystemConstantDateTimePicker.TabIndex = 6;
            // 
            // SystemConstant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 569);
            this.Controls.Add(this.SystemConstantDateTimePicker);
            this.Controls.Add(this.SystemConstantTitleLabel);
            this.Controls.Add(this.SystemConstantReturnButton);
            this.Controls.Add(this.SystemConstantDataGridView);
            this.Name = "SystemConstant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SystemConstant";
            this.Load += new System.EventHandler(this.SystemConstant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SystemConstantDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SystemConstantDataGridView;
        private System.Windows.Forms.Button SystemConstantReturnButton;
        private System.Windows.Forms.Label SystemConstantTitleLabel;
        private System.Windows.Forms.DateTimePicker SystemConstantDateTimePicker;
    }
}