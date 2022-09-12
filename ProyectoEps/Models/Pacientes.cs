using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEps.Models
{
    public class Pacientes
    {
        [Key]
        public int nmid { get; set; }
        public int nmid_persona { get; set; }
        public int nmid_medicotra { get; set; }
        public string dseps { get; set; }
        public string dsarl { get; set; }
        public DateTime feregistro { get; set; }
        public DateTime febaja { get; set; }
        public string cdusuario { get; set; }
        public string dscondicion { get; set; }

    }
}
