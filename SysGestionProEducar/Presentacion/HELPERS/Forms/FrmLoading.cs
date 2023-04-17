using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.HELPERS.Forms
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            pbLoading.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"HELPERS\Forms\loading.gif"));
            //>pbLoading.Load("Presentacion.HELPERS.Forms.loading.gif");
            pbLoading.SizeMode = PictureBoxSizeMode.StretchImage;
            CenterToParent();
        }
    }
}
