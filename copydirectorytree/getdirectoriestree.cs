using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copydirectorytree
{
    class Getdirectoriestree
    {
        //copy directoris tree and save new empty directory

        public void work ()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

             

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                        string destinationpath = @"C:\Users\pandey\Desktop\delet";
                         bool tgle = true;
                         Directorytree.DirectoryCopy(fbd.SelectedPath, destinationpath, tgle);

                   // System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
    }
}
