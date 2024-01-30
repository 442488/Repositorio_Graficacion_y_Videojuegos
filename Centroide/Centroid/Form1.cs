using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Centroid
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        Bitmap bmp;
        Graphics g;
        DrawLine line;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init() {
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            PCT_CANVAS.Image = bmp;
            canvas = new Canvas(bmp, PCT_CANVAS);
            line = new DrawLine(bmp, PCT_CANVAS);

            canvas.Render();
            line.RenderLine(g);
            PCT_CANVAS.Invalidate();
        }

        private void ActualizarAnguloDesdeTextBox()
        {
            // Obtiene el ángulo ingresado desde el forms
            if (double.TryParse(textBox1.Text, out double angulo))
            {

                canvas.ActualizarAnguloRotacion(angulo);
                canvas.Render();
                line.RenderLine(g);
                PCT_CANVAS.Invalidate();
            }

        }

        private void ActualizarEscalaDesdeTextBox()
        {
            // Obtiene el factor de escala ingresado desde el forms
            if (double.TryParse(textBox2.Text, out double factor))
            {
                canvas.ActualizarEscalado(factor);
                canvas.Render();
                line.RenderLine(g);
                PCT_CANVAS.Invalidate();
            }

        }

        private void PCT_CANVAS_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarAnguloDesdeTextBox();
            ActualizarEscalaDesdeTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Ayuda a moverse en base al eje x
            int desplazamientoX = 100; 

            canvas.MoverFigura(desplazamientoX, 0);
            canvas.Render();
            line.RenderLine(g);
            PCT_CANVAS.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Ayuda a moverse en asbe al eje -x
            int desplazamientoX = -100; 
        
            canvas.MoverFigura(desplazamientoX, 0); 
            canvas.Render();
            line.RenderLine(g);
            PCT_CANVAS.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Ayuda a moverse en asbe al eje y
            int desplazamientoY = 100; 

            canvas.MoverFigura(0, desplazamientoY);
            canvas.Render();
            line.RenderLine(g);
            PCT_CANVAS.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Ayuda a moverse en asbe al eje -y
            int desplazamientoY = -100;       
            
            canvas.MoverFigura(0, desplazamientoY);
            canvas.Render();
            line.RenderLine(g);
            PCT_CANVAS.Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            canvas.CentrarFigura();
            canvas.Render();
            line.RenderLine(g);
            PCT_CANVAS.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
