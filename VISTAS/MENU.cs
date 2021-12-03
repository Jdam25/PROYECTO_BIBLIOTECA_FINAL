using PROYECTO_BIBLIOTECA.MODELOS.DAO;
using System;
using System.Windows.Forms;
using PROYECTO_BIBLIOTECA.MODELOS.ENTIDADES;

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
           // VISTAS.RegistrardataGridView.DataSource = UsuarioDao.Cliente();
            FACTURA users = new FACTURA();
            users.Show();
        }
    }
}
