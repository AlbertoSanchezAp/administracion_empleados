using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Clases
{
    public class RegistraMovimiento
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public int EntregasDiaria { get; set; }
        public DateTime FechaCaptura { get; set; }
        public int Turno { get; set; }

        public string BusquedaNombre { get; set; }

        public RegistraMovimiento() { }

        public RegistraMovimiento(int idEmpleado, String nombreEmpleado, int entregasDiaria, DateTime fecha, int turno)
        {
            this.IdEmpleado = idEmpleado;
            this.NombreEmpleado = nombreEmpleado;
            this.EntregasDiaria = entregasDiaria;
            this.FechaCaptura = fecha;
            this.Turno= turno;

        }

    }
}
