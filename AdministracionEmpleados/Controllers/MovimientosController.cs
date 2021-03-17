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
        String URL_alta_movimiento = "http://localhost:7801/empleados_api/v1/alta/movimientos";
        String URL_elimina_movimiento = "http://localhost:7801/empleados_api/v1/elimina/movimiento";
        String URL_consulta_movimiento= "http://localhost:7801/empleados_api/v1/consulta/movimientos";
        public ActionResult Index()
        {
            List<MovimientosModel> mov = new List<MovimientosModel>();
            mov.Add(new MovimientosModel(10001, "nombre completo", 12, "Hombre", "Chofer", "Externo"));
            mov.Add(new MovimientosModel(10002, "nombre cppm", 12, "Mujer", "Chofer", "Externo"));

            return View(mov);
            
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
        public ActionResult RegistraMovimiento(int id, string nombre, MovimientosModel mov)
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


                    Console.WriteLine(response);
                    using (Stream strReader = response.GetResponseStream())
                    {
                        
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            respJson = JsonSerializer.Deserialize<RespuestaMovimientos>(responseBody);
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
            NominaModel nom = new NominaModel();
            
            nom.IdEmpleado = 10001;
            nom.NombreEmpleado = "JOSE ALBERTO SANCHEZ";
            nom.Ingresos = 15642.00;
            nom.Sueldo = 520.00;
            nom.Despensa = 520.00;
            nom.Deducciones = 4000.00;
            nom.ISR = 15642.00;
            nom.Total_Pagar = 10460.00;


            return View(nom);

        }
        [HttpPost]
        public ActionResult ConsultaReporteNomina(Movimientos consmov)
        {
            return View();
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

    }
}
