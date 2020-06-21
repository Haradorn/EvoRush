using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace EvoRush
{
    public partial class Game6x6 : Form
    {
        public static int dimension = 6;
        public int[,] pole = new int[dimension, dimension];
        public Label[,] labels = new Label[dimension, dimension];
        public PictureBox[,] pics = new PictureBox[dimension, dimension];
        private int score = 0;
        public Game6x6()
        {
            InitializeComponent();
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(_keyboardEvent);
            pole[0, 0] = 1;
            pole[0, 1] = 1;
            createPole();
            createPics();
            generateNewPic();
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = Application.StartupPath + "\\relax.wav";
            sp.PlayLooping();
        }
        private void createPole()
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Location = new Point(25 + 100 * j, 75 + 100 * i);
                    pic.Size = new Size(100, 100);
                    pic.BackColor = Color.LightGray;
                    this.Controls.Add(pic);
                }
            }
        }
        private void generateNewPic()
        {
            Random random = new Random();
            int a = random.Next(0, dimension);
            int b = random.Next(0, dimension);
            while (pics[a, b] != null)//
            {
                a = random.Next(0, dimension);
                b = random.Next(0, dimension);
            }
            pole[a, b] = 1;
            pics[a, b] = new PictureBox();
            labels[a, b] = new Label();
            labels[a, b].Text = "2";
            pics[a, b].Location = new Point(25 + b * 100, 75 + 100 * a);
            pics[a, b].Size = new Size(100, 100);
            pics[a, b].ImageLocation = Application.StartupPath + "\\medusa.jpg";
            this.Controls.Add(pics[a, b]);
            pics[a, b].BringToFront();
        }
        private void createPics()
        {
            pics[0, 0] = new PictureBox();
            labels[0, 0] = new Label();
            labels[0, 0].Text = "2";
            pics[0, 0].Location = new Point(25, 75);
            pics[0, 0].Size = new Size(100, 100);
            pics[0, 0].ImageLocation = Application.StartupPath + "\\medusa.jpg";
            this.Controls.Add(pics[0, 0]);
            pics[0, 0].BringToFront();
            pics[0, 1] = new PictureBox();
            labels[0, 1] = new Label();
            labels[0, 1].Text = "2";
            pics[0, 1].Location = new Point(125, 75);
            pics[0, 1].Size = new Size(100, 100);
            pics[0, 1].ImageLocation = Application.StartupPath + "\\medusa.jpg";
            this.Controls.Add(pics[0, 1]);
            pics[0, 1].BringToFront();
        }
        private void changeColor(int sum, int k, int j)
        {
            if (sum % 1024 == 0) pics[k, j].ImageLocation = Application.StartupPath + "\\cyborg.jpg";
            else if (sum % 512 == 0) pics[k, j].ImageLocation = Application.StartupPath + "\\man.jpg";
            else if (sum % 256 == 0) pics[k, j].ImageLocation = Application.StartupPath + "\\neander.jpg";
            else if (sum % 128 == 0) pics[k, j].ImageLocation = Application.StartupPath + "\\monkey.jpg";
            else if (sum % 64 == 0) pics[k, j].ImageLocation = Application.StartupPath + "\\elephant.jpg";
            else if (sum % 32 == 0) pics[k, j].ImageLocation = Application.StartupPath + "\\bird.jpg";
            else if (sum % 16 == 0) pics[k, j].ImageLocation = Application.StartupPath + "\\dino.jpg";
            else if (sum % 8 == 0) pics[k, j].ImageLocation = Application.StartupPath + "\\frog.jpg";
            else pics[k, j].ImageLocation = Application.StartupPath + "\\bee.jpg";
        }
        private void _keyboardEvent(object sender, KeyEventArgs e)
        {
            bool ifPicsWasMooved = false;

            switch (e.KeyCode.ToString())
            {
                case "D":
                    for (int k = 0; k < dimension; k++)
                    {
                        for (int l = 4; l >= 0; l--)
                        {
                            if (pole[k, l] == 1)
                            {
                                for (int j = l + 1; j < dimension; j++)
                                {
                                    if (pole[k, j] == 0)//
                                    {
                                        ifPicsWasMooved = true;
                                        pole[k, j - 1] = 0;
                                        pole[k, j] = 1;
                                        pics[k, j] = pics[k, j - 1];
                                        pics[k, j - 1] = null;
                                        labels[k, j] = labels[k, j - 1];
                                        labels[k, j - 1] = null;
                                        pics[k, j].Location = new Point(pics[k, j].Location.X + 100, pics[k, j].Location.Y);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[k, j].Text);
                                        int b = int.Parse(labels[k, j - 1].Text);
                                        if (a == b)
                                        {
                                            ifPicsWasMooved = true;
                                            labels[k, j].Text = (a + b).ToString();
                                            score += (a + b);
                                            changeColor(a + b, k, j);
                                            label1.Text = "Очки: " + score;
                                            pole[k, j - 1] = 0;
                                            this.Controls.Remove(pics[k, j - 1]);
                                            this.Controls.Remove(labels[k, j - 1]);
                                            pics[k, j - 1] = null;
                                            labels[k, j - 1] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "A":
                    for (int k = 0; k < dimension; k++)
                    {
                        for (int l = 1; l < dimension; l++)
                        {
                            if (pole[k, l] == 1)
                            {
                                for (int j = l - 1; j >= 0; j--)
                                {
                                    if (pole[k, j] == 0)
                                    {
                                        ifPicsWasMooved = true;
                                        pole[k, j + 1] = 0;
                                        pole[k, j] = 1;
                                        pics[k, j] = pics[k, j + 1];
                                        pics[k, j + 1] = null;
                                        labels[k, j] = labels[k, j + 1];
                                        labels[k, j + 1] = null;
                                        pics[k, j].Location = new Point(pics[k, j].Location.X - 100, pics[k, j].Location.Y);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[k, j].Text);
                                        int b = int.Parse(labels[k, j + 1].Text);
                                        if (a == b)
                                        {
                                            ifPicsWasMooved = true;
                                            labels[k, j].Text = (a + b).ToString();
                                            score += (a + b);
                                            changeColor(a + b, k, j);
                                            label1.Text = "Очки: " + score;
                                            pole[k, j + 1] = 0;
                                            this.Controls.Remove(pics[k, j + 1]);
                                            this.Controls.Remove(labels[k, j + 1]);
                                            pics[k, j + 1] = null;
                                            labels[k, j + 1] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "S":
                    for (int k = 4; k >= 0; k--)
                    {
                        for (int l = 0; l < dimension; l++)
                        {
                            if (pole[k, l] == 1)
                            {
                                for (int j = k + 1; j < dimension; j++)
                                {
                                    if (pole[j, l] == 0)
                                    {
                                        ifPicsWasMooved = true;
                                        pole[j - 1, l] = 0;
                                        pole[j, l] = 1;
                                        pics[j, l] = pics[j - 1, l];
                                        pics[j - 1, l] = null;
                                        labels[j, l] = labels[j - 1, l];
                                        labels[j - 1, l] = null;
                                        pics[j, l].Location = new Point(pics[j, l].Location.X, pics[j, l].Location.Y + 100);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[j, l].Text);
                                        int b = int.Parse(labels[j - 1, l].Text);
                                        if (a == b)
                                        {
                                            ifPicsWasMooved = true;
                                            labels[j, l].Text = (a + b).ToString();
                                            score += (a + b);
                                            changeColor(a + b, j, l);
                                            label1.Text = "Очки: " + score;
                                            pole[j - 1, l] = 0;
                                            this.Controls.Remove(pics[j - 1, l]);
                                            this.Controls.Remove(labels[j - 1, l]);
                                            pics[j - 1, l] = null;
                                            labels[j - 1, l] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "W":
                    for (int k = 1; k < dimension; k++)
                    {
                        for (int l = 0; l < dimension; l++)
                        {
                            if (pole[k, l] == 1)
                            {
                                for (int j = k - 1; j >= 0; j--)
                                {
                                    if (pole[j, l] == 0)
                                    {
                                        ifPicsWasMooved = true;
                                        pole[j + 1, l] = 0;
                                        pole[j, l] = 1;
                                        pics[j, l] = pics[j + 1, l];
                                        pics[j + 1, l] = null;
                                        labels[j, l] = labels[j + 1, l];
                                        labels[j + 1, l] = null;
                                        pics[j, l].Location = new Point(pics[j, l].Location.X, pics[j, l].Location.Y - 100);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[j, l].Text);
                                        int b = int.Parse(labels[j + 1, l].Text);
                                        if (a == b)
                                        {
                                            ifPicsWasMooved = true;
                                            labels[j, l].Text = (a + b).ToString();
                                            score += (a + b);
                                            changeColor(a + b, j, l);
                                            label1.Text = "Очки: " + score;
                                            pole[j + 1, l] = 0;
                                            this.Controls.Remove(pics[j + 1, l]);
                                            this.Controls.Remove(labels[j + 1, l]);
                                            pics[j + 1, l] = null;
                                            labels[j + 1, l] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            if (ifPicsWasMooved) generateNewPic();
        }
    }
}
