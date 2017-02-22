using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders_2017_3._0
{
    public partial class Form1 : Form
    {
        private BasicShip basicShip;
        private Ship1 ship1;
        private Invader[] invaders1;

        public Form1()
        {
            InitializeComponent();
            basicShip = new BasicShip(new Point(20, 20));
            ship1 = new Ship1(new Point(pictureBox1.Width / 2, pictureBox1.Height - basicShip.Size));
            invaders1 = new Invader[3];

            for (int i = 0; i < 3; i++)
            {
                invaders1[i] = new Invader(new Point(i * pictureBox1.Width / 3, basicShip.Size));
            }


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                

                if (invaders1[i].Position.X == pictureBox1.Width - 2 * invaders1[i].Size && invaders1[i].Direction == 0)
                {
                    for (int j = 0; j < 3; j++)
                    { invaders1[j].MoveLeft(); }
                }

                if (invaders1[i].Position.X == 0 && invaders1[i].Direction == 1)
                {
                    for (int j = 0; j < 3; j++)
                    { invaders1[j].MoveRight(); }
                }

                invaders1[i].Paint(e);
            }

            ship1.Paint(e);
            ship1.PaintBullet(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ship1.NextShip();
            ship1.NextBullet();
            for (int i = 0; i < 3; i++)
            {
                invaders1[i].NextInvader();
            }
            pictureBox1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right: ship1.GoRight(); break;
                case Keys.Left: ship1.GoLeft(); break;
                case Keys.Up: ship1.Shoot(); break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right:
                    if (ship1.Direction == 2)
                    { ship1.GoLeft(); break; }
                    else
                    { ship1.Stop(); break; }

                case Keys.Left: 
                    if (ship1.Direction == 1)
                    { ship1.GoRight(); break; }
                    else
                    { ship1.Stop(); break; }
            }
        }
    }
}
