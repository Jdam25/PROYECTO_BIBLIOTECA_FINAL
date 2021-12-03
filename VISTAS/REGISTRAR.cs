using PROYECTO_BIBLIOTECA.CONTROLADORES;
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
    public partial class REGISTRAR : Form
    {
        public REGISTRAR()
        {
            InitializeComponent();
            Cliente_Controller controlador = new Cliente_Controller(this);
        }

    }
}
