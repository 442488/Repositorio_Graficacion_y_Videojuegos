using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Centroid
{
    internal class Figure
    {
        public static List<Point> CrearCuadrado(int lado)
        {
            List<Point> puntos = new List<Point>
            {
                new Point(0, 0),
                new Point(0, lado*100),
                new Point(lado * 100, lado*100),
                new Point(lado * 100, 0)
            };

            return puntos;
        }

        public static List<Point> CrearTriangulo(int lado)
        {
            List<Point> puntos = new List<Point>
            {
                new Point(0, 0),
                new Point(lado* 100, 0),
                new Point(lado * 100 / 2, (int)(100*lado * Math.Sqrt(3) / 2))
            };

            return puntos;
        }



        //Movimiento de translacion
        internal static void TrasladarFigura(List<Point> puntos, int transX, int transY)
        {
            int centerX = 0;
            int centerY = 0;

            foreach (Point punto in puntos)
            {
                centerX += punto.X;
                centerY += punto.Y;
            }

            centerX /= puntos.Count;

            if (puntos.Count == 3)
            {
                int minY = puntos.Min(p => p.Y);
                centerY = minY + (puntos.Max(p => p.Y) - minY) / 2;
            }
            else
            {
                centerY /= puntos.Count;
            }

            int newTransX = transX - centerX;
            int newTransY = transY - centerY;

            translacion(puntos, newTransX, newTransY);
        }


        public static Point translacion(Point p, int transX, int transY)
        {
            p.X = (p.X + transX);
            p.Y = (p.Y + transY);

            return p;
        }

        public static void translacion(List<Point> puntos, int transX, int transY)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i] = translacion(puntos[i], transX, transY);
            }
        }

        //Movimiento de rotación
        public static void RotarFigura(List<Point> puntos, double angulo, Point pivote)
        {
            List<Point> puntosRotados = rotar(puntos, angulo, pivote);

            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i] = puntosRotados[i];
            }
        }

        public static List<Point> rotar(List<Point> puntos, double angulo, Point pivote)
        {
            double radianes = angulo * Math.PI / 180.0;


            for (int i = 0; i < puntos.Count; i++)
            {
                int translatedX = puntos[i].X - pivote.X;
                int translatedY = puntos[i].Y - pivote.Y;

               
                int rotatedX = (int)(translatedX * Math.Cos(radianes) - translatedY * Math.Sin(radianes));
                int rotatedY = (int)(translatedX * Math.Sin(radianes) + translatedY * Math.Cos(radianes));

               
                puntos[i] = new Point(rotatedX + pivote.X, rotatedY + pivote.Y);
            }

            return puntos;
        }


        //Movimiento escalar
        public static void EscalarFigura(List<Point> puntos, double factorEscalado)
        {
            escalar(puntos, factorEscalado);
        }

        public static void escalar(List<Point> puntos, double factorEscalado)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i] = new Point(
                    (int)(puntos[i].X * factorEscalado),
                    (int)(puntos[i].Y * factorEscalado)
                );
            }
        }
    }
}
