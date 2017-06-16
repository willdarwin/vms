using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DataModel;

namespace LeavingManagementSystem
{
    public partial class ChangePassword : Form
    {
        /// <summary>
        /// Record the result of login verification
        /// </summary>
        private string loginValidation = string.Empty;
        /// <summary>
        /// Verify whether changing password succeed.
        /// </summary>


        /// <summary>
        /// Load all the controls in the form
        /// </summary>
        public ChangePassword()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form and get the UserName from login interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            UserNameTextBox.Focus();
            ((UserLogin)this.Owner).ClearInformation();
        }

        /// <summary>
        ///  Automatically popup to confirm when exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "System prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
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
        /// Automatically popup to confirm returning to login interface when exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form f = Application.OpenForms["UserLogin"];
            if (f == null)
            {
                f = new UserLogin();
                f.Show();
            }
            else
            {
                f.Show();
            }
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserName = UserNameTextBox.Text.Trim(),
                Password = OriginalPasswordTextBox.Text.Trim()
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
                if (string.IsNullOrEmpty(OriginalPasswordTextBox.Text.Trim()))
                {
                    OriginalPasswordTextBox.Focus();
                    OriginalPasswordErrorProvider.SetError(OriginalPasswordTextBox, "OriginalPassword can't be vacant!");
                }
                else
                {
                    OriginalPasswordErrorProvider.SetError(OriginalPasswordTextBox, "");
                    if (string.IsNullOrEmpty(NewPasswordTextBox.Text.Trim()))
                    {
                        NewPasswordTextBox.Focus();
                        NewPasswordErrorProvider.SetError(NewPasswordTextBox, "NewPassword can't be vacant!");
                    }
                    else
                    {
                        NewPasswordErrorProvider.SetError(NewPasswordTextBox, "");
                        if (string.IsNullOrEmpty(ConfirmPasswordTextBox.Text.Trim()))
                        {
                            ConfirmPasswordTextBox.Focus();
                            ConfirmPasswordErrorProvider.SetError(ConfirmPasswordTextBox, "ConfirmPassword can't be vacant!");
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
                                if (NewPasswordTextBox.Text.Trim() != OriginalPasswordTextBox.Text.Trim())
                                {
                                    if (ConfirmPasswordTextBox.Text.Trim() == NewPasswordTextBox.Text.Trim())
                                    {
                                        try
                                        {
                                            user.UserId = new UserService().GetUserIdByUserName(user.UserName);
                                            user.Password = ConfirmPasswordTextBox.Text.Trim();
                                            response = new UserService().ChangePassword(user);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString());
                                        }
                                        if (response.IsFailed)
                                        {
                                            MessageBox.Show("Changing password fails", "System prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            UserNameTextBox.Focus();
                                            UserNameTextBox.Text = string.Empty;
                                            OriginalPasswordTextBox.Text = string.Empty;
                                            NewPasswordTextBox.Text = string.Empty;
                                            ConfirmPasswordTextBox.Text = string.Empty;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Changing password succeeds", "System prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please repeat new password again.", "System prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        NewPasswordTextBox.Text = string.Empty;
                                        ConfirmPasswordTextBox.Text = string.Empty;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("New password and current password are same.", "System prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    NewPasswordTextBox.Text = string.Empty;
                                    ConfirmPasswordTextBox.Text = string.Empty;
                                }
                            }
                            else
                            {
                                MessageBox.Show(response.Message, "System prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UserNameTextBox.Focus();
                                UserNameTextBox.Text = string.Empty;
                                OriginalPasswordTextBox.Text = string.Empty;
                                NewPasswordTextBox.Text = string.Empty;
                                ConfirmPasswordTextBox.Text = string.Empty;
                            }
                        }
                    }
                }
            }
        }
    }
}
