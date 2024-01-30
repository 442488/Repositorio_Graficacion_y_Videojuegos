using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centroid
{
    internal class DrawLine
    {
        Bitmap bitmap;



        public DrawLine(Bitmap bmp, PictureBox pctCanvas)
        {
            bitmap = bmp;

        }

        public void RenderLine(Graphics g)
        {

            // Realiza las lineas punteadas, horizontal y vertical
            int centerX = bitmap.Width / 2;
            int centerY = bitmap.Height / 2;
            int halfWidth = bitmap.Width / 2;
            int halfHeight = bitmap.Height / 2;

           
            Point horizontalStart = new Point(centerX - halfWidth, centerY);
            Point horizontalEnd = new Point(centerX + halfWidth, centerY);
            Point verticalStart = new Point(centerX, centerY - halfHeight);
            Point verticalEnd = new Point(centerX, centerY + halfHeight);

            Pen dashedPen = new Pen(Color.Red);
            dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            g.DrawLine(dashedPen, horizontalStart, horizontalEnd);
            g.DrawLine(dashedPen, verticalStart, verticalEnd);

            dashedPen.Dispose();
        }
    }
}
