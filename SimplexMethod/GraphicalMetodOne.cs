using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimplexMethod
{
    public partial class GraphicalMetodOne : Form
    {
        Main mainForm;

        // Коэффициенты задачи (Вариант 10)
        private readonly double C1 = 45;      // Коэффициент при x1 в целевой функции
        private readonly double C2 = 55;      // Коэффициент при x2 в целевой функции

        // Ограничение 1: 1.0*x1 + 0.1*x2 <= 21
        private readonly double A11 = 1.0;
        private readonly double A12 = 0.1;
        private readonly double B1 = 21;

        // Ограничение 2: 0.1*x1 + 1.0*x2 <= 19
        private readonly double A21 = 0.1;
        private readonly double A22 = 1.0;
        private readonly double B2 = 19;

        // Ограничение 3: 0.4*x1 + 0.1*x2 <= 12
        private readonly double A31 = 0.4;
        private readonly double A32 = 0.1;
        private readonly double B3 = 12;

        private List<Point2D> vertices = new List<Point2D>();
        private Point2D optimalPoint;
        private double maxProfit;

        public GraphicalMetodOne(Main form)
        {
            InitializeComponent();
            mainForm = form;
            InitializeChart();
        }

        private void InitializeChart()
        {
            var chart = chartOptimization;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 30;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 25;
            chart.ChartAreas[0].AxisX.Title = "x₁";
            chart.ChartAreas[0].AxisY.Title = "x₂";

            // Запрет изменения размера окна
            this.AutoScroll = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            chartOptimization.Series.Clear();
            vertices.Clear();

            // Найти все возможные вершины (точки пересечения)
            FindVertices();

            // Найти оптимальное решение
            FindOptimalSolution();

            // Визуализировать результаты
            DrawConstraints();
            DrawFeasibleRegion();
            DrawGradient();
            DrawOptimalPoint();

            // Вывести результаты
            DisplayResults();
        }

        private void FindVertices()
        {
            var vertexSet = new HashSet<Point2D>();

            // Начало координат (0, 0)
            vertexSet.Add(new Point2D(0, 0));

            // Пересечения с осями координат
            TryAddVertex(vertexSet, B1 / A11, 0);
            TryAddVertex(vertexSet, 0, B1 / A12);
            TryAddVertex(vertexSet, B2 / A21, 0);
            TryAddVertex(vertexSet, 0, B2 / A22);
            TryAddVertex(vertexSet, B3 / A31, 0);
            TryAddVertex(vertexSet, 0, B3 / A32);

            // Пересечения ограничений между собой
            var p = FindIntersection(A11, A12, B1, A21, A22, B2);
            if (p != null && IsPointFeasible(p.X, p.Y))
                vertexSet.Add(p);

            p = FindIntersection(A11, A12, B1, A31, A32, B3);
            if (p != null && IsPointFeasible(p.X, p.Y))
                vertexSet.Add(p);

            p = FindIntersection(A21, A22, B2, A31, A32, B3);
            if (p != null && IsPointFeasible(p.X, p.Y))
                vertexSet.Add(p);

            vertices = vertexSet.ToList();
        }

        private void TryAddVertex(HashSet<Point2D> vertexSet, double x1, double x2)
        {
            if (x1 >= 0 && IsPointFeasible(x1, x2))
                vertexSet.Add(new Point2D(x1, x2));
        }

        private Point2D FindIntersection(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            double det = a1 * b2 - a2 * b1;
            if (Math.Abs(det) < 1e-10)
                return null;

            double x = (c1 * b2 - c2 * b1) / det;
            double y = (a1 * c2 - a2 * c1) / det;

            if (x >= -1e-10 && y >= -1e-10)
                return new Point2D(x, y);

            return null;
        }

        private bool IsPointFeasible(double x1, double x2)
        {
            return A11 * x1 + A12 * x2 <= B1 + 1e-10 &&
                   A21 * x1 + A22 * x2 <= B2 + 1e-10 &&
                   A31 * x1 + A32 * x2 <= B3 + 1e-10 &&
                   x1 >= -1e-10 &&
                   x2 >= -1e-10;
        }

        private void FindOptimalSolution()
        {
            maxProfit = double.MinValue;
            optimalPoint = null;

            foreach (var vertex in vertices)
            {
                double f = C1 * vertex.X + C2 * vertex.Y;
                if (f > maxProfit)
                {
                    maxProfit = f;
                    optimalPoint = vertex;
                }
            }
        }

        private void DrawConstraints()
        {
            var series1 = new Series("Огр. 1: 1.0x₁ + 0.1x₂ ≤ 21  (= 21)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 3,
                IsVisibleInLegend = true
            };

            var series2 = new Series("Огр. 2: 0.1x₁ + 1.0x₂ ≤ 19  (= 19)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Green,
                BorderWidth = 3,
                IsVisibleInLegend = true
            };

            var series3 = new Series("Огр. 3: 0.4x₁ + 0.1x₂ ≤ 12  (= 12)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Blue,
                BorderWidth = 3,
                IsVisibleInLegend = true
            };

            // Ограничение 1: x2 = (B1 - A11*x1) / A12, от x1=0 до x1=30
            for (double x1 = 0; x1 <= 30; x1 += 0.5)
            {
                double x2 = (B1 - A11 * x1) / A12;
                // Учитываем границы графика [0, 30] x [0, 25]
                if (x2 >= -1 && x2 <= 26)
                    series1.Points.AddXY(x1, x2);
            }

            // Ограничение 2: x2 = (B2 - A21*x1) / A22, от x1=0 до x1=30
            for (double x1 = 0; x1 <= 30; x1 += 0.5)
            {
                double x2 = (B2 - A21 * x1) / A22;
                if (x2 >= -1 && x2 <= 26)
                    series2.Points.AddXY(x1, x2);
            }

            // Ограничение 3: x2 = (B3 - A31*x1) / A32, от x1=0 до x1=30
            for (double x1 = 0; x1 <= 30; x1 += 0.5)
            {
                double x2 = (B3 - A31 * x1) / A32;
                if (x2 >= -1 && x2 <= 26)
                    series3.Points.AddXY(x1, x2);
            }

            chartOptimization.Series.Add(series1);
            chartOptimization.Series.Add(series2);
            chartOptimization.Series.Add(series3);
        }

        private void DrawFeasibleRegion()
        {
            if (vertices.Count < 3)
                return;

            // Сортировать вершины в порядке обхода против часовой стрелки
            var sorted = vertices.OrderBy(v => Math.Atan2(v.Y, v.X)).ToList();

            var series = new Series("Область ОДР")
            {
                ChartType = SeriesChartType.Area,
                Color = Color.FromArgb(100, 200, 255, 100)
            };

            foreach (var v in sorted)
            {
                series.Points.AddXY(v.X, v.Y);
            }

            // Замкнуть область
            if (sorted.Count > 0)
            {
                series.Points.AddXY(sorted[0].X, sorted[0].Y);
            }

            chartOptimization.Series.Add(series);
        }

        private void DrawGradient()
        {
            // Вектор градиента: (C1, C2) = (45, 55)
            // Начало: (0, 0)
            // Направление: (C1, C2) нормализованное
            // Градиент указывает направление наибольшего возрастания функции

            double length = Math.Sqrt(C1 * C1 + C2 * C2);

            // Направляющий вектор (нормализованный)
            double dx = C1 / length;
            double dy = C2 / length;

            // Найти точку пересечения с границей графика [0, 30] x [0, 25]
            // Линия: (t*dx, t*dy)
            // Находим максимальное t такое, чтобы остаться внутри графика
            double tMaxX = 30 / dx;  // t при достижении x = 30
            double tMaxY = 25 / dy;  // t при достижении y = 25
            double tMax = Math.Min(tMaxX, tMaxY);  // Минимальное значение (первый край)

            var series = new Series("Градиент (направление ↑F)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Orange,
                BorderWidth = 4,
                BorderDashStyle = ChartDashStyle.Dash,
                IsVisibleInLegend = true
            };

            // Рисуем линию от (0, 0) до края графика
            series.Points.AddXY(0, 0);
            series.Points.AddXY(tMax * dx, tMax * dy);

            chartOptimization.Series.Add(series);
        }

        private void DrawOptimalPoint()
        {
            if (optimalPoint == null)
                return;

            var series = new Series("Оптимум")
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Diamond,
                MarkerSize = 12,
                Color = Color.Purple
            };

            series.Points.AddXY(optimalPoint.X, optimalPoint.Y);
            chartOptimization.Series.Add(series);
        }

        private void DisplayResults()
        {
            if (optimalPoint == null)
            {
                lblResultX1.Text = "x₁ = -";
                lblResultX2.Text = "x₂ = -";
                lblMaxProfit.Text = "Макс. прибыль: -";
                return;
            }

            lblResultX1.Text = $"x₁ = {optimalPoint.X:F2}";
            lblResultX2.Text = $"x₂ = {optimalPoint.Y:F2}";
            lblMaxProfit.Text = $"Макс. прибыль: {maxProfit:F2} руб.";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Очистить ресурсы графика
            if (chartOptimization != null)
            {
                chartOptimization.Series.Clear();
                chartOptimization.Dispose();
            }

            // Очистить список вершин
            if (vertices != null)
                vertices.Clear();

            // Очистить данные
            optimalPoint = null;
            mainForm = null;
        }
    }

    // Вспомогательный класс для представления точки
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point2D))
                return false;

            var other = (Point2D)obj;
            return Math.Abs(X - other.X) < 1e-6 && Math.Abs(Y - other.Y) < 1e-6;
        }

        public override int GetHashCode()
        {
            return (X.ToString("F6") + Y.ToString("F6")).GetHashCode();
        }
    }
}
