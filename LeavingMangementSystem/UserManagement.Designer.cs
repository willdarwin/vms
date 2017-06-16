namespace LeavingManagementSystem
{
    partial class UserManagement
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
            this.UserDataGridView = new System.Windows.Forms.DataGridView();
            this.UserReturnButton = new System.Windows.Forms.Button();
            this.SaveNewUserButton = new System.Windows.Forms.Button();
            this.UserTitleLabel = new System.Windows.Forms.Label();
            this.AddNewUserbutton = new System.Windows.Forms.Button();
            this.usernameLb = new System.Windows.Forms.Label();
            this.usernameTb = new System.Windows.Forms.TextBox();
            this.passwordLb = new System.Windows.Forms.Label();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.passwordConfirmLb = new System.Windows.Forms.Label();
            this.passwordConfirmTb = new System.Windows.Forms.TextBox();
            this.userNameerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.passworderrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.passwordConfirmerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UserDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameerrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passworderrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordConfirmerrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // UserDataGridView
            // 
            this.UserDataGridView.AllowUserToAddRows = false;
            this.UserDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UserDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.UserDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.UserDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.UserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserDataGridView.Location = new System.Drawing.Point(28, 56);
            this.UserDataGridView.MultiSelect = false;
            this.UserDataGridView.Name = "UserDataGridView";
            this.UserDataGridView.RowHeadersVisible = false;
            this.UserDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.UserDataGridView.Size = new System.Drawing.Size(516, 430);
            this.UserDataGridView.TabIndex = 1;
            this.UserDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserDataGridView_CellContentClick);
            // 
            // UserReturnButton
            // 
            this.UserReturnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserReturnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UserReturnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserReturnButton.ForeColor = System.Drawing.Color.Blue;
            this.UserReturnButton.Location = new System.Drawing.Point(440, 502);
            this.UserReturnButton.Name = "UserReturnButton";
            this.UserReturnButton.Size = new System.Drawing.Size(100, 37);
            this.UserReturnButton.TabIndex = 3;
            this.UserReturnButton.Text = "Return";
            this.UserReturnButton.UseVisualStyleBackColor = false;
            this.UserReturnButton.Visible = false;
            // 
            // SaveNewUserButton
            // 
            this.SaveNewUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveNewUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SaveNewUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveNewUserButton.ForeColor = System.Drawing.Color.Blue;
            this.SaveNewUserButton.Location = new System.Drawing.Point(185, 502);
            this.SaveNewUserButton.Name = "SaveNewUserButton";
            this.SaveNewUserButton.Size = new System.Drawing.Size(120, 37);
            this.SaveNewUserButton.TabIndex = 4;
            this.SaveNewUserButton.Text = "Save New User";
            this.SaveNewUserButton.UseVisualStyleBackColor = false;
            this.SaveNewUserButton.Click += new System.EventHandler(this.SaveNewUserButton_Click);
            // 
            // UserTitleLabel
            // 
            this.UserTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UserTitleLabel.AutoSize = true;
            this.UserTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserTitleLabel.ForeColor = System.Drawing.Color.Gray;
            this.UserTitleLabel.Location = new System.Drawing.Point(200, 17);
            this.UserTitleLabel.Name = "UserTitleLabel";
            this.UserTitleLabel.Size = new System.Drawing.Size(165, 24);
            this.UserTitleLabel.TabIndex = 5;
            this.UserTitleLabel.Text = "User Management";
            // 
            // AddNewUserbutton
            // 
            this.AddNewUserbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNewUserbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AddNewUserbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewUserbutton.ForeColor = System.Drawing.Color.DarkMagenta;
            this.AddNewUserbutton.Location = new System.Drawing.Point(34, 502);
            this.AddNewUserbutton.Name = "AddNewUserbutton";
            this.AddNewUserbutton.Size = new System.Drawing.Size(120, 37);
            this.AddNewUserbutton.TabIndex = 6;
            this.AddNewUserbutton.Text = "Add New User";
            this.AddNewUserbutton.UseVisualStyleBackColor = false;
            this.AddNewUserbutton.Click += new System.EventHandler(this.AddNewUserbutton_Click);
            // 
            // usernameLb
            // 
            this.usernameLb.AutoSize = true;
            this.usernameLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usernameLb.Location = new System.Drawing.Point(53, 500);
            this.usernameLb.Name = "usernameLb";
            this.usernameLb.Size = new System.Drawing.Size(93, 20);
            this.usernameLb.TabIndex = 7;
            this.usernameLb.Text = "username:";
            this.usernameLb.Visible = false;
            // 
            // usernameTb
            // 
            this.usernameTb.Location = new System.Drawing.Point(156, 500);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(150, 20);
            this.usernameTb.TabIndex = 8;
            this.usernameTb.Visible = false;
            // 
            // passwordLb
            // 
            this.passwordLb.AutoSize = true;
            this.passwordLb.Location = new System.Drawing.Point(53, 530);
            this.passwordLb.Name = "passwordLb";
            this.passwordLb.Size = new System.Drawing.Size(55, 13);
            this.passwordLb.TabIndex = 9;
            this.passwordLb.Text = "password:";
            this.passwordLb.Visible = false;
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(118, 530);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PasswordChar = '*';
            this.passwordTb.Size = new System.Drawing.Size(150, 20);
            this.passwordTb.TabIndex = 10;
            this.passwordTb.Visible = false;
            // 
            // passwordConfirmLb
            // 
            this.passwordConfirmLb.AutoSize = true;
            this.passwordConfirmLb.Location = new System.Drawing.Point(53, 560);
            this.passwordConfirmLb.Name = "passwordConfirmLb";
            this.passwordConfirmLb.Size = new System.Drawing.Size(92, 13);
            this.passwordConfirmLb.TabIndex = 11;
            this.passwordConfirmLb.Text = "confirm password:";
            this.passwordConfirmLb.Visible = false;
            // 
            // passwordConfirmTb
            // 
            this.passwordConfirmTb.Location = new System.Drawing.Point(149, 560);
            this.passwordConfirmTb.Name = "passwordConfirmTb";
            this.passwordConfirmTb.PasswordChar = '*';
            this.passwordConfirmTb.Size = new System.Drawing.Size(139, 20);
            this.passwordConfirmTb.TabIndex = 12;
            this.passwordConfirmTb.Visible = false;
            // 
            // userNameerrorProvider
            // 
            this.userNameerrorProvider.ContainerControl = this;
            // 
            // passworderrorProvider
            // 
            this.passworderrorProvider.ContainerControl = this;
            // 
            // passwordConfirmerrorProvider
            // 
            this.passwordConfirmerrorProvider.ContainerControl = this;
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 569);
            this.Controls.Add(this.passwordConfirmTb);
            this.Controls.Add(this.passwordConfirmLb);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.passwordLb);
            this.Controls.Add(this.usernameTb);
            this.Controls.Add(this.usernameLb);
            this.Controls.Add(this.AddNewUserbutton);
            this.Controls.Add(this.UserTitleLabel);
            this.Controls.Add(this.SaveNewUserButton);
            this.Controls.Add(this.UserReturnButton);
            this.Controls.Add(this.UserDataGridView);
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserManagement";
            this.Load += new System.EventHandler(this.UserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameerrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passworderrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordConfirmerrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UserDataGridView;
        private System.Windows.Forms.Button UserReturnButton;
        private System.Windows.Forms.Button SaveNewUserButton;
        private System.Windows.Forms.Label UserTitleLabel;
        private System.Windows.Forms.Button AddNewUserbutton;
        private System.Windows.Forms.Label usernameLb;
        private System.Windows.Forms.TextBox usernameTb;
        private System.Windows.Forms.Label passwordLb;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.Label passwordConfirmLb;
        private System.Windows.Forms.TextBox passwordConfirmTb;
        private System.Windows.Forms.ErrorProvider userNameerrorProvider;
        private System.Windows.Forms.ErrorProvider passworderrorProvider;
        private System.Windows.Forms.ErrorProvider passwordConfirmerrorProvider;
    }
}