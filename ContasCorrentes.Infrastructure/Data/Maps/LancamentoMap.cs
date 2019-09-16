using ContasCorrentes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasCorrentes.Infrastructure.Data.Map
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamento");
            builder.HasKey(x => x.LancamentoId);
            builder.HasOne(x => x.ContaCorrente).WithMany(x => x.Lancamentos);
        }
    }
}
