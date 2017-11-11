using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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


        private bool IsDirectoryName(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            if (attr.HasFlag(FileAttributes.Directory))
                return true;
            else
                return false;
        }

        private void LoadConfigExcel_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files (*.xlsx)|*.xls|All Files (*.*)|*.*";
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
                MessageBox.Show("Select config excel first");
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
                //

                if(IsDirectoryName(source)==false)
                {
                    //message
                    MessageBox.Show("Row Number :" + i.ToString() +"Coloum 1st doesn't contain Directory name");
                    return;
                }
                if (IsDirectoryName(dest) == false)
                {
                    //message
                    MessageBox.Show("Row Number :" + i.ToString() + "Coloum 2nd doesn't contain Directory name");
                    return;
                }
                if (IsDirectoryName(bakp) == false)
                {
                    //message
                    MessageBox.Show("Row Number :" + i.ToString() + "Coloum 3rd doesn't contain Directory name");
                    return;
                }
                //chk if any file in use then return ;
                ChkFilestatus chkst = new ChkFilestatus();
                if(chkst.chk(dest)==false)
                {
                    MessageBox.Show("Some File in Use");
                    return;
                }

                Copyfileswithdirectory obj = new Copyfileswithdirectory();

               string temp =  Path.GetFileName( source);

               string backpfolder = Path.Combine(bakp, temp + "_"+DateTime.Now.ToString("yyyyMMddHHmmss"));


               if (Directory.Exists(backpfolder) == false)
               {
                   Directory.CreateDirectory(backpfolder);
               }
               obj.DirectoryCopywithbak(source, dest, backpfolder);

              
               //ToDo WOrk For SQLS Scripts With ConnString 
               
               //-- chk if connection string is null or we dont have sqls folder 
               using (SqlConnection connection = new SqlConnection(connstring))
               {
                   connection.Open();

                   SqlCommand command = connection.CreateCommand();
                   SqlTransaction transaction;

                   // Start a local transaction.
                   transaction = connection.BeginTransaction("SampleTransaction");

                   // Must assign both transaction object and connection
                   // to Command object for a pending local transaction
                   command.Connection = connection;
                   command.Transaction = transaction;

                   try
                   {
                       string Sqls = Path.Combine(source, "SQLS");
                      
                       string[] sql = Directory.GetFiles(Sqls);
                       foreach (string file in sql)
                       {
                           command.CommandText = File.ReadAllText(file);
                           command.ExecuteNonQuery();
                       }
                       //command.CommandText =
                       //    "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
                       //command.ExecuteNonQuery();
                       //command.CommandText =
                       //    "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
                       //command.ExecuteNonQuery();

                       //// Attempt to commit the transaction.
                       transaction.Commit();
                   
                       //Remove Message Box after Testing 
                       MessageBox.Show("Commited Succesfully");
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show("Commit Exception Type:"+ex.GetType());
                       MessageBox.Show("  Message: {0}", ex.Message);
                       

                       // Attempt to roll back the transaction.
                       try
                       {
                           transaction.Rollback();
                       }
                       catch (Exception ex2)
                       {
                           // This catch block will handle any errors that may have occurred
                           // on the server that would cause the rollback to fail, such as
                           // a closed connection.

                           MessageBox.Show("Rollback Exception Type: "+ex2.GetType());
                           MessageBox.Show("  Message: {0}", ex2.Message);

                         
                       }
                   }
               }


            }

           



            MessageBox.Show("Transfer Completed Succesfully");

        }
    }
}
