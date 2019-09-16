using ContasCorrentes.Domain.Entities;
using ContasCorrentes.Domain.Interfaces.Validators;
using ContasCorrentes.Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContasCorrentes.Domain.Validators
{
    class ContaCorrenteCreditoValidator : IValidator<ContaCorrente, LancamentoSchema>
    {
        public string Informacao { get; set; }

        public bool Validator(ContaCorrente entity, LancamentoSchema schema)
        {
            return true;
        }
    }
}
