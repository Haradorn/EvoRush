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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            label1.Text = "Игра EvoRush - аналог игры \"2048\", в которой " +
                "\n" + "нужно соединять две одинаковые картинки," +
                "\n" + "перемещая их с помощью клавиш W, A, S, D" +
                "\n" + "В игре можно установить размер поля 4х4," +
                "\n" + "5х5 или 5х5 картинок";
            label1.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
