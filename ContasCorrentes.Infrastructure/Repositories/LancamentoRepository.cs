using ContasCorrentes.Domain.Entities;
using ContasCorrentes.Domain.Interfaces.Repositories;
using ContasCorrentes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasCorrentes.Infrastructure.Repositories
{
    public class LancamentoRepository : Repository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(EFContext context) :
            base(context)
        {

        }
    }
}
