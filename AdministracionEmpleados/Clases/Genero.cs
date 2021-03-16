using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Models
{
    public class Genero
    {
        public int idGenero { get; set; }
        public string Descripcion { get; set; }

        public Genero(int id,string sexo) {

            this.idGenero = id;
            this.Descripcion = sexo;

        }
        

    }
}
