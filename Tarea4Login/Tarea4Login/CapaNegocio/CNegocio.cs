using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CNegocio
    {
        CDatos objetoDatos = new CDatos();
        public DataTable LoginN(string user, string clave)
        {
            return objetoDatos.Login(user,clave);
        }

        public DataTable M_Visitas()
        {
            return objetoDatos.MostrarVisitas();
        }

        public DataTable M_Usuarios()
        {
            return objetoDatos.MostrarUsuarios();
        }
        public void insertarV(string nombre, string apellido, string carrera, string correo, byte[] foto, string edificios, string aulas,
         string fecha, string motivo)
        {
            objetoDatos.insertarV(nombre,apellido,carrera,correo,foto, edificios, aulas, fecha, motivo);
        }

        public void insertarU(string nombre, string apellido, string fechan, string privilegio, string user, string clave)
        {
            objetoDatos.insertarUser(nombre, apellido,fechan, privilegio, user, clave);
        }
    }
}
