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
        protected bool dead = false;
        public Invader(Point position)
            : base(position)
        { }


        Bitmap invaderImg = new Bitmap(Properties.Resources.inv1resized);
        protected int invaderWidth1 = new Bitmap(Properties.Resources.inv1resized).Width;
        protected int invaderHeight1 = new Bitmap(Properties.Resources.inv1resized).Height;


        protected int invaderWidth2 = new Bitmap(Properties.Resources.inv2resized).Width;
        protected int invaderHeight2 = new Bitmap(Properties.Resources.inv2resized).Height;

        protected int invaderWidth3 = new Bitmap(Properties.Resources.inv0resized).Width;
        protected int invaderHeight3 = new Bitmap(Properties.Resources.inv0resized).Height;

        public int InvaderWidth1
        {
            get { return this.invaderWidth1; }
        }

        public int InvaderHeight1
        {
            get { return this.invaderHeight1; }
        }

        public int InvaderWidth2
        {
            get { return this.invaderWidth2; }
        }

        public int InvaderHeight2
        {
            get { return this.invaderHeight2; }
        }

        public int InvaderWidth3
        {
            get { return this.invaderWidth3; }
        }

        public int InvaderHeight3
        {
            get { return this.invaderHeight3; }
        }

        

        public override void Paint(PaintEventArgs e)
        {
            //Bitmap invaderImgResized = new Bitmap(invaderImg, new Size(invaderImg.Width / 6, invaderImg.Height / 6));
            e.Graphics.DrawImage(invaderImg, position.X, position.Y);
            //invaderImgResized.Save("inv0resized.bmp");
           // invaderImg.Dispose();
        }

        public void Paint2(PaintEventArgs e)
        {
            Bitmap invaderImgResized = new Bitmap(Properties.Resources.inv2resized);
            e.Graphics.DrawImage(invaderImgResized, position.X, position.Y);
            invaderImgResized.Dispose();
        }

        public void Paint3(PaintEventArgs e)
        {
            Bitmap invaderImgResized = new Bitmap(Properties.Resources.inv0resized);
            e.Graphics.DrawImage(invaderImgResized, position.X, position.Y);
            invaderImgResized.Dispose();
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

        public void MoveDown()
        { this.position.Y += this.size; }

        public void NextInvader()
        {
            switch(direction)
            {
                case 0: { position.X++; break; }
                case 1: { position.X--; break; }
            }            
        }

        public bool Dead
        { get { return this.dead; } }

        public void Shot()
        { this.dead = true; }




    }
}
