using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministracionEmpleados.Models
{
    public class EmpleadoModel
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string RolEmpleado { get; set; }
        public string TipoEmpleado { get; set; }

        public double SueldoBaseHora { get; set; }

        public double PagoHoraEntrega { get; set; }

        public double BonoHora { get; set; }
        public int ValeDespensa { get; set; }
        public double SueldoBase { get; set; }

        public List<SelectListItem> LstGenero { get; set; }
        public List<SelectListItem> LstTipoEmpleado{ get; set; }
        public List<SelectListItem> LstRoles { get; set; }

        public EmpleadoModel() { }

        public EmpleadoModel(int idEmpleado,String nombreEmpleado, int edad, String sexo, string rolEmpleado, string tipoEmpleado) {
            this.IdEmpleado = idEmpleado;
            this.NombreEmpleado = nombreEmpleado;
            this.Edad = edad;
            this.Sexo = sexo;
            this.RolEmpleado= rolEmpleado;
            this.TipoEmpleado = tipoEmpleado;
        }

    }
}
