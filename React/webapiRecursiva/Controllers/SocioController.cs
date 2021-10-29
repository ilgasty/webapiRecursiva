using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapiRecursiva.Models;
using webapiRecursiva.Repositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapiRecursiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        // GET: api/<SocioController>
        [HttpGet]
        public IEnumerable<Socio> Get()
        {
            RSocios rpSoc = new RSocios();
            return rpSoc.ObtenerClientes();
            
        }
        [HttpGet("Punto1")]
        public int Get2()
        {
            RSocios rpSoc = new RSocios();
            IEnumerable<Socio> s= rpSoc.ObtenerClientes();
            return s.Count();
        }
        [HttpGet("Punto2")]
        public int GetProdRacing()
        {
            RSocios rpSoc = new RSocios();
            IEnumerable<Socio> s = rpSoc.ObtenerClientes().Where(x=>x.Equipo== "Racing");
             var a=s.GroupBy(item => item.Equipo).Select(group => group.Sum(item => item.Edad)).ToArray();

            return a[0] / s.Count();
        }
        [HttpGet("Punto3")]
        public IEnumerable<Socio> Get100casado()
        {
            RSocios rpSoc = new RSocios();
            IEnumerable<Socio> s = rpSoc.ObtenerClientes().Where(x => x.EstadoCivil == "Casado" && x.Estudios== "Universitario").Take(100).OrderBy(O=> O.Edad);
            

            return s;
        }

        [HttpGet("Punto4")]
        public IEnumerable<Punto4> Get5nombresRiver()
        {
            List<Punto4> p4 = new List<Punto4>();
            RSocios rpSoc = new RSocios();
            var s = rpSoc.ObtenerClientes().Where(x => x.Equipo == "River").GroupBy(g=>g.Nombre).Select(lg =>
                                new {
                                    nombre = lg.Key,
                                    cantidad = lg.Count(),
                                    
                                }).OrderByDescending(ro =>ro.cantidad).Take(5).ToList();
            foreach (var a in s )
            {
                p4.Add(new Punto4 { nombre = a.nombre, cantidad = a.cantidad });

            };

            return p4;
        }

        [HttpGet("Punto5")]
        public IEnumerable<Punto5> Getpunto5()
        {
            List<Punto5> p5 = new List<Punto5>();
            RSocios rpSoc = new RSocios();
            var s = rpSoc.ObtenerClientes().GroupBy(g => g.Equipo).Select(lg =>
                                  new {
                                      equipo = lg.Key,
                                      CantSocio = lg.Count(),
                                      promedioedad = lg.Sum(e => e.Edad) / lg.Count(),
                                      menoredad=lg.Min(mi=>mi.Edad),
                                      mayoredad=lg.Max(ma=>ma.Edad),
                                  }).OrderByDescending(ro => ro.CantSocio).ToList();
            foreach (var a in s)
            {
                p5.Add(new Punto5 { equipo = a.equipo, CantSocio = a.CantSocio,promedioedad=a.promedioedad,menoredad=a.menoredad,mayoredad=a.mayoredad });

            };

            return p5;
        }

        // GET api/<SocioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SocioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SocioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SocioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
