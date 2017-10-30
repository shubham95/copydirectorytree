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
    public partial class LoadConfigExcel : Form
    {
        public LoadConfigExcel()
        {
            InitializeComponent();
        }


        string excelconfig = string.Empty;

        private void LoadConfigExcel_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files (*.xlxs)|*.xls|All Files (*.*)|*.*";
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                excelconfig = ofd.FileName;
                textBox1.Text = excelconfig;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(excelconfig== string.Empty)
            {

                //Message please select configExcel file
                return;

            }

            DataSet ds = new ExcelDataset().excelToDataset(excelconfig);

            DataTable dt = ds.Tables[0];
            string[] columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();


            // coloum matching work

           for(int i=0; i<dt.Rows.Count; i++)
            {
                string source = dt.Rows[i][0].ToString();
                string dest = dt.Rows[i][1].ToString();
                string bakp = dt.Rows[i][2].ToString();
                string connstring = dt.Rows[i][3].ToString();

                Copyfileswithdirectory obj = new Copyfileswithdirectory();
                obj.DirectoryCopywithbak(source, dest, bakp);

            }



        }
    }
}
