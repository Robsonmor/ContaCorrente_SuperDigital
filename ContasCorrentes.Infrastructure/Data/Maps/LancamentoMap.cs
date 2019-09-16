using ContasCorrentes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasCorrentes.Infrastructure.Data.Map
{
    public class LancamentoMap
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Lancamento>(etd =>
            {
                etd.ToTable("Lancamento");
                etd.HasKey(c => c.LancamentoId).HasName("LancamentoId");
                etd.HasKey(c => c.ContaCorrenteId).HasName("ContaCorrenteId");
                etd.Property(c => c.ContaCorrente).HasColumnName("ContaCorrente");
                etd.Property(c => c.TipoOperacao).HasColumnName("TipoOperacao");
                etd.Property(c => c.Valor).HasColumnName("Valor");
            });
        }
    }
}
