using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Windows.Forms;


namespace projetZach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_parcourir_click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Fichier csv(*.csv)|*.csv|Tous les fichiers (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            FileStream fs = myStream as FileStream;
                            string fileName = "";
                            fileName = fs.Name;
                            txtFileName.Text = Path.GetFileName(fileName);                            

                            //code pour le graph
                            graphZach.Visible = true;
                            //string query = string.Format("select shipcity, count(orderid) from orders where shipcountry = '{0}' group by shipcity", ddlCountries.SelectedValue);
                            DataTable dt = new DataTable();

                            dt = getNewTyDataTable(fileName);
                            string[] x = new string[dt.Rows.Count];
                            int[] y = new int[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count - 1; i++)
                            {
                                x[i] = "Test";
                                y[i] = Convert.ToInt32(dt.Rows[i][1]);
                            }
                            graphZach.Series[0].Points.DataBindXY(x, y);
                            //graphZach.Series[0].ChartType = SeriesChartType.Pie;
                           //graphZach.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                            graphZach.Legends[0].Enabled = true;

                            //Convert_CSV_To_Excel(fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : Impossible de lire le fichier - Zach tu fais surment quelquechose de pas correct \n" + ex.Message);
                }
            }
        }

        private DataTable getNewTyDataTable(string filename)
        {
            string csvFileName = filename;
            string excelFileName = Path.GetFileNameWithoutExtension(filename) + ".xlsx";

            string worksheetsName = Path.GetFileNameWithoutExtension(filename);

            bool firstRowIsHeader = false;
            DataTable dt = new DataTable();
            DataTable dtColonne = new DataTable();

            var format = new ExcelTextFormat();
            format.Delimiter = ',';
            format.EOL = "\r";              // DEFAULT IS "\r\n";
                                            // format.TextQualifier = '"';
                                            /* String outputPath = "";
                                             FolderBrowserDialog fbd = new FolderBrowserDialog();
                                             fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                                             if (fbd.ShowDialog() == DialogResult.OK)
                                             {
                                                 outputPath = fbd.SelectedPath;
                                             }*/

            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFileName)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetsName);
                worksheet.Cells["A1"].LoadFromText(new FileInfo(csvFileName), format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
                /*package.SaveAs(new FileInfo(outputPath + "/" + excelFileName));*/

                dt = GetWorksheetAsDataTable(worksheet);
                //aller chercher la bonne colonne et l'assigner a un dt fix
                dtColonne.Columns.Add(dt.Columns[0].ColumnName, dt.Columns[0].DataType);
                dtColonne.Columns.Add(dt.Columns[1].ColumnName, dt.Columns[1].DataType); //mettre 53 ici une fois avec les vrai données

                //Boucler dans toute les rows et lui assigner la valeur a la place NewTy
                foreach (DataRow datarow in dt.Rows)
                {
                    dtColonne.Rows.Add(datarow[0],datarow[1]);
                }

            }

            return dtColonne;

        }

        private void Convert_CSV_To_Excel(string filename)
        {
            /*string csvFileName = @"FL_insurance_sample.csv";
            string excelFileName = @"FL_insurance_sample.xls";*/

            string csvFileName = filename;
            string excelFileName = Path.GetFileNameWithoutExtension(filename) + ".xlsx";

            string worksheetsName = Path.GetFileNameWithoutExtension(filename);

            bool firstRowIsHeader = false;
            DataTable dt = new DataTable();
            DataTable dtColonne = new DataTable();

            var format = new ExcelTextFormat();
            format.Delimiter = ',';
            format.EOL = "\r";              // DEFAULT IS "\r\n";
                                            // format.TextQualifier = '"';
            String outputPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                outputPath = fbd.SelectedPath;
            }

            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFileName)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetsName);
                worksheet.Cells["A1"].LoadFromText(new FileInfo(csvFileName), format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
                package.SaveAs(new FileInfo(outputPath + "/" + excelFileName));

            }


            /*Console.WriteLine("Finished!");
            Console.ReadLine();*/

            //http://stackoverflow.com/questions/29976752/create-excel-graph-with-epplus
        }

        public static DataTable GetWorksheetAsDataTable(ExcelWorksheet worksheet)
        {
            var dt = new DataTable(worksheet.Name);
            dt.Columns.AddRange(GetDataColumns(worksheet).ToArray());
            var headerOffset = 1; //have to skip header row
            var width = dt.Columns.Count;
            var depth = GetTableDepth(worksheet, headerOffset);
            for (var i = 1; i <= depth; i++)
            {
                var row = dt.NewRow();
                for (var j = 1; j <= width; j++)
                {
                    var currentValue = worksheet.Cells[i + headerOffset, j].Value;

                    //have to decrement b/c excel is 1 based and datatable is 0 based.
                    row[j - 1] = currentValue == null ? null : currentValue.ToString();
                }

                dt.Rows.Add(row);
            }

            return dt;
        }

        private static int GetTableDepth(ExcelWorksheet worksheet, int headerOffset)
        {
            var i = 1;
            var j = 1;
            var cellValue = worksheet.Cells[i + headerOffset, j].Value;
            while (cellValue != null)
            {
                i++;
                cellValue = worksheet.Cells[i + headerOffset, j].Value;
            }

            return i - 1; //subtract one because we're going from rownumber (1 based) to depth (0 based)
        }

        private static IEnumerable<DataColumn> GetDataColumns(ExcelWorksheet worksheet)
        {
            return GatherColumnNames(worksheet).Select(x => new DataColumn(x));
        }

        private static IEnumerable<string> GatherColumnNames(ExcelWorksheet worksheet)
        {
            var columns = new List<string>();

            var i = 1;
            var j = 1;
            var columnName = worksheet.Cells[i, j].Value;
            while (columnName != null)
            {
                columns.Add(GetUniqueColumnName(columns, columnName.ToString()));
                j++;
                columnName = worksheet.Cells[i, j].Value;
            }

            return columns;
        }

        private static string GetUniqueColumnName(IEnumerable<string> columnNames, string columnName)
        {
            var colName = columnName;
            var i = 1;
            while (columnNames.Contains(colName))
            {
                colName = columnName + i.ToString();
                i++;
            }

            return colName;
        }

    }

}


