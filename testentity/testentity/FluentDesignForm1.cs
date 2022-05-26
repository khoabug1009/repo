using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;

namespace testentity
{
    public partial class FluentDesignForm1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Person newPerson = new Person();
        public FluentDesignForm1()
        {
            InitializeComponent();
        }
        public void ClearItems()
        {
            txtID.Clear();
            txtFullname.Clear();
            txtPhonenumber.Clear();
            txtEmail.Clear();
            txtSalary.Clear();
            txtWorkplace.Clear();
            txtAddress.Clear();
        }
        void load()
        {
            txtID.Enabled = false;
            EZCLOUDEntities db = new EZCLOUDEntities();
            dataGridView1.DataSource = db.People.ToList();
        }
        private void FluentDesignForm1_Load(object sender, EventArgs e)
        {
            load();
        }

        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text.Trim() != "" && txtPhonenumber.Text.Trim() != "" && txtEmail.Text.Trim() != "" && txtSalary.Text.Trim() != "" && txtWorkplace.Text.Trim() != "" && txtAddress.Text.Trim() != "") {

                string status = "";
                if (rbtOn.Checked)
                {
                    status = rbtOn.Text;
                }
                if (rbtOff.Checked)
                {
                    status = rbtOff.Text;
                }

                newPerson.Fullname = txtFullname.Text;
                newPerson.Phone_number = txtPhonenumber.Text;
                newPerson.Email = txtEmail.Text;
                newPerson.Salary = Convert.ToInt32(txtSalary.Text);
                newPerson.Status = status;
                newPerson.Workplace = txtWorkplace.Text;
                newPerson.Address = txtAddress.Text;
                using (EZCLOUDEntities db = new EZCLOUDEntities())
                {
                    db.People.Add(newPerson);
                    db.SaveChanges();
                }
                MessageBox.Show("add successfully");
                load();
                ClearItems();
            }
            else
            {
                MessageBox.Show("not be emty");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if ((txtFullname.Text.Trim() != "") && (txtPhonenumber.Text.Trim() != "") && (txtEmail.Text.Trim() != "") && (txtSalary.Text.Trim() != "") && (txtWorkplace.Text.Trim() != "") && (txtAddress.Text.Trim() != ""))
            {
                btnAdd.Enabled = true;
                string status = "";
                if (rbtOn.Checked)
                {
                    status = rbtOn.Text;
                }
                if (rbtOff.Checked)
                {
                    status = rbtOff.Text;
                }

                newPerson.Fullname = txtFullname.Text;
                newPerson.Phone_number = txtPhonenumber.Text;
                newPerson.Email = txtEmail.Text;
                newPerson.Salary = Convert.ToInt32(txtSalary.Text);
                newPerson.Status = status;
                newPerson.Workplace = txtWorkplace.Text;
                newPerson.Address = txtAddress.Text;
                using (EZCLOUDEntities db = new EZCLOUDEntities())
                {
                    db.Entry(newPerson).State = EntityState.Modified;
                    db.SaveChanges();
                    load();
                    ClearItems();

                }
            }
            else
            {
                MessageBox.Show("You have not selected any items to edit.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if ((txtFullname.Text.Trim() != "") && (txtPhonenumber.Text.Trim() != "") && (txtEmail.Text.Trim() != "") && (txtSalary.Text.Trim() != "") && (txtWorkplace.Text.Trim() != "") && (txtAddress.Text.Trim() != ""))
            {
                btnAdd.Enabled = true;
                if (MessageBox.Show(" ban co chac muon xoa khong", " canh bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (EZCLOUDEntities db = new EZCLOUDEntities())
                    {
                        var entry = db.Entry(newPerson);
                        if (entry.State == EntityState.Detached)
                        {
                            db.People.Attach(newPerson);
                        }
                        db.People.Remove(newPerson);
                        db.SaveChanges();
                        load();
                        ClearItems();

                    }
                }
            }
            else
            {
                MessageBox.Show("You have not selected any items to delete.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            if(dataGridView1.CurrentRow.Index != -1)
            {
                newPerson.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (EZCLOUDEntities db = new EZCLOUDEntities())
                {
                    newPerson = db.People.Where(x => x.ID == newPerson.ID).FirstOrDefault();
                    txtID.Text = newPerson.ID.ToString();
                    txtFullname.Text = newPerson.Fullname;
                    txtPhonenumber.Text = newPerson.Phone_number;
                    txtEmail.Text = newPerson.Email;
                    string status = newPerson.Status;
                    if (status.Equals("on"))
                    {
                        rbtOn.Checked = true;
                    }
                    if (status.Equals("off"))
                    {
                        rbtOff.Checked = true;
                    }
                    txtSalary.Text = newPerson.Salary.ToString();
                    txtWorkplace.Text = newPerson.Workplace;
                    txtAddress.Text = newPerson.Address;
                }
            }
        }
    }
}
