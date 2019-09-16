using System;
using System.Runtime.Serialization;
using ContasCorrentes.Domain.Enumerations;

namespace ContasCorrentes.Domain.Entities
{
    [DataContract]
    [Serializable]
    public class Lancamento
    {
        [DataMember]
        public int LancamentoId { get; set; }
        [DataMember]
        public int ContaCorrenteId { get; set; }
        [DataMember]
        public TipoOperacao TipoOperacao { get; set; }
        [DataMember]
        public double Valor { get; set; }

        public ContaCorrente ContaCorrente { get; set; }
    }
}
