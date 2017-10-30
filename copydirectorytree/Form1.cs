using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copydirectorytree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenrateDirectoryTree obj = new GenrateDirectoryTree();
            obj.Show();



            //Getdirectoriestree obj = new Getdirectoriestree();
            //obj.work();
            //Copyfileswithdirectory obj2 = new Copyfileswithdirectory();

            //string sourcefoldername= @"C:\Users\pandey\Desktop\testto";
            //string destfoldername= @"C:\Users\pandey\Desktop\delet";
            //string backfoldername= @"C:\Users\pandey\Desktop\bak";

            //obj2.DirectoryCopywithbak(sourcefoldername,destfoldername,backfoldername);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new LoadConfigExcel().Show();
        }
    }
}
