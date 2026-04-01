using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexMethod
{
    public partial class SmMetodOne : Form
    {
        public SmMetodOne()
        {
            InitializeComponent();
        }

        // НЕИЗМЕНЯЕМЫЕ ИСХОДНЫЕ ДАННЫЕ (Вариант 10)
        private readonly double[,] constraintMatrix = new double[,]
        {
            { 1.0, 0.1, 1, 0, 0, 21 },    // 1.0*x1 + 0.1*x2 + 1*x3 = 21
            { 0.1, 1.0, 0, 1, 0, 19 },    // 0.1*x1 + 1.0*x2 + 1*x4 = 19
            { 0.4, 0.1, 0, 0, 1, 12 }     // 0.4*x1 + 0.1*x2 + 1*x5 = 12
        };

        private readonly double[] objectiveCoefficients = { 45, 55 };  // F = 45*x1 + 55*x2
        private double[,] simplexTable;
        private Main mainForm;

        public SmMetodOne(Main form)
        {
            InitializeComponent();
            mainForm = form;

            if (!DesignMode)
            {
                DisplayInputData();
                SetupInterface();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
 
        }

        private void InitializeSimplexTable()
        {
            // Создать симплекс-таблицу: 4 строки (целевая + 3 ограничения), 6 столбцов (5 переменных + RHS)
            simplexTable = new double[4, 6];

            // Строка целевой функции: -F = -45*x1 - 55*x2
            simplexTable[0, 0] = -objectiveCoefficients[0];
            simplexTable[0, 1] = -objectiveCoefficients[1];
            simplexTable[0, 2] = 0;
            simplexTable[0, 3] = 0;
            simplexTable[0, 4] = 0;
            simplexTable[0, 5] = 0;

            // Скопировать ограничения
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    simplexTable[i + 1, j] = constraintMatrix[i, j];
                }
            }
        }

        private void DisplayIteration(int iteration)
        {
            // Добавить разделительную строку между итерациями
            if (iteration > 0)
            {
                int rowIndex = dgvSimplex.Rows.Add();
                DataGridViewRow separatorRow = dgvSimplex.Rows[rowIndex];
                separatorRow.DefaultCellStyle.BackColor = Color.LightGray;
            }

            // Получить текущие имена базисных переменных
            string[] basisNames = GetCurrentBasisNames();

            // Маппинг: индекс отображения -> индекс в simplexTable
            int[] tableRowIndices = { 1, 2, 3, 0 };  // x3, x4, x5, -F
            string[] displayBasisNames = { basisNames[0], basisNames[1], basisNames[2], "-F" };

            // Добавить 4 строки для текущей итерации
            for (int i = 0; i < 4; i++)
            {
                int tableRowIndex = tableRowIndices[i];
                int rowIndex = dgvSimplex.Rows.Add();
                DataGridViewRow row = dgvSimplex.Rows[rowIndex];

                // Столбец 0: Итерация
                row.Cells["colIteration"].Value = iteration;

                // Столбец 1: Базис (динамический)
                row.Cells["colBasis"].Value = displayBasisNames[i];

                // Столбец 2: Значение (RHS) - всегда столбец 5
                row.Cells["colValue"].Value = simplexTable[tableRowIndex, 5].ToString("F4");

                // Столбцы 3-7: Переменные x1-x5 (столбцы 0-4 из simplexTable)
                for (int j = 0; j < 5; j++)
                {
                    row.Cells[3 + j].Value = simplexTable[tableRowIndex, j].ToString("F4");
                }

                // Подсветить строку -F
                if (i == 3)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    row.DefaultCellStyle.Font = new Font(dgvSimplex.Font, FontStyle.Bold);
                }
            }
        }

        private string[] GetCurrentBasisNames()
        {
            // Определить, какие переменные находятся в базисе
            string[] basisNames = new string[3];

            // Начальный базис
            basisNames[0] = "x3";
            basisNames[1] = "x4";
            basisNames[2] = "x5";

            // Проверить, находится ли x1 в базисе
            bool x1IsBasic = IsVariableBasic(0);
            if (x1IsBasic)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (basisNames[i] == "x3" || basisNames[i] == "x4" || basisNames[i] == "x5")
                    {
                        basisNames[i] = "x1";
                        break;
                    }
                }
            }

            // Проверить, находится ли x2 в базисе
            bool x2IsBasic = IsVariableBasic(1);
            if (x2IsBasic)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (basisNames[i] == "x3" || basisNames[i] == "x4" || basisNames[i] == "x5")
                    {
                        basisNames[i] = "x2";
                        break;
                    }
                }
            }

            return basisNames;
        }

        private bool IsVariableBasic(int varIndex)
        {
            // Проверить, является ли переменная в столбце базисной (ровно одна 1 и остальные 0)
            int oneCount = 0;
            int oneRowIndex = -1;

            for (int i = 1; i < 4; i++)
            {
                if (Math.Abs(simplexTable[i, varIndex] - 1.0) < 1e-10)
                {
                    oneCount++;
                    oneRowIndex = i;
                }
                else if (Math.Abs(simplexTable[i, varIndex]) > 1e-10)
                {
                    return false;
                }
            }

            return oneCount == 1;
        }

        private bool IsOptimal()
        {
            // Проверить, есть ли отрицательные коэффициенты в строке целевой функции (кроме RHS)
            for (int j = 0; j < 5; j++)
            {
                if (simplexTable[0, j] < -1e-10)
                    return false;
            }
            return true;
        }

        private int FindPivotColumn()
        {
            int pivotCol = -1;
            double minValue = -1e-10;

            // Найти столбец с наибольшим отрицательным коэффициентом
            for (int j = 0; j < 5; j++)
            {
                if (simplexTable[0, j] < minValue)
                {
                    minValue = simplexTable[0, j];
                    pivotCol = j;
                }
            }

            return pivotCol;
        }

        private int FindPivotRow(int pivotCol)
        {
            int pivotRow = -1;
            double minRatio = double.MaxValue;

            // Найти строку с минимальным положительным отношением: RHS / коэффициент столбца
            for (int i = 1; i < 4; i++)
            {
                if (simplexTable[i, pivotCol] > 1e-10)
                {
                    double ratio = simplexTable[i, 5] / simplexTable[i, pivotCol];
                    if (ratio >= 0 && ratio < minRatio)
                    {
                        minRatio = ratio;
                        pivotRow = i;
                    }
                }
            }

            return pivotRow;
        }

        private void PerformGaussianElimination(int pivotRow, int pivotCol)
        {
            double pivotElement = simplexTable[pivotRow, pivotCol];

            // Нормализовать разрешающую строку
            for (int j = 0; j < 6; j++)
            {
                simplexTable[pivotRow, j] /= pivotElement;
            }

            // Исключить разрешающий столбец из остальных строк
            for (int i = 0; i < 4; i++)
            {
                if (i != pivotRow)
                {
                    double factor = simplexTable[i, pivotCol];
                    for (int j = 0; j < 6; j++)
                    {
                        simplexTable[i, j] -= factor * simplexTable[pivotRow, j];
                    }
                }
            }
        }

        private void ExtractSolution()
        {
            double x1 = 0, x2 = 0;
            double maxProfit = simplexTable[0, 5];

            // Найти x1 (базисная переменная в столбце 0)
            for (int i = 1; i < 4; i++)
            {
                if (Math.Abs(simplexTable[i, 0] - 1) < 1e-10)
                {
                    bool isBasic = true;
                    for (int k = 1; k < 4; k++)
                    {
                        if (k != i && Math.Abs(simplexTable[k, 0]) > 1e-10)
                        {
                            isBasic = false;
                            break;
                        }
                    }
                    if (isBasic)
                    {
                        x1 = simplexTable[i, 5];
                        break;
                    }
                }
            }

            // Найти x2 (базисная переменная в столбце 1)
            for (int i = 1; i < 4; i++)
            {
                if (Math.Abs(simplexTable[i, 1] - 1) < 1e-10)
                {
                    bool isBasic = true;
                    for (int k = 1; k < 4; k++)
                    {
                        if (k != i && Math.Abs(simplexTable[k, 1]) > 1e-10)
                        {
                            isBasic = false;
                            break;
                        }
                    }
                    if (isBasic)
                    {
                        x2 = simplexTable[i, 5];
                        break;
                    }
                }
            }

            // Вывести результат
            lblFinalResult.Text = $"Результат: x₁ = {x1:F2}, x₂ = {x2:F2}, F_макс = {maxProfit:F2}";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (mainForm != null)
                mainForm.Show();

            this.Close();
        }

        private void DisplayInputData()
        {
            // Очистить таблицу исходных данных
            dgvInputData.Rows.Clear();
            dgvInputData.Columns.Clear();

            // Создать структуру таблицы исходных данных
            dgvInputData.Columns.Add("colParameter", "Параметр");
            dgvInputData.Columns.Add("colValue", "Значение");
            dgvInputData.Columns[0].Width = 100;
            dgvInputData.Columns[1].Width = 120;

            // Добавить данные матрицы A
            dgvInputData.Rows.Add("Матрица A:", "");
            dgvInputData.Rows.Add("a₁₁", constraintMatrix[0, 0].ToString("F1"));
            dgvInputData.Rows.Add("a₁₂", constraintMatrix[0, 1].ToString("F1"));
            dgvInputData.Rows.Add("a₂₁", constraintMatrix[1, 0].ToString("F1"));
            dgvInputData.Rows.Add("a₂₂", constraintMatrix[1, 1].ToString("F1"));
            dgvInputData.Rows.Add("a₃₁", constraintMatrix[2, 0].ToString("F1"));
            dgvInputData.Rows.Add("a₃₂", constraintMatrix[2, 1].ToString("F1"));

            // Добавить данные вектора b (ресурсы)
            dgvInputData.Rows.Add("Ресурсы (b):", "");
            dgvInputData.Rows.Add("b₁", constraintMatrix[0, 5].ToString("F0"));
            dgvInputData.Rows.Add("b₂", constraintMatrix[1, 5].ToString("F0"));
            dgvInputData.Rows.Add("b₃", constraintMatrix[2, 5].ToString("F0"));

            // Добавить коэффициенты целевой функции
            dgvInputData.Rows.Add("Целевая функция (c):", "");
            dgvInputData.Rows.Add("c₁", objectiveCoefficients[0].ToString("F0"));
            dgvInputData.Rows.Add("c₂", objectiveCoefficients[1].ToString("F0"));

            // Добавить функцию
            dgvInputData.Rows.Add("", "");
            dgvInputData.Rows.Add("F = 45x₁ + 55x₂ → max", "");
        }

        private void SetupInterface()
        {
            if (dgvSimplex.Columns.Count == 0)
                return;
            // Конфигурация формы: запрет растягивания
            this.AutoScroll = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // Конфигурация dgvSimplex
            dgvSimplex.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSimplex.AllowUserToResizeColumns = false;
            dgvSimplex.AllowUserToResizeRows = false;
            dgvSimplex.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSimplex.RowHeadersVisible = false;
            dgvSimplex.AllowUserToAddRows = false;
            dgvSimplex.ScrollBars = ScrollBars.None;
            dgvSimplex.AutoSize = false;
            dgvSimplex.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvSimplex.CurrentCell = null;
            dgvSimplex.EnableHeadersVisualStyles = false;

            // Выравнивание ячеек в dgvSimplex
            // Столбцы текста (Итерация, Базис) - выравнивание по центру
            dgvSimplex.Columns["colIteration"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSimplex.Columns["colBasis"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Числовые столбцы (Value, x1-x5) - выравнивание по центру
            dgvSimplex.Columns["colValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSimplex.Columns["colX1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSimplex.Columns["colX2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSimplex.Columns["colX3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSimplex.Columns["colX4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSimplex.Columns["colX5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Выравнивание заголовков столбцов по центру
            dgvSimplex.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Конфигурация dgvInputData
            dgvInputData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInputData.AllowUserToResizeColumns = false;
            dgvInputData.AllowUserToResizeRows = false;
            dgvInputData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvInputData.RowHeadersVisible = false;
            dgvInputData.AllowUserToAddRows = false;
            dgvInputData.ScrollBars = ScrollBars.None;
            dgvInputData.AutoSize = false;
            dgvInputData.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvInputData.CurrentCell = null;
            dgvInputData.EnableHeadersVisualStyles = false;

            // Выравнивание ячеек в dgvInputData
            dgvInputData.Columns["colParameter"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvInputData.Columns["colValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInputData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Фиксация размера контейнера исходных данных
            groupBoxInputData.MaximumSize = groupBoxInputData.Size;
            groupBoxInputData.MinimumSize = groupBoxInputData.Size;
            groupBoxInputData.AutoSize = false;

            // Запрет получения фокуса таблицами
            dgvSimplex.GotFocus += (s, e) => { btnCalculate.Focus(); };
            dgvInputData.GotFocus += (s, e) => { btnCalculate.Focus(); };
        }
    }
}
