﻿using AdministracionEmpleados.Clases;
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
        String URL_alta = "http://localhost:7801/empleados_api/v1/alta_empleado";
        String URL_actualiza = "http://localhost:7801/empleados_api/v1/actualiza/empleado";
        String URL_baja = "http://localhost:7801/empleados_api/v1/baja/empleado";

        public ActionResult Index()
        {
            List<EmpleadoModel> empleados = new List<EmpleadoModel>();
            empleados.Add( new EmpleadoModel(10001, "nombre completo",12,"Hombre","1","1"));
            empleados.Add(new EmpleadoModel(10002, "nombre cppm", 12, "Mujer", "1", "1"));

            return View(empleados);
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
             
                if (sucontratadoDespensa.Equals("1")) {
                    emp.ValeDespensa = 4;
                }
                else {
                    emp.ValeDespensa = 0;
                }
                // calcular sueldo mensual
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
        public ActionResult ActualizarEmpleados(int id, EmpleadoModel emp)
        {
            int i = id;
            emp.IdEmpleado = id;
            return View(emp);
        }

        [HttpPost]
        public ActionResult ActualizarEmpleados(EmpleadoModel emp)
        {

            Respuesta respJson = new Respuesta();
            int jornadaLaboralHoras = 8;

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
                // Handle error
            }
            
            return View();
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