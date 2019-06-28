using System;
using System.Threading;
using System.Windows.Forms;
using BusinessLayer;

namespace WindowsFormsLayers
{
    public partial class MainForm : Form
    {
        private static int counter;

        private int childFormNumber = 0;
        private CrmManager crmManager;

        public MainForm(CrmManager crmManager)
        {
            MainForm.counter = 0;
            this.crmManager = crmManager;
            crmManager.Signal += CrmManagerOnSignal;

            crmManager.Start();

            InitializeComponent();
           
        }

        private void  CrmManagerOnSignal(object sender, EventArgs e)
        {
            MainForm.counter++;
            signalStatuslabel.Text = $"  server signal# {counter}";
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void customersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowCustomersForm();
        }

        private void ShowCustomersForm()
        {
            ShowChildForm(new CustomersForm { CrmManager = crmManager });
        }

        private void ShowChildForm(Form child)
        {
            child.MdiParent = this;
            child.Show();
        }

        private void findTraitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            crmManager.Stop();
        }
    }
}
