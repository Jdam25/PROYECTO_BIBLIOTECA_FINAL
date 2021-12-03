using PROYECTO_BIBLIOTECA.CONTROLADORES;
using System.Windows.Forms;

namespace PROYECTO_BIBLIOTECA.VISTAS
{
    public partial class FACTURA : Form
    {
        public FACTURA()
        {
            InitializeComponent();
            Detalle_Controller Detalle = new Detalle_Controller(this);

        }


       
    }
}
