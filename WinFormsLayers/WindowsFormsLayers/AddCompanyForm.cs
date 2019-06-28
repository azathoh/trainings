using System;
using System.Windows.Forms;
using Contracts;

namespace WindowsFormsLayers
{
    public partial class AddCompanyForm : Form
    {
        public AddCompanyForm()
        {
            InitializeComponent();
        }

        public CustomersForm CustomersForm { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            long id = long.Parse(textBox1.Text);
            string name = textBox2.Text;
            this.NewCompany = new Tuple<long,string>(id,name);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public Tuple<long, string> NewCompany { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
