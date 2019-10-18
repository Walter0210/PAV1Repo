using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_PAV_3k2.Repositorios
{
    class RepositorioCursos
    {
        private accesoBD _BD;

        public RepositorioCursos()
        {
            _BD = new accesoBD();
        }

        public DataTable ObtenerCursos()
        {
            //se define una variable local a la función <sqltxt> del tipo <string> donde en el 
            //momento de su creación se le asigan su contenido, que es el comando SELECT  
            //necesario para poder establecer la veracidad del usuario.
            string sqltxt = "SELECT * FROM CURSOS";

            return _BD.consulta(sqltxt);
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
