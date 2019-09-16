using ContasCorrentes.Domain.Entities;
using ContasCorrentes.Domain.Interfaces.Repositories;
using ContasCorrentes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasCorrentes.Infrastructure.Repositories
{
    public class ContaCorrenteRepository : Repository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(EFContext context ) :
            base(context)
        {

        }
    }
}
