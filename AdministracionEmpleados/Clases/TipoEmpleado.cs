using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Models
{
    public class TipoEmpleado
    {
        public int idTipoEmp { get; set; }
        public string Descripcion { get; set; }

        public TipoEmpleado(int id,string descripcion) {

            this.idTipoEmp = id;
            this.Descripcion = descripcion;
        }
    }
}
