using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CDatos
    {

        SqlConnection cn = new SqlConnection
           (ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public DataTable MostrarVisitas()
        {
            SqlCommand cmd = new SqlCommand("MostrarVisitas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;

        }

        public DataTable MostrarUsuarios()
        {
            SqlCommand cmd = new SqlCommand("MostrarUsuarios", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;

        }


        public DataTable Login(string user,string clave)
        {
            using (SqlCommand cmd = new SqlCommand("Logeo", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user",user);
                cmd.Parameters.AddWithValue("@clave",clave);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tap = new DataTable();
                    da.Fill(tap);
                    return tap;
                }
            }
        }

        public void insertarV(string nombre, string apellido, string carrera, string correo, byte[] foto, string edificios, string aulas,
         string fecha, string motivo)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarVisitas", cn))
                {

                    cmd.CommandText = "InsertarVisitas";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@carrera", carrera);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@foto", foto);
                    cmd.Parameters.AddWithValue("@edificio", edificios);
                    cmd.Parameters.AddWithValue("@aula", aulas);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cn.Close();
                }
            }
        }
        public void insertarUser(string nombre, string apellido, string fechan, string privilegio, string user, string clave)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", cn))
                {

                    cmd.CommandText = "InsertarUsuario";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@f_nacimento", fechan);
                    cmd.Parameters.AddWithValue("@privilegio", privilegio);
                    cmd.Parameters.AddWithValue("@userName", user);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cn.Close();
                }
            }
        }

    }
}
