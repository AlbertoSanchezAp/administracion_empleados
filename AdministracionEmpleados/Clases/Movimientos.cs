using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Clases
{
    public class Movimientos
    {
        
        public int Movimiento { get; set; }
        public int Empleado { get; set; }
        public string Nombre { get; set; }
            //public int Entregas  { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Rol { get; set; }
        public string Tipo { get; set; }

        public double Monto_Entrega  { get; set; }
    public double Monto_Bonos { get; set; }
    public double Ingreso_Diario { get; set; }
    
    public string Fecha_Captura{ get; set; }

    }
}
