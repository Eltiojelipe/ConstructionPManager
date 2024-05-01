using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Share.Entities
{
    public class Equipos_Proy_Construccion
    {
        public int Id { get; set; } 

        public Equipos_Construccion equipos { get; set; }

        public Proyecto_Construccion proyecto { get; set; }
    }
}
