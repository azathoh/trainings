using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSpaghetti.CrmRepositoryService;

namespace WinFormsSpaghetti
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;
        private bool _run;
        private static int counter = 0;
        public MainForm()
        {
            _run = true;
            InitializeComponent();
            CrmRepositoryService.CRMRepositoryClient client = new CRMRepositoryClient(new InstanceContext(Program.CallbackImplementation));
            Thread newThread = new Thread(() =>
            {
                while (_run)
                {
                    client.KeepAlive();
                    Thread.Sleep(5000);
                }
            });
            newThread.Start();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            CustomersForm customersForm = new CustomersForm();
            customersForm.MdiParent = this;
            customersForm.Show();
        }

        private void findTraitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsForm customersForm = new ReportsForm();
            customersForm.MdiParent = this;
            customersForm.Show();
        }

        public void OnSignalArrived(object sender, SignalArgs e)
        {
            if (e.ServerAlive)
            {
                MainForm.counter++;
                signalStatuslabel.Text = $"  server signal# {counter}";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _run = false;
        }
    }
}
