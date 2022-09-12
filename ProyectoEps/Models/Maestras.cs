using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEps.Models
{
    public class Maestras

    {
        [Key]
        public string nmaestro { get; set; }
        public string cdmaestro { get; set; }
        public string dsmaestro { get; set; }
        public DateTime febaja { get; set; }
    }
}
