using AdministracionEmpleados.Clases;
using AdministracionEmpleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Controllers
{
    public class MovimientosController : Controller
    {
        // GET: MovimientosController1
        String URL_alta_movimiento = "http://localhost:7800/empleados_api/v1/alta/movimientos";
        String URL_elimina_movimiento = "http://localhost:7800/empleados_api/v1/elimina/movimiento";
        String URL_consulta_empleados = "http://localhost:7800/empleados_api/v1/consulta/empleado";
        String URL_consulta_movimiento= "http://localhost:7800/empleados_api/v1/consulta/movimientos";
        String URL_consulta_reporte= "http://localhost:7800/empleados_api/v1/consulta_nomina";
        
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

        public ActionResult Index(MovimientosModel mov)
        {
            return View();
        }

        // GET: MovimientosController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovimientosController1/Create
        public ActionResult RegistraMovimiento(int id,  string nombre, MovimientosModel mov)
        {
            mov.IdEmpleado = id;
            mov.NombreEmpleado=nombre;

            return View(mov);
            //return View();
        }

        [HttpPost]
        public ActionResult RegistraMovimiento(MovimientosModel mov)
        {
            //
            Respuesta respJson = new Respuesta();
            RegistraMovimiento reg = new RegistraMovimiento();
            reg.IdEmpleado=mov.IdEmpleado;
            reg.NombreEmpleado = mov.NombreEmpleado;
            reg.EntregasDiaria = mov.EntregasDiaria;
            reg.FechaCaptura = mov.FechaCaptura;
            reg.Turno = mov.Turno;

            HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(URL_alta_movimiento);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            String JsonRequest = JsonSerializer.Serialize<RegistraMovimiento>(reg);
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


            return View();
            //return View();
        }

  

        public ActionResult ConsultaMovimientos(int id)
        {

            List<Movimientos> movv = new List<Movimientos>();
            movv = consultaMovimientosEmpleado(id);

            return View(movv);

        }
        [HttpPost]
        public ActionResult ConsultaMovimientos(Movimientos consmov)
        {

            return View();
        }

        public List<Movimientos> consultaMovimientosEmpleado(int id) {

            
            ConsultaMovimientos mov = new ConsultaMovimientos();
            RespuestaMovimientos respJson = new RespuestaMovimientos();
            mov.Id_Empleado = id;
            
            HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(URL_consulta_movimiento);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            
            String JsonRequest = JsonSerializer.Serialize<ConsultaMovimientos>(mov);
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


                    ///Console.WriteLine(response);
                    using (Stream strReader = response.GetResponseStream())
                    {
                        
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            respJson = JsonSerializer.Deserialize<RespuestaMovimientos>(responseBody);
                            if (respJson.Movimientos.Equals(null))
                            {
                                Console.WriteLine("No existen Registros de Empleados");
                            }
                            Console.WriteLine(responseBody);
                            
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

            return respJson.Movimientos;
        }

       

        public ActionResult ConsultaReporteNomina(int id)
        {
            ConsultaEmpleados nomina = new ConsultaEmpleados();

            NominaModel Resp = new NominaModel();
            
            HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(URL_consulta_reporte);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            nomina.IdEmpleado = id;
           

            String JsonRequest = JsonSerializer.Serialize<ConsultaEmpleados>(nomina);
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
                            Resp = JsonSerializer.Deserialize<NominaModel>(responseBody);
                            if (Resp.Equals(null))
                            {

                                Console.WriteLine("Ha ocurrido un Error en la Transaccion del Reporte");
                                return RedirectToAction("Index");
                            }
                            Console.WriteLine(responseBody);
                            //return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle erro
                // r
            }



            return View(Resp);
        }


        // GET: MovimientosController1/Delete/5
        public ActionResult EliminarMovimiento(int idmovi, int id, string nombre)
        {
            ConsultaMovimientosModel mov = new ConsultaMovimientosModel();
            mov.Movimiento = idmovi;
            mov.Empleado = id;
            mov.Nombre = nombre;
            return View(mov);
        }



        [HttpPost]
        public ActionResult EliminarMovimiento(int idMovi, int id, ConsultaMovimientosModel mov)
        {
            // genear servicio baja 
            Respuesta respJson = new Respuesta();
            
            HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(URL_elimina_movimiento);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            mov.Movimiento = idMovi;
            mov.Empleado = id;
            mov.Fecha_Captura = "";


            String JsonRequest = JsonSerializer.Serialize<ConsultaMovimientosModel>(mov);
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
                            if (respJson.Equals(null)) {

                                Console.WriteLine("Ha ocurrido un Error en la Transaccion del Movimiento");
                                return RedirectToAction("Index");
                            }
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



            return View();
        }

        
       public NominaModel obtenerReporteNomina(int id)
        {
            
            NominaModel nomina = new NominaModel();

            
            return nomina;

        }



        public List<Empleados> consultaEmpleados()
        {
            ConsultaEmpleados mov = new ConsultaEmpleados();
            RespuestaEmpleados respJson = new RespuestaEmpleados();

            HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(URL_consulta_empleados);
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


                    Console.WriteLine(response);
                    using (Stream strReader = response.GetResponseStream())
                    {

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            respJson = JsonSerializer.Deserialize<RespuestaEmpleados>(responseBody);
                            Console.WriteLine(responseBody);
                            if (respJson.Empleados.Equals(null))
                            {
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

    }
}
