using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InterfazAlumnos.Models;
using InterfazAlumnos.Consumers;

namespace InterfazAlumnos.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly AlumnoConsumer consumer;

        public HomeController(AlumnoConsumer co)
        {
            consumer=co;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        

        }

        public async Task<IActionResult> ListaAlumnos(){
            var listado=await consumer.ListadoUsuarios();
            return View(listado);
        }

        public async Task<IActionResult> Alumno(int? id){
            if(id==null){
                return NotFound();
            }
            var alumno=await consumer.BuscarAlumno(id);
            if(alumno ==null){
                return NotFound();
            }
            return View(alumno);
        }

        public async Task<IActionResult> ListaCasas(){
            var listaCasas=await consumer.ListadoCasas();
            return View(listaCasas);
        }

        public async Task<IActionResult> Casa(int? id){
            if(id==null){
                return NotFound();
            }
            var casa=await consumer.Casa(id);

            if(casa==null){
                return NotFound();
            }
            return View(casa);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
