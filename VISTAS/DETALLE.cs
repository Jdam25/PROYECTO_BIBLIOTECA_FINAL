using PROYECTO_BIBLIOTECA.CONTROLADORES;
using System.Windows.Forms;

namespace PROYECTO_BIBLIOTECA.VISTAS
{
    public partial class DETALLE : Form
    {
        public DETALLE()
        {
            InitializeComponent();

            Detalle_Controller Detalle = new Detalle_Controller(this);

        }


       
    }
}
