using System;
using System.Collections.Generic;
using System.Text;

namespace ContasCorrentes.Domain.Interfaces.Validators
{
    public interface IValidator<TEntity, ISchema> 
        where TEntity : class
    {
        string Informacao { get; set; }

        bool Validator(TEntity entity, ISchema schema);
    }
}
