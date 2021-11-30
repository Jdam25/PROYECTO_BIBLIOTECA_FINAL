using PROYECTO_BIBLIOTECA.MODELOS.DAO;
using PROYECTO_BIBLIOTECA.MODELOS.ENTIDADES;
using PROYECTO_BIBLIOTECA.VISTAS;
using System;
using System.Windows.Forms;
using System.Text;

namespace PROYECTO_BIBLIOTECA.CONTROLADORES
{
    public class Login_Controller
    {
        // llamamos el using y declaramos el objeto
        LOGIN VISTAS;

        //Creamos el constructor
        public Login_Controller ( LOGIN view )
        {
            VISTAS = view;
            VISTAS.btnLogin.Click += new EventHandler(ValidarUsuario);
        }

        //Creación de Método Para validar si el usuario ingresado es correcto:
        public void ValidarUsuario(object serder, EventArgs e)
        {
            UsuarioDao userDao = new UsuarioDao();
            Usuario user = new Usuario();
            user.Usuarios = VISTAS.textBox1.Text;
            // user.Contraseña = EncriptarClave(Vistas.txtContraseña.Text);
            user.Contraseña = VISTAS.textBox2.Text;
            bool valido = userDao.ValidarUsuario(user);
            if (valido)
            {
                // MessageBox.Show("Usuario Correcto");
                MENU menu = new MENU();
                VISTAS.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario Incorrecto");
            }

        }

    }
}
