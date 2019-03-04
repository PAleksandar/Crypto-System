using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoClient
{
    public partial class CloudClientForm : Form
    {
        private Form1 form1;
        private string _sourcePath;
        public CloudClientForm(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void CloudClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                _sourcePath = fbd.SelectedPath;

                //fileSystemWatcher1.Path = _sourcePath;
            }
        }
    }
}
