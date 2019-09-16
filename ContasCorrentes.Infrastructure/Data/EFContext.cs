using ContasCorrentes.Domain.Entities;
using ContasCorrentes.Infrastructure.Data.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ContasCorrentes.Infrastructure.Data
{
    public class EFContext : DbContext
    {
        public EFContext()
        { }
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        { }

        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("ContasCorrentes");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
