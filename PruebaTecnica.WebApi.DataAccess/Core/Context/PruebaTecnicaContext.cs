
using PruebaTecnica.WebApi.DataAccess.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PruebaTecnica.WebApi.DataAccess.Core.Context
{
    public class PruebaTecnicaContext : DbContext
    {
        public PruebaTecnicaContext() : base("PruebaTecnicaDatabase") { }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<TipoDeIdentificacion> TiposDeIdentificacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<TipoDeIdentificacion>().ToTable("TiposDeIdentificacion");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        }
    }
}
