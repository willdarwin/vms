using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BLL;
using DataModel;

namespace LeavingManagementSystem
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            Bind();
        }
        private void Bind()
        {
            this.UserDataGridView.DataSource = new UserService().GetAllUsers();
            UserDataGridView.Columns[0].Visible = false;


            DataGridViewLinkColumn usereditbutton = new DataGridViewLinkColumn();
            usereditbutton.HeaderText = "Reset password";
            usereditbutton.Text = "Reset";
            usereditbutton.UseColumnTextForLinkValue = true;
            UserDataGridView.Columns.Add(usereditbutton);



            int i = UserDataGridView.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                UserDataGridView.Rows[j].ReadOnly = true;
            }
            int t = UserDataGridView.Columns.Count;
            for (int j = 0; j < t; j++)
            {
                UserDataGridView.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void UserDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UserDataGridView.Columns[e.ColumnIndex].HeaderText == "Reset password")
                {
                    int rows = UserDataGridView.CurrentRow.Index;
                    string userid = UserDataGridView.Rows[rows].Cells[0].Value.ToString();
                    if (userid != null && userid != "" && MessageBox.Show("Do you want to reset password?", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
                    {

                        foreach (DataGridViewCell cell in UserDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.SkyBlue;
                        }


                        if (UserDataGridView.Rows[rows].Cells[3].Style.BackColor == Color.SkyBlue)
                        {
                            string username = UserDataGridView.Rows[rows].Cells[1].Value.ToString();
                            UserService userService = new UserService();
                            userService.SetInitialPassword(Convert.ToInt32(userid), username);

                            UserDataGridView.Rows[rows].ReadOnly = true;
                            UserDataGridView.Columns[3].Visible = true;

                            foreach (DataGridViewCell cell in UserDataGridView.Rows[rows].Cells)
                            {
                                cell.Style.BackColor = Color.Empty;
                            }


                            this.UserDataGridView.Columns.RemoveAt(3);
                            this.UserDataGridView.DataSource = null;
                            Bind();
                            MessageBox.Show("Reset password successfully.");

                        }
                        else
                        {
                            foreach (DataGridViewCell cell in UserDataGridView.Rows[rows].Cells)
                            {
                                cell.Style.BackColor = Color.Empty;
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SaveNewUserButton_Click(object sender, EventArgs e)
        {
            string username = usernameTb.Text.Trim();

            string password = username;
            bool judge = false;

            if (string.IsNullOrEmpty(username))
            {
                userNameerrorProvider.SetError(usernameTb, "Sorry!Please input user name.");

            }
            else if (username != "")
            {
                userNameerrorProvider.SetError(usernameTb, "");

            }

            if (username != "")
            {
                judge = true;

            }
            if (judge == true)
            {
                int rows = UserDataGridView.CurrentRow.Index;

                User user = new User();
                user.UserName = username;
                user.Password = password;
                new UserService().InsertUser(user);
                this.UserDataGridView.Columns.RemoveAt(3);
                this.UserDataGridView.DataSource = null;
                
                Bind();

                UserDataGridView.Columns[0].Visible = false;
                UserDataGridView.Rows[rows].ReadOnly = true;
              
                
                MessageBox.Show("Add successfully.");

                userInforShowOrNot(false);
                this.Size = new System.Drawing.Size(this.Size.Width, 600);
            }
        }

        private void AddNewUserbutton_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(this.Size.Width, 650);
            userInforShowOrNot(true);

        }


        public void userInforShowOrNot(bool value)
        {
            usernameLb.Visible = value;
            usernameTb.Visible = value;

        }


      

        //private void UserManagement_FormClosing_1(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult dr = MessageBox.Show("Do you want to exit?", "System prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (dr == DialogResult.Yes)
        //    {
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}

    }
}

