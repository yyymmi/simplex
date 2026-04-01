namespace SimplexMethod
{
    partial class SmMetodOne
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvSimplex = new System.Windows.Forms.DataGridView();
            this.colIteration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblFinalResult = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBoxInputData = new System.Windows.Forms.GroupBox();
            this.dgvInputData = new System.Windows.Forms.DataGridView();
            this.lblInputDataTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputData)).BeginInit();
            this.groupBoxInputData.SuspendLayout();
            this.SuspendLayout();

            // dgvSimplex
            this.dgvSimplex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSimplex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimplex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIteration,
            this.colBasis,
            this.colValue,
            this.colX1,
            this.colX2,
            this.colX3,
            this.colX4,
            this.colX5});
            this.dgvSimplex.Location = new System.Drawing.Point(12, 12);
            this.dgvSimplex.Name = "dgvSimplex";
            this.dgvSimplex.ReadOnly = true;
            this.dgvSimplex.Size = new System.Drawing.Size(500, 350);
            this.dgvSimplex.TabIndex = 0;

            // colIteration
            this.colIteration.HeaderText = "Итерация";
            this.colIteration.Name = "colIteration";
            this.colIteration.Width = 70;

            // colBasis
            this.colBasis.HeaderText = "Базис";
            this.colBasis.Name = "colBasis";
            this.colBasis.Width = 60;

            // colValue
            this.colValue.HeaderText = "Значение";
            this.colValue.Name = "colValue";
            this.colValue.Width = 80;

            // colX1
            this.colX1.HeaderText = "x1";
            this.colX1.Name = "colX1";
            this.colX1.Width = 70;

            // colX2
            this.colX2.HeaderText = "x2";
            this.colX2.Name = "colX2";
            this.colX2.Width = 70;

            // colX3
            this.colX3.HeaderText = "x3";
            this.colX3.Name = "colX3";
            this.colX3.Width = 70;

            // colX4
            this.colX4.HeaderText = "x4";
            this.colX4.Name = "colX4";
            this.colX4.Width = 70;

            // colX5
            this.colX5.HeaderText = "x5";
            this.colX5.Name = "colX5";
            this.colX5.Width = 70;

            // lblInputDataTitle
            this.lblInputDataTitle.AutoSize = true;
            this.lblInputDataTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblInputDataTitle.Location = new System.Drawing.Point(520, 12);
            this.lblInputDataTitle.Name = "lblInputDataTitle";
            this.lblInputDataTitle.Size = new System.Drawing.Size(150, 17);
            this.lblInputDataTitle.TabIndex = 4;
            this.lblInputDataTitle.Text = "Исходные данные (Вариант 10)";

            // groupBoxInputData
            this.groupBoxInputData.Location = new System.Drawing.Point(520, 35);
            this.groupBoxInputData.Name = "groupBoxInputData";
            this.groupBoxInputData.Size = new System.Drawing.Size(250, 327);
            this.groupBoxInputData.TabIndex = 5;
            this.groupBoxInputData.TabStop = false;
            this.groupBoxInputData.Text = "Параметры задачи";

            // dgvInputData
            this.dgvInputData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInputData.Location = new System.Drawing.Point(3, 16);
            this.dgvInputData.Name = "dgvInputData";
            this.dgvInputData.ReadOnly = true;
            this.dgvInputData.RowHeadersWidth = 70;
            this.dgvInputData.Size = new System.Drawing.Size(244, 308);
            this.dgvInputData.TabIndex = 0;
            this.groupBoxInputData.Controls.Add(this.dgvInputData);

            // btnCalculate
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.Location = new System.Drawing.Point(12, 368);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(150, 40);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // lblFinalResult
            this.lblFinalResult.AutoSize = true;
            this.lblFinalResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblFinalResult.Location = new System.Drawing.Point(12, 420);
            this.lblFinalResult.Name = "lblFinalResult";
            this.lblFinalResult.Size = new System.Drawing.Size(100, 18);
            this.lblFinalResult.TabIndex = 2;
            this.lblFinalResult.Text = "Результат: ";

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(695, 368);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Назад";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // SmMetodOne
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(780, 450);
            this.MinimumSize = new System.Drawing.Size(780, 450);
            this.MaximizeBox = false;
            this.Controls.Add(this.lblInputDataTitle);
            this.Controls.Add(this.groupBoxInputData);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblFinalResult);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dgvSimplex);
            this.Name = "SmMetodOne";
            this.Text = "Симплекс-метод - Решение задачи линейного программирования";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputData)).EndInit();
            this.groupBoxInputData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvSimplex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIteration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBasis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX5;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblFinalResult;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBoxInputData;
        private System.Windows.Forms.DataGridView dgvInputData;
        private System.Windows.Forms.Label lblInputDataTitle;
    }
}
