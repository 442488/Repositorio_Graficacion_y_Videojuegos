using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallax
{
    public partial class Form1 : Form
    {


        //global variable

        int motion1 = 2;
        int motion2 = 4;
        int motion3 = 8;
        int motion4 = 16;

        int width = 688;

        int l1_X1, l1_X2, l2_X1, l2_X2, l3_X1, l3_X2;

        Bitmap layer0, layer1, layer2, layer3;
        bool right, hold = true;

        static Graphics g;

        private void BlacgroundMove()

        {

            if (l1_X1 < -width) { l1_X1 = width - motion1; }
            l1_X1 -= motion1; l1_X2 -= motion1;
            if (l1_X2 < -width) { l1_X2 = width - motion1; }

            if (l2_X1 < -width) { l2_X1 = width - motion2; }
            l2_X1 -= motion2; l2_X2 -= motion2;
            if (l2_X2 < -width) { l2_X2 = width - motion2; }

            if (l3_X1 < -width) { l3_X1 = width - motion3; }
            l3_X1 -= motion3; l3_X2 -= motion3;
            if (l3_X2 < -width) { l3_X2 = width - motion3; }

            Invalidate();

        }




        public Form1()
        {
            InitializeComponent();

            layer1 = MyResourses.L1;
            layer2 = MyResourses.L2;
            layer3 = MyResourses.L3;

            l1_X1 = l2_X1 = l3_X1 = 0;
            l1_X2 = l2_X2 = l3_X2 = width;

            player.Image = MyResourses.Mhold;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (right)
                BlacgroundMove();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyData == Keys.Right & hold)
            {
                right = true;
                hold = false;
                player.Image = MyResourses.running;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Right & !hold)
            {
                right = false;
                hold = true;
                player.Image = MyResourses.Mhold;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            g = e.Graphics;

            g.DrawImage(layer1, l1_X1, 0, layer1.Width, this.Height - 50);
            g.DrawImage(layer1, l1_X2, 0, layer1.Width, this.Height - 50);

            g.DrawImage(layer2, l2_X1, 50, layer1.Width, this.Height - 150);
            g.DrawImage(layer2, l2_X2, 50, layer1.Width, this.Height - 150);

            g.DrawImage(layer3, l3_X1, 0, layer1.Width, this.Height - 50);
            g.DrawImage(layer3, l3_X2, 0, layer1.Width, this.Height - 50);


        }

    }
}
