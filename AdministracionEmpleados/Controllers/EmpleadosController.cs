using AdministracionEmpleados.Clases;
using AdministracionEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace AdministracionEmpleados.Controllers
{

    public class EmpleadosController : Controller
    {
        String URL_alta = "http://localhost:7800/empleados_api/v1/alta_empleado";
        String URL_actualiza = "http://localhost:7800/empleados_api/v1/actualiza/empleado";
        String URL_baja = "http://localhost:7800/empleados_api/v1/baja/empleado";
        String URL_consulta_Empleados = "http://localhost:7800/empleados_api/v1/consulta/empleado";
        public ActionResult Index()
        {
            
            List<Empleados> emp = new List<Empleados>();
            emp = consultaEmpleados();
            if (!emp.Equals(null))
            {
                return View(emp);
            }
            else
            {
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult Index(EmpleadoModel emp)
        {
            
            return View();
        }

        // GET: HomeController1
        public ActionResult AltaEmpleado()
        {

            EmpleadoModel emp = new EmpleadoModel();
            emp = cargarInfo();
            return View(emp);
       
        }
       
 
        // GET: HomeController1
        [HttpPost]
        public ActionResult AltaEmpleado(EmpleadoModel emp)
        {
            Respuesta respJson = new Respuesta();
                int jornadaLaboralHoras = 8;
                String sucontratadoDespensa = emp.TipoEmpleado;
                String rol = emp.RolEmpleado;
                emp.BonoHora = 10.00;

            if (rol.Equals("3")) {
                    emp.BonoHora = 0.00;
                } else if (rol.Equals("2")) {
                    emp.BonoHora = 5.00;
                }

                if (sucontratadoDespensa.Equals("1")) {
                    emp.ValeDespensa = 4;
                }
                else {
                    emp.ValeDespensa = 0;
                }
           
                if (emp.Sexo.Equals("1"))
                {
                    emp.Sexo = "Hombre";
                }
                else {
                    emp.Sexo = "Mujer";
                }

                emp.SueldoBaseHora = 30.00;
                emp.PagoXEntrega = 5.00;
                double sueldoBaseMensual= (emp.SueldoBaseHora * jornadaLaboralHoras) * 30;
                emp.SueldoBase = sueldoBaseMensual;
                
               
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL_alta);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
            
                 String JsonRequest = JsonSerializer.Serialize<EmpleadoModel>(emp);                                 
                 using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                 {
                     streamWriter.Write(JsonRequest);
                     streamWriter.Flush();
                     streamWriter.Close();
                 }

                 try
                 {
                     using (WebResponse response = request.GetResponse())
                     {
                         using (Stream strReader = response.GetResponseStream())
                         {
                        if (strReader == null) return View();
                             using (StreamReader objReader = new StreamReader(strReader))
                             {
                                 string responseBody = objReader.ReadToEnd();
                                 respJson = JsonSerializer.Deserialize<Respuesta>(responseBody);
                                Console.WriteLine(responseBody);
                            return RedirectToAction("Index");
                        }
                         }
                     }
                 }
                 catch (WebException ex)
                 {
                     // Handle erro
                     // r
                 }
            
            emp = cargarInfo();
            return View(emp);
            
        }
        
        public ActionResult ActualizarEmpleados(int id, string nom)
        {

            Empleados emp = new Empleados();
            emp.Empleado = id;
            emp.Nombre = nom;

            EmpleadoModel empleadosAct = new EmpleadoModel();
            empleadosAct = cargarInfo();
            empleadosAct.IdEmpleado = emp.Empleado;
            empleadosAct.NombreEmpleado = emp.Nombre;

            return View(empleadosAct); 

        }

        [HttpPost]
        public ActionResult ActualizarEmpleados(EmpleadoModel emp)
        {

            Respuesta respJson = new Respuesta();

            int jornadaLaboralHoras = 8;
            String sucontratadoDespensa = emp.TipoEmpleado;
            String rol = emp.RolEmpleado;
            emp.ValeDespensa = 4;
            
            if (rol.Equals("3"))
            {
                emp.BonoHora = 0.00;
            }
            if (sucontratadoDespensa.Equals("0"))
            {
                emp.ValeDespensa = 0;
            }
            
            // calcular sueldo mensual


            double sueldoBaseMensual = (emp.SueldoBaseHora * jornadaLaboralHoras) * 30;
            emp.SueldoBase = sueldoBaseMensual;
            emp.Sexo = "";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL_actualiza);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            String JsonRequest = JsonSerializer.Serialize<EmpleadoModel>(emp);
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonRequest);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return RedirectToAction("Index"); 
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            respJson = JsonSerializer.Deserialize<Respuesta>(responseBody);
                            Console.WriteLine(responseBody);
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }

            return RedirectToAction("Index");
        }

        public ActionResult BajaEmpleado(int id,string nom, int ed, string sex, string rol, string tipo, EmpleadoModel emp)
        {
    
            int i = id;
            emp.IdEmpleado = id;
            emp.NombreEmpleado = nom;
            emp.Edad = ed;
            emp.Sexo = sex;
            emp.RolEmpleado = rol;
            emp.TipoEmpleado = tipo;

            return View(emp);
        }


        [HttpPost]
        public ActionResult BajaEmpleado(int id)
        {

                Respuesta respJson = new Respuesta();
                Baja bajaEmpleado = new Baja();
                bajaEmpleado.IdEmpleado = id;
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL_baja);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
            
                 String JsonRequest = JsonSerializer.Serialize<Baja>(bajaEmpleado);                                 
                 using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                 {
                     streamWriter.Write(JsonRequest);
                     streamWriter.Flush();
                     streamWriter.Close();
                 }

                 try
                 {
                     using (WebResponse response = request.GetResponse())
                     {
                         using (Stream strReader = response.GetResponseStream())
                         {
                        if (strReader == null) return View();
                             using (StreamReader objReader = new StreamReader(strReader))
                             {
                                 string responseBody = objReader.ReadToEnd();
                                 respJson = JsonSerializer.Deserialize<Respuesta>(responseBody);
                                Console.WriteLine(responseBody);
                             return RedirectToAction("Index");
                            }
                         }
                     }
                 }
                 catch (WebException ex)
                 {
                     // Handle erro
                     // r
                 }
            

            // crear servicio baja
           ///return View();
            return RedirectToAction("Index");
        }



        public List<Empleados> consultaEmpleados()
        {
            ConsultaEmpleados mov = new ConsultaEmpleados();
            RespuestaEmpleados respJson = new RespuestaEmpleados();
           
            HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(URL_consulta_Empleados);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            String JsonRequest = JsonSerializer.Serialize<ConsultaEmpleados>(mov);
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonRequest);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {


                    
                    using (Stream strReader = response.GetResponseStream())
                    {

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            respJson = JsonSerializer.Deserialize<RespuestaEmpleados>(responseBody);
                            Console.WriteLine(responseBody);
                            if (respJson.Empleados.Equals(null)) {
                                Console.WriteLine("No existen Registros de Empleados");
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle erro
                // r
            }

            //  mov2 = respJson.Movimientos;

            return respJson.Empleados;
        }



        public EmpleadoModel cargarInfo(){

            List<Genero> gen = new List<Genero>();
            gen.Add(new Genero(1, "Hombre"));
            gen.Add(new Genero(2, "Mujer"));

            List<SelectListItem> genE = gen.ConvertAll(gen => {
                return new SelectListItem()
                {
                    Text = gen.Descripcion,
                    Value = gen.idGenero.ToString(),
                    Selected = false

                };
            });

            List<Roles> roles = new List<Roles>();
            roles.Add(new Roles(1, "Chofer"));
            roles.Add(new Roles(2, "Cargador"));
            roles.Add(new Roles(3, "Auxiliar"));

            List<SelectListItem> convRoles = roles.ConvertAll(roles => {
                return new SelectListItem()
                {
                    Text = roles.Descripcion,
                    Value = roles.idRoles.ToString(),
                    Selected = false
                };
            });


            List<TipoEmpleado> TipoEmp = new List<TipoEmpleado>();
            TipoEmp.Add(new TipoEmpleado(1, "Interno"));
            TipoEmp.Add(new TipoEmpleado(2, "Externo"));

            List<SelectListItem> convTipoEmp = TipoEmp.ConvertAll(TipoEmp => {
                return new SelectListItem()
                {
                    Text = TipoEmp.Descripcion,
                    Value = TipoEmp.idTipoEmp.ToString(),
                    Selected = false
                };
            });


            EmpleadoModel emp = new EmpleadoModel();
            emp.LstGenero = genE;
            emp.LstRoles = convRoles;
            emp.LstTipoEmpleado = convTipoEmp;
            return emp;

        }
    }
}
