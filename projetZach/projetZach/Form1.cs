﻿using System;
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
        int maxCycle = 0;
        CultureInfo ci;
        String outputPath = "";

        public Form1()
        {
            InitializeComponent();

            graphZach.Series[0].Name = "NewTy";
            graphZach.Series[0].LegendText = "NewTy";

            ci = new CultureInfo("fr-CA");
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
                                      if (colCount == 77 || colCount == 78 || colCount == 79)
                                        {
                                            dt.Columns[colCount].DataType = typeof(Double);
                                        }
                                    }
                                   else
                                   {
                                        decimal dec;
                                        if (Decimal.TryParse(value, out dec))
                                            dt.Rows[lineCount - 1][colCount] = decimal.Parse(value.ToString(), ci ).ToString("G29");
                                        else
                                            dt.Rows[lineCount - 1][colCount] = value;
                                            
                                   }
                                    colCount++;
                                }
                                lineCount++;
                            }
                        }

                        DrawChart(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : Impossible de lire le fichier - Zach tu fais surment quelquechose de pas correct \n" + ex.Message);
                }
            }
        }

        private void DrawChart(DataTable data)
        {
            //code pour le graph
            graphZach.Visible = true;
            
            //dt = getNewTyDataTable(fileName);
            string[] x = new string[dt.Rows.Count];
            double[] y = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                //Calcul le cycle maximum pour afficher les checkbox
                if (Convert.ToInt32(dt.Rows[i][0]) > maxCycle)
                {
                    maxCycle = Convert.ToInt32(dt.Rows[i][0]);
                }
                //Definit les données pour le graphique
                x[i] = dt.Rows[i][0].ToString(); /*decimal.Parse(dt.Rows[i][0].ToString()).ToString("G29")*/;
                y[i] = Convert.ToDouble(dt.Rows[i][78]);
            }
            graphZach.Series[0].Points.DataBindXY(x, y);
            graphZach.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            graphZach.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            graphZach.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            //Affichage des checkbox
            for (var i = 1; i <= maxCycle; i++)
            {
                this.Controls.Find("checkbox" + i, true)[0].Enabled = true;
                ((CheckBox)this.Controls.Find("checkbox" + i, true)[0]).Checked = true;
            }
        }

        private DataTable PutZeros(DataTable data, string[] noCycles)
        {
            DataTable newData = new DataTable();
            newData = data.Copy();

            foreach (DataRow dr in newData.Rows)
            {
                foreach(string noCycle in noCycles)
                {
                    if(dr[0].ToString().Contains(noCycle))
                    {
                        dr[77] = 0;
                        dr[78] = 0;
                        dr[79] = 0;
                    }
                }
            }

            return newData;
        }

        private void ExportToExcel(DataTable data, string nomFichier)
        {
            DataTable newData = new DataTable();

            //Mettre à 0 les cycle que on ignore
            List<String> cycleZeroListe = new List<string>();
            for (var i = 1; i <= maxCycle; i++)
            {
                if (((CheckBox)this.Controls.Find("checkbox" + i, true)[0]).Checked == false)
                {
                    cycleZeroListe.Add(i.ToString());
                }
                
            }
            string[] cycleZeroArray;
            cycleZeroArray = cycleZeroListe.ToArray();

            newData = PutZeros(data, cycleZeroArray);


            string excelFileName = Path.GetFileNameWithoutExtension(nomFichier) + ".xlsx";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;

            //Le bout de code suivant fonctionne fuck all - pas capable faire starté le dialog a la place que je veux
            if (outputPath != "")
            {
                fbd.SelectedPath = outputPath + "\\"; 
            }

            
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                outputPath = fbd.SelectedPath;

                using (ExcelPackage pck = new ExcelPackage(new FileInfo(excelFileName)))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
                    ws.Cells["A1"].LoadFromDataTable(newData, true);
                    pck.SaveAs(new FileInfo(outputPath + "/" + excelFileName));


                    MessageBox.Show("L'exportation est terminé");
                }
            }

            
        }
        

        private void btn_generer_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dt, fileName);

            }
            catch
            (Exception ex)
            {
                MessageBox.Show("Erreur : Une erreur est survenue lors de l'exportation - Envoit un texte à Vince avec un screenshot pour voir \n" + ex.Message);
            }
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


