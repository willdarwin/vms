using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using BLL;
using DataModel;
using DAL;

namespace LeavingManagementSystem
{
    public partial class UserLogin : Form
    {
        #region private field

        /// <summary>
        /// Record identifying code.
        /// </summary>
        private string identifyingCode = string.Empty;
        #endregion

        /// <summary>
        /// Load all the controls in the form
        /// </summary>
        public UserLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form and generate random identifying code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLogin_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            UserNameTextBox.Focus();
            IdentifyingCode ic = new IdentifyingCode();
            identifyingCode = ic.IdentifyingCodeStringGenerate();
            try
            {
                IdentifyingCodePictureBox.BackgroundImage = ic.IdentifyingCodeImageGenerate(identifyingCode);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            ToolTip.SetToolTip(IdentifyingCodePictureBox, "Click to change");
        }

        /// <summary>
        /// Excute user login  validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserName = UserNameTextBox.Text.Trim(),
                Password = PasswordTextBox.Text.Trim()
            };
            Response response = new Response();
            if (string.IsNullOrEmpty(UserNameTextBox.Text.Trim()))
            {
                UserNameTextBox.Focus();
                UserNameErrorProvider.SetError(UserNameTextBox, "UserName can't be vacant!");
            }
            else
            {
                UserNameErrorProvider.SetError(UserNameTextBox, "");
                if (string.IsNullOrEmpty(PasswordTextBox.Text.Trim()))
                {
                    PasswordTextBox.Focus();
                    PasswordErrorProvider.SetError(PasswordTextBox, "Password can't be vacant!");
                }
                else
                {
                    PasswordErrorProvider.SetError(PasswordTextBox, "");
                    if (string.IsNullOrEmpty(IdentifyingCodeTextBox.Text.Trim()))
                    {
                        IdentifyingCodeTextBox.Focus();
                        IdentifyingCodeErrorProvider.SetError(IdentifyingCodeTextBox, "IdentifyingCode can't be vacant!");
                    }
                    else
                    {
                        try
                        {
                            response = new UserService().Authentication(user);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        if (string.IsNullOrEmpty(response.Message))
                        {
                            if (IdentifyingCodeTextBox.Text.Trim() == identifyingCode || IdentifyingCodeTextBox.Text.Trim().ToLowerInvariant() == identifyingCode.ToLowerInvariant() || IdentifyingCodeTextBox.Text.Trim().ToUpperInvariant() == identifyingCode.ToUpperInvariant())
                            {
                                Form f = Application.OpenForms["StaffList"];
                                if (f == null)
                                {
                                    f = new StaffList();
                                    f.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    f.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Identifying code do not match!", "System prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.Message, "System prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInformation();
                            Bind();
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  Automatically popup to confirm when exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "System prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Click picturebox to change a identifying code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdentifyingCodePictureBox_Click(object sender, EventArgs e)
        {
            identifyingCode = new IdentifyingCode().IdentifyingCodeStringGenerate();
            IdentifyingCodePictureBox.BackgroundImage = new IdentifyingCode().IdentifyingCodeImageGenerate(identifyingCode);
        }

        /// <summary>
        /// Jump to changing password form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePasswordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.Owner = this;
            cp.Show();
            this.Hide();
        }

        #region public method
        /// <summary>
        /// Post the user name to the change password interface
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return UserNameTextBox.Text.Trim();
        }

        /// <summary>
        /// Clear all the textbox content
        /// </summary>
        public void ClearInformation()
        {
            UserNameTextBox.Clear();
            PasswordTextBox.Clear();
            IdentifyingCodeTextBox.Clear();
        }
        #endregion
    }
}