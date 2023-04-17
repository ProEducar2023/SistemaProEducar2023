using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.HELPERS
{
    public static class AppearanceUtil
    {
        public static Color BackColorColumnPrimary => Color.FromArgb(19, 141, 117);
        public static Color ForeColorColumnPrimary => Color.White;
        public static Color BackColorColumn => Color.FromArgb(169, 204, 227);
        public static Color BackColorColumnDefault => Color.White;
        public static Color ForeColorColumnDefault => Color.Black;
        public static Color ColorButtonPrimaryDark => Color.FromArgb(14, 102, 85);
        public static Color ColorButtonPrimaryDarkLight => Color.Teal;
        public static Color ColorButtonWhite => Color.White;

        public static void StyleButtonFlat(this Button button)
        {
            if (button != null)
            {
                button.ForeColor = ColorButtonPrimaryDark;
                button.BackColor = ColorButtonWhite;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = ColorButtonPrimaryDarkLight;
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.MouseDownBackColor = ColorButtonWhite;
                button.FlatAppearance.MouseOverBackColor = ColorButtonPrimaryDarkLight;
                button.Cursor = Cursors.Hand;
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }

            void Button_MouseEnter(object sender, EventArgs e)
            {
                button.ForeColor = ColorButtonWhite;
            }

            void Button_MouseLeave(object sender, EventArgs e)
            {
                button.ForeColor = ColorButtonPrimaryDark;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="button"></param>
        /// <param name="textColor">Establece el color de texto del button</param>
        /// <param name="backColor">Establece el color de fondo del button</param>
        /// <param name="borderColor">Color de borde del button</param>
        /// <param name="mouseClickBackColor">Establece el color de fondo del button cuando se presiona el mouse sobre el button \n También -> Establece color de texto del button cuando el mouse esta sobre el button</param>
        /// <param name="mouseOverBackColor">Establece el color de fondo del button cuando el puntero de mouse esta sobre el button \n También -> Establece color de texto del button cuando el mouse no esta sobre el button</param>
        /// <param name="borderSize">Establece el ancho del border del button</param>
        public static void StyleButtonFlat(this Button button, Color textColor, Color backColor, Color borderColor,
            Color mouseClickBackColor, Color mouseOverBackColor, int borderSize)
        {
            if (button != null)
            {
                button.ForeColor = textColor;
                button.BackColor = backColor;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = borderColor;
                button.FlatAppearance.BorderSize = borderSize;
                button.FlatAppearance.MouseDownBackColor = mouseClickBackColor;
                button.FlatAppearance.MouseOverBackColor = mouseOverBackColor;
                button.Cursor = Cursors.Hand;
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }
            //> Se produce cuando el mouse esta sobre el button
            void Button_MouseEnter(object sender, EventArgs e)
            {
                button.ForeColor = mouseClickBackColor;
            }
            //> Se produce cuando el mouse deja(sale) el button
            void Button_MouseLeave(object sender, EventArgs e)
            {
                button.ForeColor = mouseOverBackColor;
            }
        }

        public static void StyleButtonFlat(this Button button, Color textColor, Color backColor, Color borderColor, int borderSize)
        {
            if (button != null)
            {
                button.ForeColor = textColor;
                button.BackColor = backColor;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = borderColor;
                button.FlatAppearance.BorderSize = borderSize;
                //> button.FlatAppearance.MouseDownBackColor = mouseClickBackColor;
                button.FlatAppearance.MouseOverBackColor = textColor;
                button.Cursor = Cursors.Hand;
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }
            //> Se produce cuando el mouse esta sobre el button
            void Button_MouseEnter(object sender, EventArgs e)
            {
                button.ForeColor = backColor;
            }
            //> Se produce cuando el mouse deja(sale) el button
            void Button_MouseLeave(object sender, EventArgs e)
            {
                button.ForeColor = textColor;
            }
        }

        public static void Style1TabPages(this TabControl tabControl, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = tabControl.TabPages[e.Index];

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            // Este sera el rectangulo que se dibujara sobre el titutlo del tab 
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);
            // Este sera el color por defecto del tab no seleccionado 
            SolidBrush sb = new SolidBrush(Color.AntiqueWhite);
            //> Este sera el color por defecto del text del tab no seleccionado
            SolidBrush solidBrush = new SolidBrush(Color.Blue);
            if (tabControl.SelectedIndex == e.Index)
            {
                // color del tab que se selecciona
                sb.Color = Color.Teal;
                //> color del text del tab seleccionado
                solidBrush.Color = Color.White;
            }

            // aplica el color sobre el tabpage actual 
            g.FillRectangle(sb, e.Bounds);

            Font font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);

            //escribe el texto que tenia el tab
            g.DrawString(tp.Text, font, solidBrush, headerRect, sf);
        }
    }
}
