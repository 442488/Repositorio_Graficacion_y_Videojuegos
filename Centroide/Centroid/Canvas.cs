using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centroid
{
    internal class Canvas
    {
        Bitmap bitmap;
        Graphics g;
        PictureBox PCT_CANVA;

        private double anguloRotacion = 0; 
        double factorDeEscala = 1;
        int tranX = 0, tranY = 0;


        public void ActualizarAnguloRotacion(double nuevoAngulo)
        {
            anguloRotacion = nuevoAngulo;
        }

        public void ActualizarEscalado(double nuevoFactor)
        {
            factorDeEscala = nuevoFactor;
        }

        public void MoverFigura(int transX, int transY)
        {
            tranX += transX;
            tranY += transY;


            Render();
        }


        public Canvas(Bitmap bmp, PictureBox pctCanvas) 
        {
            bitmap = bmp;
            g = Graphics.FromImage(bitmap);
            PCT_CANVA = pctCanvas;
        }

        public void CentrarFigura()
        {
            // Calcula donde queda el centro

            int nuevoCentroX = bitmap.Width / 2;
            int nuevoCentroY = bitmap.Height / 2;
            int transX = nuevoCentroX - tranX;
            int transY = nuevoCentroY - tranY;

            // Mueve la figura al centro
            MoverFigura(transX, transY);
        }


        public void Render()
        {
            // Crea las figuras

            g.Clear(Color.Transparent); 
            List<Point> puntosCuadrado = Figure.CrearCuadrado(1);

            Figure.EscalarFigura(puntosCuadrado, factorDeEscala);

            Point pivoteRotacion = puntosCuadrado [0]; 

            Figure.RotarFigura(puntosCuadrado, anguloRotacion, pivoteRotacion);
            Figure.TrasladarFigura(puntosCuadrado, tranX - pivoteRotacion.X, tranY - pivoteRotacion.Y);

            using (Pen pinkPen = new Pen(Color.Pink))
            {
                g.DrawLine(pinkPen, puntosCuadrado[0], puntosCuadrado[1]);
                g.DrawLine(pinkPen, puntosCuadrado[1], puntosCuadrado[2]);
                g.DrawLine(pinkPen, puntosCuadrado[2], puntosCuadrado[3]);
                g.DrawLine(pinkPen, puntosCuadrado[3], puntosCuadrado[0]);
            }


            PCT_CANVA.Invalidate();
        }
    }
}
