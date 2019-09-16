using ContasCorrentes.Domain.Entities;
using ContasCorrentes.Domain.Enumerations;
using ContasCorrentes.Domain.Interfaces.Repositories;
using ContasCorrentes.Domain.Interfaces.Schemas;
using ContasCorrentes.Domain.Interfaces.Services;
using ContasCorrentes.Domain.Interfaces.Validators;
using ContasCorrentes.Domain.Schemas;
using ContasCorrentes.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasCorrentes.Domain.Services
{
    public class LancamentoService: ILancamentoService
    {
        protected readonly ILancamentoRepository _lancamentoRepository;
        protected readonly IContaCorrenteRepository _contaCorrenteRepository;
        protected IValidator<ContaCorrente, LancamentoSchema> _validacao;

        public LancamentoService(ILancamentoRepository lancamentoRepository, 
            IContaCorrenteRepository contaCorrenteRepository,
            IValidator<ContaCorrente, LancamentoSchema> validator)
        {
            _lancamentoRepository = lancamentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
            _validacao = validator;
        }

        public void Credito(ContaCorrente entity, LancamentoSchema schema)
        {
            Lancamento lancamento = new Lancamento()
            {
                ContaCorrenteId = schema.ContaOrigemId,
                TipoOperacao = TipoOperacao.Credito,
                Valor = schema.Valor
            };

            _lancamentoRepository.Create(lancamento);

            entity.Saldo += schema.Valor;
            _contaCorrenteRepository.Update(entity);
        }

        public void Debito(ContaCorrente entity, LancamentoSchema schema)
        {
            Lancamento lancamento = new Lancamento()
            {
                ContaCorrenteId = schema.ContaOrigemId,
                TipoOperacao = TipoOperacao.Debito,
                Valor = schema.Valor
            };

            _lancamentoRepository.Create(lancamento);

            entity.Saldo -= schema.Valor;
            _contaCorrenteRepository.Update(entity);
        }

        public string Lancamento(LancamentoSchema lancamentoSchema)
        {
            ContaCorrente contaOrigem = _contaCorrenteRepository.Find(lancamentoSchema.ContaOrigemId);

            if (_validacao.Validator(contaOrigem, lancamentoSchema))
            {
                this.Debito(contaOrigem, lancamentoSchema);
                this.Credito(contaOrigem, lancamentoSchema);

                return "Operação efetuada com sucesso!";
            }
            else
                return _validacao.Informacao;
        }

        public void Dispose()
        {
            _lancamentoRepository.Dispose();
            _contaCorrenteRepository.Dispose();
        }
    }
}
