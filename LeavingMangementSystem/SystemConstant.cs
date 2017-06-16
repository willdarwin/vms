using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using BLL;
using DataModel;

namespace LeavingManagementSystem
{
    public partial class SystemConstant : Form
    {
        public SystemConstant()
        {
            InitializeComponent();
        }

        private void SystemConstant_Load(object sender, EventArgs e)
        {
             Bind();
        }

        private void Bind()
        {
            try
            {
                SystemConstantDataGridView.DataSource = new SystemConstantService().GetSystemConstant();
                SystemConstantDataGridView.Columns[0].Visible = false;

                DataGridViewLinkColumn SystemConstanteditbutton = new DataGridViewLinkColumn();
                SystemConstanteditbutton.HeaderText = "EditManagement";
                SystemConstanteditbutton.Text = "Edit";
                SystemConstanteditbutton.UseColumnTextForLinkValue = true;
                SystemConstantDataGridView.Columns.Add(SystemConstanteditbutton);

                DataGridViewLinkColumn SystemConstantupdatebutton = new DataGridViewLinkColumn();
                SystemConstantupdatebutton.HeaderText = "UpdateManagement";
                SystemConstantupdatebutton.Text = "Save";
                SystemConstantupdatebutton.UseColumnTextForLinkValue = true;
                SystemConstantDataGridView.Columns.Add(SystemConstantupdatebutton);
                SystemConstantDataGridView.Columns[5].Visible = false;

                SystemConstantDateTimePicker.Visible = false;
                this.SystemConstantDataGridView.Controls.Add(SystemConstantDateTimePicker);
                SystemConstantDateTimePicker.Text = SystemConstantDataGridView.Rows[3].Cells[2].Value.ToString();
                int t = SystemConstantDataGridView.Columns.Count;
                for (int j = 0; j < t; j++)
                {
                    SystemConstantDataGridView.Columns[j].ReadOnly = true;
                    SystemConstantDataGridView.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "System tips", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void SystemConstantDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rows = SystemConstantDataGridView.CurrentRow.Index;
            DataModel.SystemConstant systemConstant = new DataModel.SystemConstant();
            string SystemConstantid = SystemConstantDataGridView.Rows[rows].Cells[0].Value.ToString();
            try
            {
                if (SystemConstantDataGridView.Columns[e.ColumnIndex].HeaderText == "EditManagement")
                {
                    
                    if (SystemConstantid != null && MessageBox.Show("Do you want to edit it?", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
                    {
                       
                        SystemConstantDataGridView.Columns[5].Visible = true;
                        SystemConstantDataGridView.Columns[4].Visible = false;
                        if (rows == 3)
                        {
                            SystemConstantDateTimePicker.CustomFormat = "MM-dd";
                            SystemConstantDateTimePicker.Format = DateTimePickerFormat.Custom;
                            SystemConstantDateTimePicker.Visible = true;
                        }
                        else
                        {
                            SystemConstantDataGridView.Rows[rows].Cells[2].ReadOnly = false;
                        }
                        foreach (DataGridViewCell cell in SystemConstantDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.SkyBlue;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewCell cell in SystemConstantDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.Empty;
                        }
                    }
                }
                if (SystemConstantDataGridView.Columns[e.ColumnIndex].HeaderText == "UpdateManagement")
                {
                    if (SystemConstantDataGridView.Rows[rows].Cells[5].Style.BackColor == Color.SkyBlue)
                    {
                        SystemConstantDataGridView.Columns[4].Visible = true;
                        SystemConstantDataGridView.Columns[5].Visible = false;
                        SystemConstantDataGridView.Rows[rows].Cells[2].ReadOnly = true;
                        SystemConstantDateTimePicker.Visible = false;
                        systemConstant.SystemConstantId = Convert.ToInt32(SystemConstantid);
                        systemConstant.ConstantName = SystemConstantDataGridView.Rows[rows].Cells[1].Value.ToString().Trim();
                        if (rows == 3)
                        {
                            systemConstant.ConstantValue = SystemConstantDateTimePicker.Text;
                        }
                        else
                        {
                            systemConstant.ConstantValue = SystemConstantDataGridView.Rows[rows].Cells[2].Value.ToString().Trim();
                        }
                        systemConstant.Description = SystemConstantDataGridView.Rows[rows].Cells[3].Value.ToString().Trim();
                        new SystemConstantService().UpdateSystemConstant(systemConstant);
                        MessageBox.Show("Update successfully.");
                        foreach (DataGridViewCell cell in SystemConstantDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.Empty;
                        }
                        this.SystemConstantDataGridView.Columns.RemoveAt(5);
                        this.SystemConstantDataGridView.Columns.RemoveAt(4);
                        this.SystemConstantDataGridView.DataSource = null;
                        Bind();
                    }
                    else
                    {
                        MessageBox.Show("It is the different row.Please check it again");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "System tips", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SystemConstantDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (SystemConstantDataGridView.Columns[e.ColumnIndex].HeaderText == "ConstantValue")
            {
                int rows = SystemConstantDataGridView.CurrentRow.Index;
                if (e.FormattedValue.ToString().Trim() != ""&& rows!=3)
                {
                    try
                    {
                        int.Parse(e.FormattedValue.ToString());
                    }
                    catch (Exception ex)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please input a number");
                    }
                }
            }
        }

        //private void SystemConstant_FormClosing(object sender, FormClosingEventArgs e)
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
