using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Modelss;
using WebApplication2.Modelsss;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Hangares> hangares { get; set; }
        public DbSet<Aviones> aviones { get; set; }
        public DbSet<Piloto> piloto { get; set; }
    }
}
