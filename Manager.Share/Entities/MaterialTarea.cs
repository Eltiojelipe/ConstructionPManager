using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Share.Entities
{
    public class MaterialTarea
    {
        public int Id { get; set; } 

        public Material Material { get; set; }  

        public Tarea Tarea { get; set; }
    }
}
