using ContasCorrentes.Domain.Entities;
using ContasCorrentes.Domain.Schemas;
using System;
using System.Collections.Generic;

namespace ContasCorrentes.Domain.Interfaces.Services
{
    public interface ILancamentoService : IDisposable
    {
        string Lancamento(LancamentoSchema lancamentoSchema);
        void Debito(ContaCorrente entity, LancamentoSchema schema);
        void Credito(ContaCorrente entity, LancamentoSchema schema);
    }
}
