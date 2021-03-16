using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Clases
{
    public class Roles
    {
        public int idRoles { get; set; }
        public string Descripcion { get; set; }

        public Roles(int id, string descripcion)
        {
            this.idRoles = id;
            this.Descripcion = descripcion;

        }
    }
}
