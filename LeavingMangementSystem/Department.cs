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

namespace LeavingMangementSystem
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            try
            {
                DepartmentDataGridView.DataSource = new DepartmentService().GetDepartments();
                DepartmentDataGridView.Columns[0].Visible = false;

                DataGridViewLinkColumn departmenteditbutton = new DataGridViewLinkColumn();
                departmenteditbutton.HeaderText = "EditManagement";
                departmenteditbutton.Text = "Edit";
                departmenteditbutton.UseColumnTextForLinkValue = true;
                DepartmentDataGridView.Columns.Add(departmenteditbutton);

                DataGridViewLinkColumn departmentupdatebutton = new DataGridViewLinkColumn();
                departmentupdatebutton.HeaderText = "UpdateManagement";
                departmentupdatebutton.Text = "Save";
                departmentupdatebutton.UseColumnTextForLinkValue = true;
                DepartmentDataGridView.Columns.Add(departmentupdatebutton);
                DepartmentDataGridView.Columns[4].Visible = false;

                DataGridViewLinkColumn departmentdeletebutton = new DataGridViewLinkColumn();
                departmentdeletebutton.HeaderText = "DeleteManagement";
                departmentdeletebutton.Text = "Delete";
                departmentdeletebutton.UseColumnTextForLinkValue = true;
                DepartmentDataGridView.Columns.Add(departmentdeletebutton);

                int i = DepartmentDataGridView.Rows.Count;
                for (int j = 0; j < i - 1; j++)
                {
                    DepartmentDataGridView.Rows[j].ReadOnly = true;
                }
                int t = DepartmentDataGridView.Columns.Count;
                for (int j = 0; j < t; j++)
                {
                    DepartmentDataGridView.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "System tips", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void DepartmentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rows = DepartmentDataGridView.CurrentRow.Index;
            DataModel.Department department = new DataModel.Department();
            try
            {
                if (DepartmentDataGridView.Columns[e.ColumnIndex].HeaderText == "DeleteManagement")
                {
                    department.DepartmentId = Convert.ToInt32(DepartmentDataGridView.Rows[rows].Cells[0].Value);
                    department.DepartmentName = DepartmentDataGridView.Rows[rows].Cells[1].Value.ToString();
                    department.DepartmentManager = DepartmentDataGridView.Rows[rows].Cells[2].Value.ToString();
                    
                    foreach (DataGridViewCell cell in DepartmentDataGridView.Rows[rows].Cells)
                    {
                        cell.Style.BackColor = Color.SkyBlue;
                    }
                    new DepartmentService().SearchEmployeeIdByDepartmentName(department);
                    if (department.DepartmentId != null && MessageBox.Show("Do you want to edit it?", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
                    {
                        //SystemConstantDataGridView.Rows[rows].Cells[2].ReadOnly = false;
                        //SystemConstantDataGridView.Columns[5].Visible = true;
                        //SystemConstantDataGridView.Columns[4].Visible = false;
                        
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
                        SystemConstantDataGridView.Columns[5].Visible = false;
                        systemConstant.ConstantName = SystemConstantDataGridView.Rows[rows].Cells[1].Value.ToString();
                        systemConstant.ConstantValue = SystemConstantDataGridView.Rows[rows].Cells[2].Value.ToString();
                        systemConstant.Description = SystemConstantDataGridView.Rows[rows].Cells[3].Value.ToString();
                        new SystemConstantService().UpdateSystemConstant(systemConstant);
                        SystemConstantDataGridView.DataSource = new SystemConstantService().GetSystemConstant();

                        SystemConstantDataGridView.Rows[rows].Cells[2].ReadOnly = true;
                        SystemConstantDataGridView.Columns[4].Visible = true;
                        MessageBox.Show("Update successfully.");
                        foreach (DataGridViewCell cell in SystemConstantDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.Empty;
                        }
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
        private void AddNewDepartmentButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveNewDepartmentButton_Click(object sender, EventArgs e)
        {

        }
    }
}
