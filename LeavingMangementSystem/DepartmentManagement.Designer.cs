namespace LeavingManagementSystem
{
    partial class DepartmentManagement
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
            this.DepartmentDataGridView = new System.Windows.Forms.DataGridView();
            this.DepartmentTitleLabel = new System.Windows.Forms.Label();
            this.DepartmentNameLabel = new System.Windows.Forms.Label();
            this.DepartmentManagerLabel = new System.Windows.Forms.Label();
            this.DepartmentNameTextBox = new System.Windows.Forms.TextBox();
            this.DepartmentManagerTextBox = new System.Windows.Forms.TextBox();
            this.AddNewDepartmentButton = new System.Windows.Forms.Button();
            this.SaveNewDepartmentButton = new System.Windows.Forms.Button();
            this.DepartmentReturnButton = new System.Windows.Forms.Button();
            this.DepartmentNameerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.DepartmentManagererrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.DescriptionLable = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.ParentDepartmentLable = new System.Windows.Forms.Label();
            this.ParentDepartmentcomboBox = new System.Windows.Forms.ComboBox();
            this.DescriptionerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentNameerrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentManagererrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionerrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DepartmentDataGridView
            // 
            this.DepartmentDataGridView.AllowUserToAddRows = false;
            this.DepartmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DepartmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DepartmentDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.DepartmentDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DepartmentDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DepartmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartmentDataGridView.Location = new System.Drawing.Point(28, 56);
            this.DepartmentDataGridView.MultiSelect = false;
            this.DepartmentDataGridView.Name = "DepartmentDataGridView";
            this.DepartmentDataGridView.RowHeadersVisible = false;
            this.DepartmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DepartmentDataGridView.Size = new System.Drawing.Size(749, 345);
            this.DepartmentDataGridView.TabIndex = 1;
            this.DepartmentDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DepartmentDataGridView_CellContentClick);
            // 
            // DepartmentTitleLabel
            // 
            this.DepartmentTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DepartmentTitleLabel.AutoSize = true;
            this.DepartmentTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentTitleLabel.ForeColor = System.Drawing.Color.DimGray;
            this.DepartmentTitleLabel.Location = new System.Drawing.Point(275, 17);
            this.DepartmentTitleLabel.Name = "DepartmentTitleLabel";
            this.DepartmentTitleLabel.Size = new System.Drawing.Size(248, 24);
            this.DepartmentTitleLabel.TabIndex = 4;
            this.DepartmentTitleLabel.Text = "Department      Management";
            // 
            // DepartmentNameLabel
            // 
            this.DepartmentNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DepartmentNameLabel.AutoSize = true;
            this.DepartmentNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.DepartmentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentNameLabel.Location = new System.Drawing.Point(57, 321);
            this.DepartmentNameLabel.Name = "DepartmentNameLabel";
            this.DepartmentNameLabel.Size = new System.Drawing.Size(165, 20);
            this.DepartmentNameLabel.TabIndex = 9;
            this.DepartmentNameLabel.Text = "Department Name :";
            this.DepartmentNameLabel.Visible = false;
            // 
            // DepartmentManagerLabel
            // 
            this.DepartmentManagerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DepartmentManagerLabel.AutoSize = true;
            this.DepartmentManagerLabel.BackColor = System.Drawing.SystemColors.Control;
            this.DepartmentManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentManagerLabel.Location = new System.Drawing.Point(33, 370);
            this.DepartmentManagerLabel.Name = "DepartmentManagerLabel";
            this.DepartmentManagerLabel.Size = new System.Drawing.Size(189, 20);
            this.DepartmentManagerLabel.TabIndex = 11;
            this.DepartmentManagerLabel.Text = "Department manager :";
            this.DepartmentManagerLabel.Visible = false;
            // 
            // DepartmentNameTextBox
            // 
            this.DepartmentNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DepartmentNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentNameTextBox.Location = new System.Drawing.Point(232, 319);
            this.DepartmentNameTextBox.Name = "DepartmentNameTextBox";
            this.DepartmentNameTextBox.Size = new System.Drawing.Size(150, 26);
            this.DepartmentNameTextBox.TabIndex = 12;
            this.DepartmentNameTextBox.Visible = false;
            // 
            // DepartmentManagerTextBox
            // 
            this.DepartmentManagerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DepartmentManagerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentManagerTextBox.Location = new System.Drawing.Point(232, 368);
            this.DepartmentManagerTextBox.Name = "DepartmentManagerTextBox";
            this.DepartmentManagerTextBox.Size = new System.Drawing.Size(150, 26);
            this.DepartmentManagerTextBox.TabIndex = 13;
            this.DepartmentManagerTextBox.Visible = false;
            // 
            // AddNewDepartmentButton
            // 
            this.AddNewDepartmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNewDepartmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AddNewDepartmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDepartmentButton.ForeColor = System.Drawing.Color.DarkMagenta;
            this.AddNewDepartmentButton.Location = new System.Drawing.Point(34, 434);
            this.AddNewDepartmentButton.Name = "AddNewDepartmentButton";
            this.AddNewDepartmentButton.Size = new System.Drawing.Size(120, 37);
            this.AddNewDepartmentButton.TabIndex = 14;
            this.AddNewDepartmentButton.Text = "Add New Department";
            this.AddNewDepartmentButton.UseVisualStyleBackColor = false;
            this.AddNewDepartmentButton.Click += new System.EventHandler(this.AddNewDepartmentButton_Click_1);
            // 
            // SaveNewDepartmentButton
            // 
            this.SaveNewDepartmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveNewDepartmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SaveNewDepartmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveNewDepartmentButton.ForeColor = System.Drawing.Color.Blue;
            this.SaveNewDepartmentButton.Location = new System.Drawing.Point(185, 434);
            this.SaveNewDepartmentButton.Name = "SaveNewDepartmentButton";
            this.SaveNewDepartmentButton.Size = new System.Drawing.Size(120, 37);
            this.SaveNewDepartmentButton.TabIndex = 15;
            this.SaveNewDepartmentButton.Text = "Save New Department";
            this.SaveNewDepartmentButton.UseVisualStyleBackColor = false;
            this.SaveNewDepartmentButton.Click += new System.EventHandler(this.SaveNewDepartmentButton_Click_1);
            // 
            // DepartmentReturnButton
            // 
            this.DepartmentReturnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DepartmentReturnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DepartmentReturnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentReturnButton.ForeColor = System.Drawing.Color.Blue;
            this.DepartmentReturnButton.Location = new System.Drawing.Point(677, 434);
            this.DepartmentReturnButton.Name = "DepartmentReturnButton";
            this.DepartmentReturnButton.Size = new System.Drawing.Size(100, 37);
            this.DepartmentReturnButton.TabIndex = 16;
            this.DepartmentReturnButton.Text = "Return";
            this.DepartmentReturnButton.UseVisualStyleBackColor = false;
            this.DepartmentReturnButton.Visible = false;
            // 
            // DepartmentNameerrorProvider
            // 
            this.DepartmentNameerrorProvider.ContainerControl = this;
            // 
            // DepartmentManagererrorProvider
            // 
            this.DepartmentManagererrorProvider.ContainerControl = this;
            // 
            // DescriptionLable
            // 
            this.DescriptionLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DescriptionLable.AutoSize = true;
            this.DescriptionLable.BackColor = System.Drawing.SystemColors.Control;
            this.DescriptionLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLable.Location = new System.Drawing.Point(476, 321);
            this.DescriptionLable.Name = "DescriptionLable";
            this.DescriptionLable.Size = new System.Drawing.Size(110, 20);
            this.DescriptionLable.TabIndex = 17;
            this.DescriptionLable.Text = "Description :";
            this.DescriptionLable.Visible = false;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(593, 320);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(150, 26);
            this.DescriptionTextBox.TabIndex = 18;
            this.DescriptionTextBox.Visible = false;
            // 
            // ParentDepartmentLable
            // 
            this.ParentDepartmentLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ParentDepartmentLable.AutoSize = true;
            this.ParentDepartmentLable.BackColor = System.Drawing.SystemColors.Control;
            this.ParentDepartmentLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParentDepartmentLable.Location = new System.Drawing.Point(417, 370);
            this.ParentDepartmentLable.Name = "ParentDepartmentLable";
            this.ParentDepartmentLable.Size = new System.Drawing.Size(172, 20);
            this.ParentDepartmentLable.TabIndex = 19;
            this.ParentDepartmentLable.Text = "Parent Department :";
            this.ParentDepartmentLable.Visible = false;
            // 
            // ParentDepartmentcomboBox
            // 
            this.ParentDepartmentcomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ParentDepartmentcomboBox.FormattingEnabled = true;
            this.ParentDepartmentcomboBox.Location = new System.Drawing.Point(596, 372);
            this.ParentDepartmentcomboBox.Name = "ParentDepartmentcomboBox";
            this.ParentDepartmentcomboBox.Size = new System.Drawing.Size(150, 21);
            this.ParentDepartmentcomboBox.TabIndex = 20;
            this.ParentDepartmentcomboBox.Visible = false;
            // 
            // DescriptionerrorProvider
            // 
            this.DescriptionerrorProvider.ContainerControl = this;
            // 
            // DepartmentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 506);
            this.Controls.Add(this.ParentDepartmentcomboBox);
            this.Controls.Add(this.ParentDepartmentLable);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DescriptionLable);
            this.Controls.Add(this.DepartmentReturnButton);
            this.Controls.Add(this.SaveNewDepartmentButton);
            this.Controls.Add(this.AddNewDepartmentButton);
            this.Controls.Add(this.DepartmentManagerTextBox);
            this.Controls.Add(this.DepartmentNameTextBox);
            this.Controls.Add(this.DepartmentManagerLabel);
            this.Controls.Add(this.DepartmentNameLabel);
            this.Controls.Add(this.DepartmentTitleLabel);
            this.Controls.Add(this.DepartmentDataGridView);
            this.Name = "DepartmentManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DepartmentManagement";
            this.Load += new System.EventHandler(this.DepartmentManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentNameerrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentManagererrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionerrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DepartmentDataGridView;
        private System.Windows.Forms.Label DepartmentTitleLabel;
        private System.Windows.Forms.Label DepartmentNameLabel;
        private System.Windows.Forms.Label DepartmentManagerLabel;
        private System.Windows.Forms.TextBox DepartmentNameTextBox;
        private System.Windows.Forms.TextBox DepartmentManagerTextBox;
        private System.Windows.Forms.Button AddNewDepartmentButton;
        private System.Windows.Forms.Button SaveNewDepartmentButton;
        private System.Windows.Forms.Button DepartmentReturnButton;
        private System.Windows.Forms.ErrorProvider DepartmentNameerrorProvider;
        private System.Windows.Forms.ErrorProvider DepartmentManagererrorProvider;
        private System.Windows.Forms.ComboBox ParentDepartmentcomboBox;
        private System.Windows.Forms.Label ParentDepartmentLable;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLable;
        private System.Windows.Forms.ErrorProvider DescriptionerrorProvider;
    }
}