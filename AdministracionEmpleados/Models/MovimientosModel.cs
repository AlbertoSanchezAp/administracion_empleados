using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Models
{
    public class MovimientosModel
     {

        public int IdMovimiento { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string RolEmpleado { get; set; }
        public string TipoEmpleado { get; set; }
        public int EntregasDiaria { get; set; }
        public double BonoEntrega { get; set; }
        public double SubTotalEntregaDiaria { get; set; } 
        public DateTime FechaCaptura { get; set; }
        public int Turno { get; set; }

        public string BusquedaNombre{ get; set; }

        public MovimientosModel() { }

        public MovimientosModel(int idEmpleado, String nombreEmpleado, int edad, String sexo, string rolEmpleado, string tipoEmpleado)
        {
            this.IdEmpleado = idEmpleado;
            this.NombreEmpleado = nombreEmpleado;
            this.Edad = edad;
            this.Sexo = sexo;
            this.RolEmpleado = rolEmpleado;
            this.TipoEmpleado = tipoEmpleado;
        }
    }
}
