using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders_2017_3._0
{
    class Invader : BasicShip
    {
        protected int direction = 0;
        public Invader(Point position)
            : base(position)
        { }

        public override void Paint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.DarkGreen, position.X, position.Y, 2 * size, 2 * size);
        }


        public int Direction
        {
            get { return this.direction; }
        }
        public void MoveRight()
        {
            this.direction = 0;
        }

        public void MoveLeft()
        {
            this.direction = 1;
        }

        public void NextInvader()
        {
            switch(direction)
            {
                case 0: { position.X++; break; }
                case 1: { position.X--; break; }
            }
            
            
        }
    }
}
