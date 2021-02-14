using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uaaloo.Model
{
    public class Cliente
    {
        public int Id {get; set;} = 0; 
        public string Nombre {get; set;}
        public string Apellido {get; set;} = "";
        public string Direccion {get; set;} = "";
    }
}