using ContasCorrentes.Domain.Entities;
using ContasCorrentes.Domain.Interfaces.Validators;
using ContasCorrentes.Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasCorrentes.Domain.Validators
{
    public class ContaCorrenteDebitoValidator: IValidator<ContaCorrente, LancamentoSchema>
    {
        public string Informacao { get; set; }

        public bool Validator(ContaCorrente entity, LancamentoSchema schema)
        {
            var retorno = true;

            if (entity != null)
            {
                if (entity.Saldo < schema.Valor)
                {
                    Informacao = string.Format("Conta não possui saldo para realizar a transação.");
                    return false;
                }
            }

            return retorno;
        }
    }
}
