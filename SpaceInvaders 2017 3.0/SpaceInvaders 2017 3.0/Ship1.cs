using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace SpaceInvaders_2017_3._0
{
    class Ship1 : BasicShip
    {

        protected int direction = 0;
        protected int status = 0;
        protected Point positionBullet;

        public Ship1(Point position)
            : base(position)
        {
        }

        public override void Paint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, position.X, position.Y, size, size);
        }

        public override void PaintBullet(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, positionBullet.X, positionBullet.Y, 5, 5);
        }

        public int Direction
        {
            get { return this.direction; }
        }

        public Point PositionBullet
        {
            get { return this.positionBullet; }
        }

        public void GoRight()
        {
            this.direction = 1;
        }

        public void GoLeft()
        {
            this.direction = 2;
        }

        public void Stop()
        {
            this.direction = 0;
        }

        public void NextShip()
        {
            switch (direction)
            {
                case 0: { break; }
                case 1:
                    {
                        if (position.X + this.size < 522)
                            position.X = position.X + 2;
                        break;
                    }
                case 2:
                    {
                        if (position.X > 0)
                            position.X = position.X - 2;
                        break;
                    }
            }
        }

        public void Shoot()
        {
            this.status = 1;
        }

        public void Load()
        {
            this.status = 0;
        }

        public void NextBullet()
        {
            switch (status)
            {
                case 0: { positionBullet.X = position.X + this.size / 2; positionBullet.Y = position.Y; break; }
                case 1:
                    {
                        if (positionBullet.Y > 0)
                        { positionBullet.Y = positionBullet.Y - 6; }
                        else
                        { this.status = 0; }
                        break;
                    }
            }
        }
    }
}
