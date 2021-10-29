using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using webapiRecursiva.Models;

namespace webapiRecursiva.Repositorio
{
    public class RSocios
    {
        public IEnumerable<Socio> ObtenerClientes()
        {
            string[] lineas = File.ReadAllLines("./Data/socios.csv");
            List<Socio> ss = new List<Socio>();
            foreach(var linea in lineas)
            {
                var valores = linea.Split(';');
                ss.Add(new Socio { Nombre = valores[0], Edad = Convert.ToInt32( valores[1]), Equipo = valores[2],EstadoCivil=valores[3],Estudios=valores[4] });
            }
            return ss;
        }
        

    }
}
