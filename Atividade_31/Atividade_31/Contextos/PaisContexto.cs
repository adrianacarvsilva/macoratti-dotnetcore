using Atividade_31.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividade_31.Contextos
{
    public class PaisContexto : DbContext
    {
        public PaisContexto(DbContextOptions<PaisContexto> options) : base(options)
        { 
        }
        public virtual System.Data.Entity.DbSet<PaisModel> Paises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaisModel>().ToTable("Paises"); // or whatever tablename you have
        }
    }
}
