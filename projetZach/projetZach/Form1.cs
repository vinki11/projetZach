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
                            Convert_CSV_To_Excel(fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : Impossible de lire le fichier - Zach tu fais surment quelquechose de pas correct /n" + ex.Message);
                }
            }
        }
    

        private void Convert_CSV_To_Excel(string filename)
        {
            /*string csvFileName = @"FL_insurance_sample.csv";
            string excelFileName = @"FL_insurance_sample.xls";*/

            string csvFileName = filename;
            string excelFileName = Path.GetFileNameWithoutExtension(filename) + ".xlsx";

            string worksheetsName = Path.GetFileNameWithoutExtension(filename);

            bool firstRowIsHeader = false;

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
        }

    }
}
