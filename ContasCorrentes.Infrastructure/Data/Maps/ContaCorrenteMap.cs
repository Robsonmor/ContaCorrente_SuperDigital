using ContasCorrentes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContasCorrentes.Infrastructure.Data.Map
{
    public class ContaCorrenteMap
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<ContaCorrente>(etd =>
            {
                etd.ToTable("ContaCorrente");
                etd.HasKey(c => c.ContaCorrenteId).HasName("ContaCorrenteId");
                etd.Property(c => c.Agencia).HasColumnName("Agencia");
                etd.Property(c => c.Conta).HasColumnName("Conta");
                etd.Property(c => c.Saldo).HasColumnName("Saldo");
            });
        }
    }
}
