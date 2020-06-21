using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvoRush
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game4x4 game = new Game4x4();
            game.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game5x5 game = new Game5x5();
            game.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game6x6 game = new Game6x6();
            game.ShowDialog();
        }
    }
}
