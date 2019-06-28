using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSpaghetti.CrmRepositoryService;

namespace WinFormsSpaghetti
{
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        public CustomersForm CustomersForm { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            long t = 0;
            if (!long.TryParse(textBox1.Text, out t))
            {
                MessageBox.Show( "ID must be number","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            emp.Id = long.Parse(textBox1.Text);
            emp.Name = textBox2.Text;
            emp.Surname = textBox3.Text;

            if (!CustomersForm.WcfClient.GetAllEmployees().Contains(emp,new EmployeeComparer()))
            {
                CustomersForm.WcfClient.AddEmployee(emp);
            }

            DataGridView dgv1 = (DataGridView)CustomersForm.Controls["splitContainer1"].Controls[0].Controls["dataGridView1"];
            if (dgv1 != null)
            {
                if (dgv1.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = dgv1.SelectedRows[0];
                    if (selectedRow != null)
                    {
                        Company company = selectedRow.DataBoundItem as Company;
                        if (company != null)
                        {
                            CustomersForm.WcfClient.AddEmployeeToCompany(emp, company);
                            DataGridView dgv2 = (DataGridView) CustomersForm.Controls["splitContainer1"].Controls[1]
                                .Controls["dataGridView2"];
                            if (dgv2 != null)
                            {
                                dgv2.DataSource = CustomersForm.WcfClient.GetEmployeesByCompany(company.Name);
                            }

                            this.Close();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""
                ;
            textBox2.Text = string.Empty;           textBox3.Text = String.Empty;
            

        }
    }

    internal class EmployeeComparer : IEqualityComparer<Employee>
    {
    
        public bool Equals(Employee x, Employee y)
        {
            return x.Name == y.Name && x.Id == y.Id && x.Surname == y.Surname;
        }

        public int GetHashCode(Employee obj)
        {
            unchecked
            {
                var hashCode = (obj.Name != null ? obj.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.Surname != null ? obj.Surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                return hashCode;
            }
        }
    }
}
