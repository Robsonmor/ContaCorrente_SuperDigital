using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ContasCorrentes.Domain.Entities
{
    public class ContaCorrente
    {
        [DataMember]
        public int ContaCorrenteId { get; set; }
        [DataMember]
        public int Conta { get; set; }
        [DataMember]
        public int Agencia { get; set; }
        [DataMember]
        public double Saldo { get; set; }

        public IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}
