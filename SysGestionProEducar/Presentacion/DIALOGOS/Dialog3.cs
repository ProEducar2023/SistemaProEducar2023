using System;
using System.Windows.Forms;

namespace Presentacion.DIALOGOS
{
    public partial class Dialog3 : Form
    {
        public Dialog3()
        {
            InitializeComponent();
        }

        private void Dialog3_Load(object sender, EventArgs e)
        {

        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
