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
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetScore(int n)
        {
            label2.Text = Convert.ToString(n);
        }

        public void SetEnd(int endNumber)
        {
            if (endNumber == 0)
            {
                label1.Text = "You won!";
                this.Text = "Victory";
            }
            else if (endNumber == 1)
            {
                label1.Text = "You monster!";
                this.Text = "You monster!";
            }
            else if (endNumber == 2)
            {
                label1.Text = "You lost!";
                this.Text = "Game Over";
            }
            
        }

        
    }
}
