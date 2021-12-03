using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_BIBLIOTECA.VISTAS
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            REGISTRAR users = new REGISTRAR();
            users.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TERMINOS users = new TERMINOS();
            users.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           FACTURA users = new FACTURA();
            users.Show();
        }
    }
}
