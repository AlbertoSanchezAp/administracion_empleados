using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Models
{
    public class NominaModel
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }

        public double Ingresos { get; set; }
        public double Sueldo { get; set; }
        public double Despensa { get; set; }

        public double Deducciones { get; set; }

        public double ISR { get; set; }

        public double Total_Pagar { get; set; }
    }
}
