using System.Windows.Forms;
using PROYECTO_BIBLIOTECA.CONTROLADORES;

namespace PROYECTO_BIBLIOTECA.VISTAS
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();

            Login_Controller controlador = new Login_Controller(this);
        }

       
    }
}
