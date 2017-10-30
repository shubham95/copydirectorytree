using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copydirectorytree
{
    public partial class GenrateDirectoryTree : Form
    {
        public GenrateDirectoryTree()
        {
            InitializeComponent();
        }

        private void GenrateDirectoryTree_Load(object sender, EventArgs e)
        {
            sourceDirectory.Enabled = false;
            destDirectory.Enabled = false;
        }

        string SourceDirectory = string.Empty;
        string DestinationDirectory = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SourceDirectory = fbd.SelectedPath.ToString();
                    sourceDirectory.Text = SourceDirectory;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    DestinationDirectory = fbd.SelectedPath.ToString();
                    destDirectory.Text = DestinationDirectory;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if
            if(SourceDirectory==string.Empty)
            {
                //Message Box and Return
                return;
            }

            if (DestinationDirectory == string.Empty)
            {
                //Message Box and Return
                return;
            }

            Directorytree.DirectoryCopy(SourceDirectory,DestinationDirectory,true);

            // Message Box directoryTree generated
        }
    }
}
