using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Share.Entities
{
    public class MaquinariaTarea
    {
        public int Id { get; set; } 

        public Tarea Tarea { get; set; }    

        public Maquinaria Maquinaria { get; set; }
    }
}
