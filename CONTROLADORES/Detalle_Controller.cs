using PROYECTO_BIBLIOTECA.MODELOS.DAO;
using PROYECTO_BIBLIOTECA.MODELOS.ENTIDADES;
using PROYECTO_BIBLIOTECA.VISTAS;
using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace PROYECTO_BIBLIOTECA.CONTROLADORES
{
    public class Detalle_Controller
    {

        UsuarioDao usuarioDao = new UsuarioDao();
        Usuario user = new Usuario();
        DETALLE VISTAS;

        public Detalle_Controller(Detalle view)
        {
                VISTAS = view;

            VISTAS.Load += new EventHandler(Detalle);
        }


        private void Detalle(object sender, EventArgs e)
        {
            Details();
        }

        private void Details()
        {
            VISTAS.RegistrardataGridView.DataSource = UsuarioDao.Detalle();
        }
    }
}
