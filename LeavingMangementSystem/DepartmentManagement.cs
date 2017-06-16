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
    public partial class DepartmentManagement : Form
    {
        public DepartmentManagement()
        {
            InitializeComponent();
        }
        private void DepartmentManagement_Load(object sender, EventArgs e)
        {
            Bind();
        }
        private void Bind()
        {
            try
            {
                DepartmentDataGridView.DataSource = new DepartmentService().GetDepartments();
                DepartmentDataGridView.Columns[0].Visible = false;
                DepartmentDataGridView.Columns[1].HeaderText = "Department Name";
                DepartmentDataGridView.Columns[2].HeaderText = "Description";
                DepartmentDataGridView.Columns[3].HeaderText = "Department Manager";
                DepartmentDataGridView.Columns[4].HeaderText = "Parent Department";

                DataGridViewComboBoxColumn parentdepartment = new DataGridViewComboBoxColumn();
                parentdepartment.HeaderText = "ParentDepartment";

                parentdepartment.DataSource = new DepartmentService().AllParentDepartment();
                parentdepartment.ValueMember = "DepartmentId";
                parentdepartment.DisplayMember = "DepartmentName";
                DepartmentDataGridView.Columns.Add(parentdepartment);
                DepartmentDataGridView.Columns[5].Visible = false;

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
                DepartmentDataGridView.Columns[7].Visible = false;

                DataGridViewLinkColumn departmentcanclebutton = new DataGridViewLinkColumn();
                departmentcanclebutton.HeaderText = "CancleManagement";
                departmentcanclebutton.Text = "Cancle";
                departmentcanclebutton.UseColumnTextForLinkValue = true;
                DepartmentDataGridView.Columns.Add(departmentcanclebutton);
                DepartmentDataGridView.Columns[8].Visible = false;

                DataGridViewLinkColumn departmentdeletebutton = new DataGridViewLinkColumn();
                departmentdeletebutton.HeaderText = "DeleteManagement";
                departmentdeletebutton.Text = "Delete";
                departmentdeletebutton.UseColumnTextForLinkValue = true;
                DepartmentDataGridView.Columns.Add(departmentdeletebutton);

                int i = DepartmentDataGridView.Rows.Count;
                for (int j = 0; j < i; j++)
                {
                    DepartmentDataGridView.Rows[j].Cells[5].Style.NullValue = DepartmentDataGridView.Rows[j].Cells[4].Value.ToString();
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
            int DepartmentId = Convert.ToInt32(DepartmentDataGridView.Rows[rows].Cells[0].Value);

            try
            {
                if (DepartmentDataGridView.Columns[e.ColumnIndex].HeaderText == "DeleteManagement")
                {
                    foreach (DataGridViewCell cell in DepartmentDataGridView.Rows[rows].Cells)
                    {
                        cell.Style.BackColor = Color.SkyBlue;
                    }

                    bool dp = new DepartmentService().SearchEmployeeIdByDepartment(DepartmentId);
                    if (!dp && DepartmentId != 0 && MessageBox.Show("Do you want to delete it?", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
                    {
                        new DepartmentService().DeleteDepartment(DepartmentId);
                        this.DepartmentDataGridView.Columns.RemoveAt(9);
                        this.DepartmentDataGridView.Columns.RemoveAt(8);
                        this.DepartmentDataGridView.Columns.RemoveAt(7);
                        this.DepartmentDataGridView.Columns.RemoveAt(6);
                        this.DepartmentDataGridView.Columns.RemoveAt(5);
                        this.DepartmentDataGridView.DataSource = null;
                        Bind();
                    }
                    else if (dp)
                    {
                        MessageBox.Show("This department can not be deleted right now.");
                        foreach (DataGridViewCell cell in DepartmentDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.Empty;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewCell cell in DepartmentDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.Empty;
                        }
                    }
                }
                if (DepartmentDataGridView.Columns[e.ColumnIndex].HeaderText == "EditManagement")
                {
                    if (DepartmentId != 0)
                    {
                        DepartmentDataGridView.Rows[rows].ReadOnly = false;
                        DepartmentDataGridView.Columns[9].Visible = false;
                        DepartmentDataGridView.Columns[8].Visible = true;
                        DepartmentDataGridView.Columns[7].Visible = true;
                        DepartmentDataGridView.Columns[6].Visible = false;
                        DepartmentDataGridView.Columns[5].Visible = true;
                        DepartmentDataGridView.Columns[4].Visible = false;
                        foreach (DataGridViewCell cell in DepartmentDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.SkyBlue;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewCell cell in DepartmentDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.Empty;
                        }
                    }
                }
                if (DepartmentDataGridView.Columns[e.ColumnIndex].HeaderText == "UpdateManagement")
                {
                    if (DepartmentDataGridView.Rows[rows].Cells[7].Style.BackColor == Color.SkyBlue)
                    {
                        DataModel.Department departmentnew = new DataModel.Department();
                        departmentnew.DepartmentId = Convert.ToInt32(DepartmentDataGridView.Rows[rows].Cells[0].Value);
                        departmentnew.Description = DepartmentDataGridView.Rows[rows].Cells[2].Value.ToString().Trim();
                        bool stf = new DepartmentService().SearchOneStaffId(DepartmentDataGridView.Rows[rows].Cells[3].Value.ToString().Trim());
                        bool dept = new DepartmentService().SearchDepartmentByDepartmentName(DepartmentDataGridView.Rows[rows].Cells[1].Value.ToString().Trim());
                        if (!dept)
                        {
                            departmentnew.DepartmentName = DepartmentDataGridView.Rows[rows].Cells[1].Value.ToString().Trim();
                        }
                        else
                        {
                            int deptId = new DepartmentService().GetDepartmentId(DepartmentDataGridView.Rows[rows].Cells[1].Value.ToString().Trim());
                            if (deptId == departmentnew.DepartmentId)
                            {
                                departmentnew.DepartmentName = DepartmentDataGridView.Rows[rows].Cells[1].Value.ToString().Trim();
                            }
                            else
                            {
                                MessageBox.Show("This department already exist.");
                            }
                        }

                        if (DepartmentDataGridView.Rows[rows].Cells[5].Value != null)
                        {
                            departmentnew.ParentDepartmentId = Convert.ToInt32(DepartmentDataGridView.Rows[rows].Cells[5].Value.ToString().Trim());
                        }
                        else
                        {
                            departmentnew.ParentDepartmentId = new DepartmentService().GetParentId(DepartmentDataGridView.Rows[rows].Cells[5].Style.NullValue.ToString().Trim());
                        }

                        if (!stf)
                        {
                            MessageBox.Show("This manager does not exist.");
                        }
                        else if (stf && departmentnew.DepartmentId != 0 && departmentnew.DepartmentName != null && departmentnew.ParentDepartmentId != 0)
                        {
                            departmentnew.DepartmentManagerId = new DepartmentService().GetManagerId(DepartmentDataGridView.Rows[rows].Cells[3].Value.ToString().Trim());
                            new DepartmentService().UpdateDepartment(departmentnew);
                            MessageBox.Show("Update successfully.");
                            foreach (DataGridViewCell cell in DepartmentDataGridView.Rows[rows].Cells)
                            {
                                cell.Style.BackColor = Color.Empty;
                            }
                            this.DepartmentDataGridView.Columns.RemoveAt(9);
                            this.DepartmentDataGridView.Columns.RemoveAt(8);
                            this.DepartmentDataGridView.Columns.RemoveAt(7);
                            this.DepartmentDataGridView.Columns.RemoveAt(6);
                            this.DepartmentDataGridView.Columns.RemoveAt(5);
                            this.DepartmentDataGridView.DataSource = null;
                            Bind();
                        }
                    }
                    else
                    {
                        MessageBox.Show("It is the different row.Please check it again");
                    }
                }
                if (DepartmentDataGridView.Columns[e.ColumnIndex].HeaderText == "CancleManagement")
                {
                    if (DepartmentDataGridView.Rows[rows].Cells[8].Style.BackColor == Color.SkyBlue)
                    {
                        foreach (DataGridViewCell cell in DepartmentDataGridView.Rows[rows].Cells)
                        {
                            cell.Style.BackColor = Color.Empty;
                        }
                        this.DepartmentDataGridView.Columns.RemoveAt(9);
                        this.DepartmentDataGridView.Columns.RemoveAt(8);
                        this.DepartmentDataGridView.Columns.RemoveAt(7);
                        this.DepartmentDataGridView.Columns.RemoveAt(6);
                        this.DepartmentDataGridView.Columns.RemoveAt(5);
                        this.DepartmentDataGridView.DataSource = null;
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


        private void AddNewDepartmentButton_Click_1(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(this.Size.Width, 650);
            DepartmentNameLabel.Visible = true;
            DepartmentNameTextBox.Visible = true;
            DepartmentManagerLabel.Visible = true;
            DepartmentManagerTextBox.Visible = true;
            DescriptionLable.Visible = true;
            DescriptionTextBox.Visible = true;
            ParentDepartmentLable.Visible = true;
            ParentDepartmentcomboBox.Visible = true;
            ParentDepartmentcomboBox.DataSource = new DepartmentService().AllParentDepartment();
            ParentDepartmentcomboBox.ValueMember = "DepartmentId";
            ParentDepartmentcomboBox.DisplayMember = "DepartmentName";
        }

        private void SaveNewDepartmentButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DepartmentNameTextBox.Text.Trim()))
            {
                DepartmentNameerrorProvider.SetError(DepartmentNameTextBox, "Sorry!Please input department name.");
            }
            else if (DepartmentNameTextBox.Text.Trim() != "")
            {
                DepartmentNameerrorProvider.SetError(DepartmentNameTextBox, "");
            }
            if (string.IsNullOrEmpty(DepartmentManagerTextBox.Text.Trim()))
            {
                DepartmentManagererrorProvider.SetError(DepartmentManagerTextBox, "Sorry!Please input department manager.");
            }
            else if (DepartmentManagerTextBox.Text.Trim() != "")
            {
                DepartmentManagererrorProvider.SetError(DepartmentManagerTextBox, "");
            }
            if (string.IsNullOrEmpty(DescriptionTextBox.Text.Trim()))
            {
                DepartmentManagererrorProvider.SetError(DescriptionTextBox, "Sorry!Please input description.");
            }
            else if (DescriptionTextBox.Text.Trim() != "")
            {
                DepartmentManagererrorProvider.SetError(DescriptionTextBox, "");
            }

            bool dp = new DepartmentService().SearchDepartmentByDepartmentName(DepartmentNameTextBox.Text.Trim());
            bool bl = new DepartmentService().SearchOneStaffId(DepartmentManagerTextBox.Text.Trim());

            if (bl && !dp && DepartmentNameTextBox.Text.Trim() != "" && DepartmentManagerTextBox.Text.Trim() != "" && DescriptionTextBox.Text.Trim() != "")
            {
                DataModel.Department department = new DataModel.Department();
                department.DepartmentName = DepartmentNameTextBox.Text.Trim();
                department.Description = DescriptionTextBox.Text.Trim();
                department.DepartmentManagerId = new DepartmentService().GetManagerId(DepartmentManagerTextBox.Text.Trim());
                department.ParentDepartmentId = Convert.ToInt32(ParentDepartmentcomboBox.SelectedValue.ToString());
                new DepartmentService().AddDepartment(department);

                this.DepartmentDataGridView.Columns.RemoveAt(9);
                this.DepartmentDataGridView.Columns.RemoveAt(8);
                this.DepartmentDataGridView.Columns.RemoveAt(7);
                this.DepartmentDataGridView.Columns.RemoveAt(6);
                this.DepartmentDataGridView.Columns.RemoveAt(5);
                this.DepartmentDataGridView.DataSource = null;
                Bind();

                MessageBox.Show("Add successfully.");
                DepartmentNameLabel.Visible = false;
                DepartmentNameTextBox.Visible = false;
                DepartmentNameTextBox.Text = "";
                DepartmentManagerLabel.Visible = false;
                DepartmentManagerTextBox.Visible = false;
                DepartmentManagerTextBox.Text = "";
                DescriptionLable.Visible = false;
                DescriptionTextBox.Visible = false;
                DescriptionTextBox.Text = "";
                ParentDepartmentLable.Visible = false;
                ParentDepartmentcomboBox.Visible = false;

                this.Size = new System.Drawing.Size(this.Size.Width, 540);
            }
            else if (dp)
            {
                MessageBox.Show("This department already exist.");
                DepartmentNameTextBox.Text = "";
            }
            else if (!bl)
            {
                MessageBox.Show("This manager does not exist.");
                DepartmentManagerTextBox.Text = "";
            }
        }

        //private void DepartmentManagement_FormClosing(object sender, FormClosingEventArgs e)
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
