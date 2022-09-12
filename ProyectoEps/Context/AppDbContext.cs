using Microsoft.EntityFrameworkCore;
using ProyectoEps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEps.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Maestras> Maestras { get; set; }
        public DbSet<DataMaestra> DataMaestra { get; set; }


    }
}
