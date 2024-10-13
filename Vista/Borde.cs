using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCP_AMHCH.Vista
{
    class Borde
    {
        public static class BorderUtils
        {
            // Método estático para dibujar el borde
            public static void DrawBorder(Control control, PaintEventArgs e, int borderWidth, Color borderColor)
            {
                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, control.ClientSize.Width - borderWidth, control.ClientSize.Height - borderWidth));
                }
            }
            // Manejar el evento Paint
            public static void DrawLine(Control control, PaintEventArgs e, Color borderColor, int x1, int x2, int y)
            {

                // Obtener el objeto Graphics para dibujar
                Graphics g = e.Graphics;

                // Crear una pluma (Pen) para definir el grosor y el color de la línea
                Pen blackPen = new Pen(borderColor, 2);  // Línea negra con grosor de 2 píxeles

                // Dibujar la línea desde el punto inicial (X1, Y1) hasta el punto final (X2, Y2)
                g.DrawLine(blackPen, x1, y, control.ClientSize.Width - x2, y);  // Coordenadas para la línea horizontal

                // Liberar la pluma cuando ya no se necesite
                blackPen.Dispose();
            }
        }
    }
}
