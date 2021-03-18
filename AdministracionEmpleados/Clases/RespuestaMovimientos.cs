using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministracionEmpleados.Models;

namespace AdministracionEmpleados.Clases
{
    public class RespuestaMovimientos
    {
        /// Movimientos Movimientos { get; set; }
        public List<Movimientos> Movimientos { get; set; }
        public List<Empleados> Empleados { get; set; }

    }
}
