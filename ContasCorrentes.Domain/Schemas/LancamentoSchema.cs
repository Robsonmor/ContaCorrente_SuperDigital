using ContasCorrentes.Domain.Interfaces.Schemas;

namespace ContasCorrentes.Domain.Schemas
{
    public class LancamentoSchema: ISchema
    {
        public int ContaOrigemId { get; set; }
        public int ContaDestinoId { get; set; }
        public double Valor { get; set; }
    }
}
