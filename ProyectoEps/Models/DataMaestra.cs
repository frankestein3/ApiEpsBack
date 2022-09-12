using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEps.Models
{
    public class DataMaestra
    {
        [Key]
        public string nmdato { get; set; }
        public string nmmaestro { get; set; }
        public string cddato { get; set; }
        public string dsdato { get; set; }
        public string cddato1 { get; set; }
        public string cddato2 { get; set; }
        public string cddato3 { get; set; }
        public DateTime febaja { get; set; }

    }
}
