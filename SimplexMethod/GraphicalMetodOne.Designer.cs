namespace SimplexMethod
{
    partial class GraphicalMetodOne
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
            this.chartOptimization = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelResults = new System.Windows.Forms.Panel();
            this.lblMaxProfit = new System.Windows.Forms.Label();
            this.lblResultX2 = new System.Windows.Forms.Label();
            this.lblResultX1 = new System.Windows.Forms.Label();
            this.lblObjectiveFunction = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartOptimization)).BeginInit();
            this.panelResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartOptimization
            // 
            chartArea1.Name = "ChartArea1";
            this.chartOptimization.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOptimization.Legends.Add(legend1);
            this.chartOptimization.Location = new System.Drawing.Point(12, 12);
            this.chartOptimization.Name = "chartOptimization";
            this.chartOptimization.Size = new System.Drawing.Size(550, 400);
            this.chartOptimization.TabIndex = 0;
            this.chartOptimization.Text = "chartOptimization";
            // 
            // panelResults
            // 
            this.panelResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResults.Controls.Add(this.lblMaxProfit);
            this.panelResults.Controls.Add(this.lblResultX2);
            this.panelResults.Controls.Add(this.lblResultX1);
            this.panelResults.Controls.Add(this.lblObjectiveFunction);
            this.panelResults.Location = new System.Drawing.Point(568, 12);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(220, 350);
            this.panelResults.TabIndex = 1;
            // 
            // lblMaxProfit
            // 
            this.lblMaxProfit.AutoSize = true;
            this.lblMaxProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxProfit.Location = new System.Drawing.Point(10, 190);
            this.lblMaxProfit.Name = "lblMaxProfit";
            this.lblMaxProfit.Size = new System.Drawing.Size(135, 17);
            this.lblMaxProfit.TabIndex = 3;
            this.lblMaxProfit.Text = "Макс. прибыль: -";
            // 
            // lblResultX2
            // 
            this.lblResultX2.AutoSize = true;
            this.lblResultX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultX2.Location = new System.Drawing.Point(10, 150);
            this.lblResultX2.Name = "lblResultX2";
            this.lblResultX2.Size = new System.Drawing.Size(40, 17);
            this.lblResultX2.TabIndex = 2;
            this.lblResultX2.Text = "x₂ = -";
            // 
            // lblResultX1
            // 
            this.lblResultX1.AutoSize = true;
            this.lblResultX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultX1.Location = new System.Drawing.Point(10, 125);
            this.lblResultX1.Name = "lblResultX1";
            this.lblResultX1.Size = new System.Drawing.Size(40, 17);
            this.lblResultX1.TabIndex = 1;
            this.lblResultX1.Text = "x₁ = -";
            // 
            // lblObjectiveFunction
            // 
            this.lblObjectiveFunction.AutoSize = true;
            this.lblObjectiveFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjectiveFunction.Location = new System.Drawing.Point(10, 10);
            this.lblObjectiveFunction.Name = "lblObjectiveFunction";
            this.lblObjectiveFunction.Size = new System.Drawing.Size(151, 75);
            this.lblObjectiveFunction.TabIndex = 0;
            this.lblObjectiveFunction.Text = "F = 45x₁ + 55x₂ → max\r\nОграничения:\r\n1.0x₁ + 0.1x₂ ≤ 21\r\n0.1x₁ + 1.0x₂ ≤ 19\r\n0.4x" +
    "₁ + 0.1x₂ ≤ 12";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(568, 270);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(220, 40);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Расчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.Location = new System.Drawing.Point(568, 372);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(220, 40);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Назад";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // GraphicalMetodOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.panelResults);
            this.Controls.Add(this.chartOptimization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "GraphicalMetodOne";
            this.Text = "Графический метод решения ЗЛП";
            ((System.ComponentModel.ISupportInitialize)(this.chartOptimization)).EndInit();
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartOptimization;
        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.Label lblObjectiveFunction;
        private System.Windows.Forms.Label lblResultX1;
        private System.Windows.Forms.Label lblResultX2;
        private System.Windows.Forms.Label lblMaxProfit;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button BtnExit;
    }
}