namespace projetZach
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_generer = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnParcourirFichier = new System.Windows.Forms.Button();
            this.graphZach = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnParcourirPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graphZach)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_generer
            // 
            this.btn_generer.Location = new System.Drawing.Point(1053, 519);
            this.btn_generer.Name = "btn_generer";
            this.btn_generer.Size = new System.Drawing.Size(75, 23);
            this.btn_generer.TabIndex = 0;
            this.btn_generer.Text = "Generer";
            this.btn_generer.UseVisualStyleBackColor = true;
            this.btn_generer.Click += new System.EventHandler(this.btn_generer_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(176, 24);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(871, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // btnParcourirFichier
            // 
            this.btnParcourirFichier.Location = new System.Drawing.Point(1053, 24);
            this.btnParcourirFichier.Name = "btnParcourirFichier";
            this.btnParcourirFichier.Size = new System.Drawing.Size(75, 23);
            this.btnParcourirFichier.TabIndex = 3;
            this.btnParcourirFichier.Text = "Parcourir";
            this.btnParcourirFichier.UseVisualStyleBackColor = true;
            this.btnParcourirFichier.Click += new System.EventHandler(this.btn_parcourir_file_click);
            // 
            // graphZach
            // 
            chartArea1.Name = "ChartArea1";
            this.graphZach.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graphZach.Legends.Add(legend1);
            this.graphZach.Location = new System.Drawing.Point(36, 80);
            this.graphZach.Name = "graphZach";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graphZach.Series.Add(series1);
            this.graphZach.Size = new System.Drawing.Size(1092, 421);
            this.graphZach.TabIndex = 4;
            this.graphZach.Text = "graphZach";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(138, 519);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(32, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(200, 519);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(32, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(262, 519);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(32, 17);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(324, 519);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(32, 17);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(386, 519);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(32, 17);
            this.checkBox5.TabIndex = 9;
            this.checkBox5.Text = "5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(448, 519);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(32, 17);
            this.checkBox6.TabIndex = 10;
            this.checkBox6.Text = "6";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox7.Enabled = false;
            this.checkBox7.Location = new System.Drawing.Point(510, 519);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(32, 17);
            this.checkBox7.TabIndex = 11;
            this.checkBox7.Text = "7";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox8.Enabled = false;
            this.checkBox8.Location = new System.Drawing.Point(572, 519);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(32, 17);
            this.checkBox8.TabIndex = 12;
            this.checkBox8.Text = "8";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox9.Enabled = false;
            this.checkBox9.Location = new System.Drawing.Point(634, 519);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(32, 17);
            this.checkBox9.TabIndex = 13;
            this.checkBox9.Text = "9";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox10.Enabled = false;
            this.checkBox10.Location = new System.Drawing.Point(696, 519);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(38, 17);
            this.checkBox10.TabIndex = 14;
            this.checkBox10.Text = "10";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox11.Enabled = false;
            this.checkBox11.Location = new System.Drawing.Point(764, 519);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(38, 17);
            this.checkBox11.TabIndex = 15;
            this.checkBox11.Text = "11";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox12.Enabled = false;
            this.checkBox12.Location = new System.Drawing.Point(832, 519);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(38, 17);
            this.checkBox12.TabIndex = 16;
            this.checkBox12.Text = "12";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox13.Enabled = false;
            this.checkBox13.Location = new System.Drawing.Point(900, 519);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(38, 17);
            this.checkBox13.TabIndex = 17;
            this.checkBox13.Text = "13";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(176, 50);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(871, 20);
            this.txtOutputPath.TabIndex = 18;
            // 
            // btnParcourirPath
            // 
            this.btnParcourirPath.Location = new System.Drawing.Point(1053, 48);
            this.btnParcourirPath.Name = "btnParcourirPath";
            this.btnParcourirPath.Size = new System.Drawing.Size(75, 23);
            this.btnParcourirPath.TabIndex = 19;
            this.btnParcourirPath.Text = "Parcourir";
            this.btnParcourirPath.UseVisualStyleBackColor = true;
            this.btnParcourirPath.Click += new System.EventHandler(this.btnParcourirPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Fichier importé :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Chemin d\'exportation :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 568);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnParcourirPath);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.checkBox13);
            this.Controls.Add(this.checkBox12);
            this.Controls.Add(this.checkBox11);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.graphZach);
            this.Controls.Add(this.btnParcourirFichier);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btn_generer);
            this.Name = "Form1";
            this.Text = "Generateur";
            ((System.ComponentModel.ISupportInitialize)(this.graphZach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_generer;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnParcourirFichier;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphZach;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnParcourirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

