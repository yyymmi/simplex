using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimplexMethod
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load); // Подключаем обработчик события Load
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Начальные значения коэффициентов целевой функции
            textBoxC1.Text = "55";
            textBoxC2.Text = "70";

            // Начальные значения ограничений
            textBox1.Text = "0,9";  // a1_b1
            textBox4.Text = "0,3";  // a2_b1
            textBox7.Text = "38";   // b_b1

            textBox2.Text = "0,4";  // a1_b2
            textBox5.Text = "0,7";  // a2_b2
            textBox8.Text = "29";   // b_b2

            textBox3.Text = "0,4";  // a1_b3
            textBox6.Text = "0,8";  // a2_b3
            textBox9.Text = "21";   // b_b3
        }

        private void buttonOptimize_Click(object sender, EventArgs e)
        {
            // Парсим коэффициенты целевой функции
            double c1 = double.Parse(textBoxC1.Text);
            double c2 = double.Parse(textBoxC2.Text);

            // Парсим значения ограничений
            double a1_b1 = double.Parse(textBox1.Text);
            double a2_b1 = double.Parse(textBox4.Text);
            double b_b1 = double.Parse(textBox7.Text);

            double a1_b2 = double.Parse(textBox2.Text);
            double a2_b2 = double.Parse(textBox5.Text);
            double b_b2 = double.Parse(textBox8.Text);

            double a1_b3 = double.Parse(textBox3.Text);
            double a2_b3 = double.Parse(textBox6.Text);
            double b_b3 = double.Parse(textBox9.Text);

            // Коэффициенты ограничений
            double[,] A = { { a1_b1, a2_b1 }, { a1_b2, a2_b2 }, { a1_b3, a2_b3 } };
            double[] b = { b_b1, b_b2, b_b3 };

            // Находим оптимальное решение (методом полного перебора)
            double bestProfit = double.NegativeInfinity;
            double bestX1 = 0, bestX2 = 0;

            // Увеличиваем шаги для повышения точности
            double step = 0.01;

            for (double x1 = 0; x1 <= 120; x1 += step)
            {
                for (double x2 = 0; x2 <= 120; x2 += step)
                {
                    bool satisfies = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (A[i, 0] * x1 + A[i, 1] * x2 > b[i])
                        {
                            satisfies = false;
                            break;
                        }
                    }

                    if (satisfies)
                    {
                        double profit = c1 * x1 + c2 * x2;
                        if (profit > bestProfit)
                        {
                            bestProfit = profit;
                            bestX1 = x1;
                            bestX2 = x2;
                        }
                    }
                }
            }

            // Обновляем график
            chart.Series.Clear();

            // Добавляем линии ограничений
            var constraintSeries = new Series[3];
            for (int i = 0; i < 3; i++)
            {
                constraintSeries[i] = new Series
                {
                    Name = $"Constraint {i + 1}",
                    Color = Color.DarkBlue,
                    ChartType = SeriesChartType.Line
                };

                for (double x1 = 0; x1 <= 120; x1 += step)
                {
                    double x2 = (b[i] - A[i, 0] * x1) / A[i, 1];
                    constraintSeries[i].Points.AddXY(x1, x2);
                }

                chart.Series.Add(constraintSeries[i]);
            }


            // Добавляем точку оптимального решения
            var optimalSolutionSeries = new Series
            {
                Name = "Optimal Solution",
                Color = Color.Red,
                ChartType = SeriesChartType.Point
            };
            optimalSolutionSeries.Points.AddXY(bestX1, bestX2);
            chart.Series.Add(optimalSolutionSeries);

            // Показываем информацию об оптимальном решении
            labelResult.Text = $"Optimal Solution: (x1, x2) = ({bestX1:F2}, {bestX2:F2}), Profit = {bestProfit:F2}";
        }
    }
}
