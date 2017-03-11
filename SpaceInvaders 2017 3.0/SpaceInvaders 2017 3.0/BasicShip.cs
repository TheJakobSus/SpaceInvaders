using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders_2017_3._0
{
    class BasicShip
    {
        protected Point position;
        protected int size;

        public BasicShip(Point position)
        {
            this.position = position;
            this.size = 20;
        }

        public virtual void Paint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.DarkGray, position.X, position.Y, size, size);
        }


        public virtual void PaintBullet(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, position.X, position.Y, size, size);
        }

        public Point Position
        {
            get { return this.position; }
        }

        public int Size
        {
            get { return this.size; }
        }

    }
}
