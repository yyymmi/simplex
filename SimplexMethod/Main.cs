using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexMethod
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simp SWindow = new Simp();
            SWindow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graph GWindow = new Graph();
            GWindow.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HP HWindow = new HP();
            HWindow.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnGraphicalMetodOne_Click(object sender, EventArgs e)
        {
            GraphicalMetodOne form = new GraphicalMetodOne(this);
            form.Show();
            this.Hide();
        }

        private void btnSmMetodOne_Click(object sender, EventArgs e)
        {
            SmMetodOne form = new SmMetodOne(this);
            form.Show();
            this.Hide();
        }
    }
}
