using PROYECTO_BIBLIOTECA.MODELOS.ENTIDADES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PROYECTO_BIBLIOTECA.MODELOS.DAO
{
    public  class UsuarioDao:Conexion 
   {
        SqlCommand comando = new SqlCommand();

        public bool ValidarUsuario(Usuario user)
        {

            bool valido = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT 1 FROM USUARIOS WHERE USUARIO= @Usuario and CONTRASEÑA= @Contraseña");
                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = user.Usuarios ;
                comando.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 80).Value = user.Contraseña;
                //comando.Parameters.Add("Estado", SqlDbType.NVarChar, 50).Value = user.Estado;
                valido = Convert.ToBoolean(comando.ExecuteScalar());
                MiConexion.Close();

            }
            catch (Exception)
            {
            }
            return valido;
        }

        public DataTable Detalle()
        {
            DataTable rt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT *  FROM REGISTRAR");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                SqlDataReader dr = comando.ExecuteReader();
                rt.Load(dr);
            }
            catch (Exception)
            {
            }

            return rt;
        }
    }
}
