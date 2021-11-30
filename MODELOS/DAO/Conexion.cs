using System.Configuration;
using System.Data.SqlClient;

namespace PROYECTO_BIBLIOTECA.MODELOS.DAO
{
    public class Conexion
    {
        protected SqlConnection MiConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BibliotecaConexion"].ConnectionString);
    }
}
