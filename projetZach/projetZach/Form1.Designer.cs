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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_generer = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnParcourir = new System.Windows.Forms.Button();
            this.graphZach = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.graphZach)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_generer
            // 
            this.btn_generer.Location = new System.Drawing.Point(328, 221);
            this.btn_generer.Name = "btn_generer";
            this.btn_generer.Size = new System.Drawing.Size(75, 23);
            this.btn_generer.TabIndex = 0;
            this.btn_generer.Text = "Generer";
            this.btn_generer.UseVisualStyleBackColor = true;
            this.btn_generer.Click += new System.EventHandler(this.btn_generer_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(12, 24);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(311, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // btnParcourir
            // 
            this.btnParcourir.Location = new System.Drawing.Point(329, 24);
            this.btnParcourir.Name = "btnParcourir";
            this.btnParcourir.Size = new System.Drawing.Size(75, 23);
            this.btnParcourir.TabIndex = 3;
            this.btnParcourir.Text = "Parcourir";
            this.btnParcourir.UseVisualStyleBackColor = true;
            this.btnParcourir.Click += new System.EventHandler(this.btn_parcourir_click);
            // 
            // graphZach
            // 
            chartArea2.Name = "ChartArea1";
            this.graphZach.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.graphZach.Legends.Add(legend2);
            this.graphZach.Location = new System.Drawing.Point(11, 67);
            this.graphZach.Name = "graphZach";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.graphZach.Series.Add(series2);
            this.graphZach.Size = new System.Drawing.Size(490, 139);
            this.graphZach.TabIndex = 4;
            this.graphZach.Text = "graphZach";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 324);
            this.Controls.Add(this.graphZach);
            this.Controls.Add(this.btnParcourir);
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
        private System.Windows.Forms.Button btnParcourir;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphZach;
    }
}

