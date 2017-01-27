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
using System.Globalization;

namespace projetZach
{
    public partial class Form1 : Form
    {
        string fileName = "";
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_parcourir_click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";//mettre directory par defaut de Zach ?
            openFileDialog1.Filter = "Fichier csv(*.csv)|*.csv|Tous les fichiers (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = false;

            List<String> csvLines = new List<String>();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            FileStream fs = myStream as FileStream;
                            fileName = fs.Name;
                            txtFileName.Text = Path.GetFileName(fileName);
                            dt = new DataTable();

                            String csvLine;
                            StreamReader reader = new StreamReader(fileName);
                            while ((csvLine = reader.ReadLine()) != null)
                            {
                                csvLines.Add(csvLine.Replace('.',',')); //change en virgule mais ca fix pas le problème d'affichage a Zach
                            }
                            //On construit le datatable avec le csv
                            int lineCount = 0;
                            foreach (String readerLine in csvLines)
                            {
                                var values = readerLine.Split('\t');
                                if (lineCount != 0)
                                {
                                    dt.Rows.Add();
                                }
                                int colCount = 0;
                                foreach (String value in values)
                                {
                                    //On ajoute les colonnes au DataTable
                                   if (lineCount == 0)
                                    {
                                      dt.Columns.Add(colName(value,dt)); //Fonction recursive qui ajoute des espace a coté du nom de colonne pour évité les 12 millions de doublons. Datatable permet pas de doublons de nom de colonnes
                                    }
                                   else
                                   {
                                        int iValue = 0;
                                        if (int.TryParse(value, out iValue)) //ca marche pas pensé a un moyen de mettre les esti de format comme Zach veut
                                        {
                                            dt.Rows[lineCount - 1][colCount] = iValue;
                                        }
                                        else
                                        {
                                            dt.Rows[lineCount - 1][colCount] = value;
                                        }
                                            
                                   }
                                    colCount++;
                                }
                                lineCount++;
                            }

                            //code pour le graph
                            graphZach.Visible = true;
                            //string query = string.Format("select shipcity, count(orderid) from orders where shipcountry = '{0}' group by shipcity", ddlCountries.SelectedValue);
                            

                            //dt = getNewTyDataTable(fileName);
                            string[] x = new string[dt.Rows.Count];
                            double[] y = new double[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count - 1; i++)
                            {
                                x[i] = dt.Rows[i][0].ToString();
                                y[i] = Convert.ToDouble(dt.Rows[i][78]);
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

        private void ExportToExcel(DataTable data, string nomFichier)
        {
            string excelFileName = Path.GetFileNameWithoutExtension(nomFichier) + ".xlsx";

            String outputPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                outputPath = fbd.SelectedPath;
            }

            using (ExcelPackage pck = new ExcelPackage(new FileInfo(excelFileName)))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
                ws.Cells["A1"].LoadFromDataTable(data, true);
                pck.SaveAs(new FileInfo(outputPath + "/" + excelFileName));
            }
        }
        

        private void btn_generer_Click(object sender, EventArgs e)
        {
            ExportToExcel(dt, fileName);
        }

        private string colName(string value, DataTable data)
        {
            string colonneName = "";

            if (data.Columns.Contains(value))
                colonneName = colName(value + " ", data);
            else
                colonneName = value;

            return colonneName;
        }
    }

}


