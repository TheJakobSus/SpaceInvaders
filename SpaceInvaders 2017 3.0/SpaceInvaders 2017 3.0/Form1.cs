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
        private Invader[] invaders;
        int invadersDeadCount = 0;
        int invaderTotalColumns = 5;
        int invaderTotalRows = 2;
        public int score = 0;

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            basicShip = new BasicShip(new Point(20, 20));
            ship1 = new Ship1(new Point(pictureBox1.Width / 2, pictureBox1.Height - basicShip.Size));
            invaders = new Invader[invaderTotalRows * invaderTotalColumns];



            //invaders inicialization 
            
            for (int invaderNumber = 0; invaderNumber < invaderTotalRows * invaderTotalColumns; invaderNumber++)
            {
                int invaderCurrentColumn = (invaderNumber - ((invaderNumber / invaderTotalColumns) * invaderTotalColumns));
                int invaderCurrentRow = invaderNumber / invaderTotalColumns + 1;
                invaders[invaderNumber] = new Invader(new Point(invaderCurrentColumn * (pictureBox1.Width / invaderTotalColumns), invaderCurrentRow * basicShip.Size*5/2 ));
            }
            





        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int invaderNumber = 0; invaderNumber < invaderTotalColumns * invaderTotalRows; invaderNumber++)
            {
                int invaderCurrentColumn = (invaderNumber - ((invaderNumber / invaderTotalColumns) * invaderTotalColumns));
                int invaderCurrentRow = invaderNumber / invaderTotalColumns + 1;
                if (invaders[invaderNumber].Dead == false)
                {
                    if (invaderNumber == invaderTotalColumns / 2 )
                    { invaders[invaderNumber].Paint3(e); }
                    else if (invaderCurrentRow == 2)
                    { invaders[invaderNumber].Paint2(e); }
                    else
                    { invaders[invaderNumber].Paint(e); }
                }
            }
            

            ship1.Paint(e);
            ship1.PaintBullet(e);

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ship1.NextShip();
            ship1.NextBullet();
            //invaders1 
            for (int invaderNumber = 0; invaderNumber < invaderTotalColumns * invaderTotalRows; invaderNumber++)
            {
                int invaderCurrentColumn = (invaderNumber - ((invaderNumber / invaderTotalColumns) * invaderTotalColumns));
                int invaderCurrentRow = invaderNumber / invaderTotalColumns + 1;
                // invaders arrive to right edge
                if (invaders[invaderNumber].Position.X == pictureBox1.Width - invaders[invaderNumber].InvaderWidth1
                    && invaders[invaderNumber].Direction == 0
                    && invaders[invaderNumber].Dead == false)
                {
                    for (int invaderNumber1 = 0; invaderNumber1 < invaderTotalColumns * invaderTotalRows; invaderNumber1++)
                    {
                        invaders[invaderNumber1].MoveLeft();
                        invaders[invaderNumber1].MoveDown();
                    }
                }
                // invaders arrive to left edge
                if (invaders[invaderNumber].Position.X == 0
                    && invaders[invaderNumber].Direction == 1
                    && invaders[invaderNumber].Dead == false)
                {
                    for (int invaderNumber1 = 0; invaderNumber1 < invaderTotalColumns * invaderTotalRows; invaderNumber1++)
                    {
                        invaders[invaderNumber1].MoveRight();
                        invaders[invaderNumber1].MoveDown();
                    }
                }

                //invaders get shot
                if (ship1.PositionBullet.X >= invaders[invaderNumber].Position.X
                    && ship1.PositionBullet.X <= invaders[invaderNumber].Position.X + invaders[invaderNumber].InvaderWidth1
                    && ship1.PositionBullet.Y >= invaders[invaderNumber].Position.Y
                    && ship1.PositionBullet.Y <= invaders[invaderNumber].Position.Y + invaders[invaderNumber].InvaderHeight1
                    && invaders[invaderNumber].Dead == false)
                {
                    invaders[invaderNumber].Shot();
                    ship1.Load();
                    invadersDeadCount++;
                    if (invaderNumber == invaderTotalColumns / 2)
                    { score += -99999; }
                    else if (invaderCurrentRow == 1)
                    { score += 125; }
                    else
                    { score += 75; }
                }


                invaders[invaderNumber].NextInvader();

            }

            // Invaders get to the bottom
            for (int invaderNumber = 0; invaderNumber < invaderTotalColumns * invaderTotalRows; invaderNumber++)
            {
                if (invaders[invaderNumber].Position.Y + invaders[invaderNumber].InvaderHeight1 >= pictureBox1.Height
                && invaders[invaderNumber].Dead == false)
                {
                    timer1.Enabled = false;
                    PopUp popup = new PopUp();
                    popup.SetScore(score);
                    popup.SetEnd(2);
                    popup.ShowDialog();
                }
            



            /*if (invaders2[i].Position.Y + invaders2[i].InvaderHeight1 >= pictureBox1.Height
                && invaders2[i].Dead == false )
            {
                timer1.Enabled = false;
                PopUp popup = new PopUp();
                popup.SetScore(score);
                popup.SetEnd(false);
                popup.ShowDialog();
            }*/


            }

            // invaders dead counter (o is number of rows, n is number of invaders per row)
            for (int invaderNumber = 0; invaderNumber < invaderTotalColumns * invaderTotalRows; invaderNumber++)
            {
                if (invadersDeadCount == invaderTotalRows * invaderTotalColumns - 1
                &&  invaders[invaderTotalColumns / 2].Dead==false)
                {
                    timer1.Enabled = false;
                    PopUp popup = new PopUp();
                    popup.SetScore(score);
                    popup.SetEnd(0);
                    popup.ShowDialog();
                }
                else if (invadersDeadCount == invaderTotalRows * invaderTotalColumns)
                {
                    timer1.Enabled = false;
                    PopUp popup = new PopUp();
                    popup.SetScore(score);
                    popup.SetEnd(1);
                    popup.ShowDialog();
                }
                

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
            popup.SetEnd(2);
            popup.ShowDialog();
        }

        

        
    }
}
