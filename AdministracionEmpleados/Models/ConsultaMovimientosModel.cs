using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministracionEmpleados.Clases;
namespace AdministracionEmpleados.Models
{
    public class ConsultaMovimientosModel
    {
        public int Movimiento { get; set; }
        public int Empleado { get; set; }
        public string Nombre { get; set; }
        //public int Entregas  { get; set; }
        public double Monto_Entrega { get; set; }
        public double Monto_Bonos { get; set; }
        public double Ingreso_Diario { get; set; }
        public string Fecha_Captura { get; set; }
        public ConsultaMovimientosModel() { }
        public ConsultaMovimientosModel(int idMovimientos,int idEmpleado,string nombre,int entrega,double totalEntrega,double totalBono,double ingreso,string fecha ) {

            this.Movimiento = idMovimientos;
            this.Empleado = idEmpleado;
            this.Nombre = nombre;
           // this.Entregas = entrega;
            this.Monto_Entrega = totalEntrega;
            this.Monto_Bonos = totalBono;
            this.Ingreso_Diario = ingreso;
            this.Fecha_Captura = fecha;
        }


    }
}
