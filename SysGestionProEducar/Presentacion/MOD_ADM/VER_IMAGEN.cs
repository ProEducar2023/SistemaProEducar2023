using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class VER_IMAGEN : Form
    {
        string ruta;
        public VER_IMAGEN(string ruta)
        {
            InitializeComponent();
            this.ruta = ruta;
        }

        private void VER_IMAGEN_Load(object sender, EventArgs e)
        {
            //pcb_foto.Image = Image.FromFile(Path.Combine(Application.StartupPath,ruta));
            try
            {
                pcb_foto.Image = Image.FromFile(@"C:\img\" + ruta);
                pcb_foto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {

            }

        }
    }
}
