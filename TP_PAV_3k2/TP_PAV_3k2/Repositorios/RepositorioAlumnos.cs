using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PAV_3k2.Clases;

namespace TP_PAV_3k2.Repositorios
{
    class RepositorioAlumnos
    {
        private accesoBD _BD;

        public RepositorioAlumnos()
        {
            _BD = new accesoBD();
        }

        /*public DataTable ObtenerAlumnos()
        {
            //se define una variable local a la función <sqltxt> del tipo <string> donde en el 
            //momento de su creación se le asigan su contenido, que es el comando SELECT  
            //necesario para poder establecer la veracidad del usuario.
            string sqltxt = "SELECT ID, NOMBRE, APELLIDO FROM ALUMNOS";

            return _BD.consulta(sqltxt);
        }*/

        /*public DataTable ObtenerAlumnosNombres()
        {
            //se define una variable local a la función <sqltxt> del tipo <string> donde en el 
            //momento de su creación se le asigan su contenido, que es el comando SELECT  
            //necesario para poder establecer la veracidad del usuario.
            string sqltxt = "SELECT ID, NOMBRE+' '+APELLIDO as nombre FROM ALUMNOS";

            return _BD.consulta(sqltxt);
        }*/

        public Alumno ObtenerAlumnoId(int idAlumno)
        {
            string sqltxt = $"SELECT * FROM ALUMNOS WHERE ID={idAlumno}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var alumno = new Alumno();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                alumno.id = int.Parse(fila.ItemArray[0].ToString());
                alumno.apellido = fila.ItemArray[1].ToString();
                alumno.nombre= fila.ItemArray[2].ToString();
                alumno.NombreCompleto= fila.ItemArray[2].ToString()+" "+ fila.ItemArray[1].ToString();
            }
            return alumno;
        }

        public List<Alumno> ObtenerAlumnosNombresID(DataTable idAlumnos)
        {
            var alumnos = new List<Alumno>();
            foreach (DataRow fila in idAlumnos.Rows)
            {
                if (fila.HasErrors)
                    continue;
                var alumno = new Alumno();
                alumno.id = int.Parse(fila["idAlumno"].ToString());                
                alumnos.Add(ObtenerAlumnoId(alumno.id));
                /*string sqltxt = $"SELECT ID, NOMBRE+' '+APELLIDO as nombre FROM ALUMNOS WHERE ID='{alumno.id}'";
                _BD.consulta(sqltxt);*/
                
            }
                

            return alumnos;
        }

        public List<Alumno> ObtenerAlumnosconidCurso(string idCurso)
        {           
            
            string sqltxt = $"SELECT idAlumno FROM cursos_alumno WHERE idCurso={idCurso}";
            
            return ObtenerAlumnosNombresID(_BD.consulta(sqltxt));


        }

        /*public TipoCombustible ObtenerTipoCombustible(string TipoCombustibleId)
        {
            string sqltxt = $"SELECT * FROM dbo.TipoCombustible WHERE idTipoCombustible={TipoCombustibleId}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var tipoCombustible = new TipoCombustible();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                tipoCombustible.Id = int.Parse(fila.ItemArray[0].ToString());
                tipoCombustible.Nombre = fila.ItemArray[1].ToString();
            }
            return tipoCombustible;
        }*/


    }
}
