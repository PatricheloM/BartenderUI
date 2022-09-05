using System.Data;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;
using BartenderUI.Util.Factories;

namespace BartenderUI.Util
{
    class ExcelFileReader
    {
        public static DataSet GetDataSet()
        {
            DataSet result = new DataSet();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel táblázatok (*.xlsx, *.xls)|*.xlsx;*.xls|Vesszővel elválasztott értékek (*.csv)|*.csv";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = openFileDialog.OpenFile();
                    IExcelDataReader reader;

                    switch (Path.GetExtension(openFileDialog.FileName))
                    {
                        case ".csv":
                            reader = ExcelReaderFactory.CreateCsvReader(stream);
                            result = reader.AsDataSet();
                            reader.Close();
                            stream.Close();
                            break;
                        default:
                            reader = ExcelReaderFactory.CreateReader(stream);
                            result = reader.AsDataSet();
                            reader.Close();
                            stream.Close();
                            break;
                    }
                }
            }

            return result;
        }
    }
}
