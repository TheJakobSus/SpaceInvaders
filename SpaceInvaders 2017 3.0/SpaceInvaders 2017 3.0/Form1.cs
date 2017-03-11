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
        private Invader[] invaders2;
        int n = 5;
        int m = 0;
        public int score = 0;

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            basicShip = new BasicShip(new Point(20, 20));
            ship1 = new Ship1(new Point(pictureBox1.Width / 2, pictureBox1.Height - basicShip.Size));
            invaders1 = new Invader[5];
            invaders2 = new Invader[5];
            


            //invaders inicialization 
            for (int i = 0; i < n; i++)
            {
                invaders1[i] = new Invader(new Point(i * pictureBox1.Width / 5, basicShip.Size));
                invaders2[i] = new Invader(new Point(i * pictureBox1.Width / 5, basicShip.Size * 4));
            }





        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < n; i++)
            {                
                if (invaders1[i].Dead == false)
                { invaders1[i].Paint(e); }                

                if (invaders2[i].Dead == false)
                { invaders2[i].Paint(e); }
            }

            ship1.Paint(e);
            ship1.PaintBullet(e);

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ship1.NextShip();
            ship1.NextBullet();
            //invaders1 
            for (int i = 0; i < n; i++)
            {
                // invaders arrive to right edge
                if (invaders1[i].Position.X == pictureBox1.Width - invaders1[i].InvaderWidth1
                    && invaders1[i].Direction == 0
                    && invaders1[i].Dead == false)
                {
                    for (int j = 0; j < n; j++)
                    {
                        invaders1[j].MoveLeft();
                        invaders1[j].MoveDown();
                        invaders2[j].MoveLeft();
                        invaders2[j].MoveDown();
                    }
                }
                // invaders arrive to left edge
                if (invaders1[i].Position.X == 0 
                    && invaders1[i].Direction == 1
                    && invaders1[i].Dead == false)
                {
                    for (int j = 0; j < n; j++)
                    {
                        invaders1[j].MoveRight();
                        invaders1[j].MoveDown();
                        invaders2[j].MoveRight();
                        invaders2[j].MoveDown();
                    }
                }

                //invaders get shot
                if (ship1.PositionBullet.X >= invaders1[i].Position.X
                    && ship1.PositionBullet.X <= invaders1[i].Position.X + invaders1[i].InvaderWidth1
                    && ship1.PositionBullet.Y >= invaders1[i].Position.Y
                    && ship1.PositionBullet.Y <= invaders1[i].Position.Y + invaders1[i].InvaderHeight1
                    && invaders1[i].Dead == false)
                {
                    invaders1[i].Shot();
                    ship1.Load();
                    m++;
                    score += 75;
                }


                invaders1[i].NextInvader();
                
            }

            //invaders2
            for (int i = 0; i < n; i++)
            {
                // invaders arrive to right edge
                if (invaders2[i].Position.X == pictureBox1.Width - invaders2[i].InvaderWidth1
                    && invaders2[i].Direction == 0
                    && invaders2[i].Dead == false)
                {
                    for (int j = 0; j < n; j++)
                    {
                        invaders1[j].MoveLeft();
                        invaders1[j].MoveDown();
                        invaders2[j].MoveLeft();
                        invaders2[j].MoveDown();
                    }
                }
                // invaders arrive to left edge
                if (invaders2[i].Position.X == 0
                    && invaders2[i].Direction == 1
                    && invaders2[i].Dead == false)
                {
                    for (int j = 0; j < n; j++)
                    {
                        invaders1[j].MoveRight();
                        invaders1[j].MoveDown();
                        invaders2[j].MoveRight();
                        invaders2[j].MoveDown();
                    }
                }

                //invaders get shot
                if (ship1.PositionBullet.X >= invaders2[i].Position.X
                    && ship1.PositionBullet.X <= invaders2[i].Position.X + invaders2[i].InvaderWidth1
                    && ship1.PositionBullet.Y >= invaders2[i].Position.Y
                    && ship1.PositionBullet.Y <= invaders2[i].Position.Y + invaders2[i].InvaderHeight1
                    && invaders2[i].Dead == false)
                {
                    invaders2[i].Shot();
                    ship1.Load();
                    m++;
                    score += 75;
                }

                invaders2[i].NextInvader();

                
            }

            // Invaders get to the bottom
            for (int i = 0; i < n; i++)
            {
                if (invaders1[i].Position.Y + invaders1[i].InvaderHeight1 >= pictureBox1.Height
                    && invaders1[i].Dead == false)
                {
                    timer1.Enabled = false;
                    PopUp popup = new PopUp();
                    popup.SetScore(score);
                    popup.SetEnd(false);
                    popup.ShowDialog();
                }

                if (invaders2[i].Position.Y + invaders2[i].InvaderHeight1 >= pictureBox1.Height
                    && invaders2[i].Dead == false )
                {
                    timer1.Enabled = false;
                    PopUp popup = new PopUp();
                    popup.SetScore(score);
                    popup.SetEnd(false);
                    popup.ShowDialog();
                }


            }

            // invaders dead counter (2 is number of rows, n is number of invaders per row)
            if (m==2*n)
            {
                timer1.Enabled = false;
                PopUp popup = new PopUp();
                popup.SetScore(score);
                popup.SetEnd(true);
                popup.ShowDialog();
            }

            string scoretxt = Convert.ToString(score);
            label2.Text = scoretxt;

            pictureBox1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.D: ship1.GoRight(); break;
                case Keys.A: ship1.GoLeft(); break;
                case Keys.W: ship1.Shoot(); break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.D:
                    if (ship1.Direction == 2)
                    { ship1.GoLeft(); break; }
                    else
                    { ship1.Stop(); break; }

                case Keys.A: 
                    if (ship1.Direction == 1)
                    { ship1.GoRight(); break; }
                    else
                    { ship1.Stop(); break; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            PopUp popup = new PopUp();
            popup.SetScore(score);
            popup.SetEnd(false);
            popup.ShowDialog();
        }

        

        
    }
}
