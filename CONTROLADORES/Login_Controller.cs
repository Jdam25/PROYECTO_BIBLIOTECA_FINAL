using PROYECTO_BIBLIOTECA.MODELOS.DAO;
using PROYECTO_BIBLIOTECA.MODELOS.ENTIDADES;
using PROYECTO_BIBLIOTECA.VISTAS;
using System;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;

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
            UsuarioDao userDAO = new UsuarioDao();
            Usuario user = new Usuario();
            user.Usuarios = VISTAS.textBox1.Text;
            user.Contraseña = EncriptarClave(VISTAS.txtContraseña.Text);

            bool valido = userDAO.ValidarUsuario(user);
            if (valido)
            {
                MessageBox.Show("Usuario Correcto");
                MENU menu = new MENU();
                VISTAS.Hide();
                System.Security.Principal.GenericIdentity identidad = new System.Security.Principal.GenericIdentity(VISTAS.txtContraseña.Text);
                System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identidad, null);
                System.Threading.Thread.CurrentPrincipal = principal;

                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario Incorrecto");
            }

        }
        public static string EncriptarClave(string str)
        {
            string cadena = str + "MiClavePersonal";
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(cadena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }


    }
}
