using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using uaaloo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace uaaloo.Controllers
{
    // [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {



        List<Cliente> _oClientes = new List<Cliente>(){
            new Cliente(){
                Id=10, Nombre="Umberto", Apellido="Velez", Direccion="Dire"
            },
        }; 
  
    
        [HttpGet]
        public IActionResult Get()
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();


            if (_oClientes.Count == 0){
                return NotFound("No existen clientes cargados en el sistema.");
            }

            // Stop timing
            stopwatch.Stop();

            // Write result
            Console.WriteLine("Tiempo tardado en devolver clientes: {0}", stopwatch.Elapsed);

            // Devolver lista de clientes
            return Ok(_oClientes);

        }


        [HttpGet("obtenerClientePorID")]
        public IActionResult Get(int id)
        {

            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            var oCliente = _oClientes.SingleOrDefault(x=>x.Id == id);
            if (oCliente == null){
                return NotFound("No se encontró el Cliente buscado");
            }

            // Stop timing
            stopwatch.Stop();

            // Write result
            Console.WriteLine("Tiempo tardado en devolver cliente: {0}", stopwatch.Elapsed);

            // Devolver lista de clientes
            return Ok(_oClientes);
        }

        [HttpPost]
        public IActionResult Save(Cliente oCliente)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();


            _oClientes.Add(oCliente);
            if (_oClientes.Count == 0){
                return NotFound("No se encontró datos a agregar");
            }

            // Stop timing
            stopwatch.Stop();

            // Write result
            Console.WriteLine("Tiempo tardado en guardar cliente: {0}", stopwatch.Elapsed);

            // Devolver lista de clientes
            return Ok(_oClientes);


        }

        [HttpDelete]
        public IActionResult eliminarCliente(int id)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            var oCliente = _oClientes.SingleOrDefault(x => x.Id == id);
            _oClientes.Remove(oCliente);

            // Stop timing
            stopwatch.Stop();

            // Write result
            Console.WriteLine("Tiempo tardado en guardar cliente: {0}", stopwatch.Elapsed);

            // Devolver lista de clientes
            return Ok(oCliente);


        }

    }
}