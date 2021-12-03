using System;
using System.Windows.Forms;

namespace PROYECTO_BIBLIOTECA.VISTAS
{
    public partial class MENU : Syncfusion.Windows.Forms.Office2010Form
    {
        public MENU()
        {
            InitializeComponent();
        }
        TERMINOS Terminos;
        REGISTRAR users;
        DETALLE Detalle;
      
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (users == null)
            {
                users = new REGISTRAR();
                users.MdiParent = this;
                users.FormClosed += Users_FormClosed;
                users.Show();
            }
            else
            {
                users.Activate();
            }

        }

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            users = null;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Terminos == null)
            {
                Terminos = new TERMINOS();
                Terminos.MdiParent = this;
                //Terminos.FormClosed += TERMINOS_FormClosed;
                Terminos.Show();
            }
            else
            {
                users.Activate();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DETALLE users = new DETALLE();
            users.Show();
        }
    }
}
