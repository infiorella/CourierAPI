using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnionStarAPI.Models;

namespace UnionStarAPI.Data
{
    public class UnionStarContext: DbContext
    {
        public UnionStarContext(DbContextOptions<UnionStarContext> option): base(option)
        {

        }

        //Modelos
        public DbSet<Cotizacion> Cotizacion { get; set; }
        public DbSet<Interesado> Interesado { get; set; }
        public DbSet<Objeto> Objeto { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Servicio> Servicio { get; set; }

        public DbSet<Cotizaciones> Cotizaciones { get; set; }
    }
}
