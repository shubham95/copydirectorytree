using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Data;
using System.IO;

namespace copydirectorytree
{
    class ExcelDataset
    {
        public DataSet excelToDataset(string filename)
        {
            DataSet result = null;
            FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            if (Path.GetExtension(filename) == "xls")
            {

                //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(fs);
            }
            //...
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            if (Path.GetExtension(filename) == "xlsx")
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            }

            //reader.IsFirstRowAsColumnNames = true;
            result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            return result;
        }
    }
}
