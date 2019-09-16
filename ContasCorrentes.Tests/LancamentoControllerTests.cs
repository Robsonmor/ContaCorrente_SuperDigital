using ContasCorrentes.Domain.Interfaces.Services;
using ContasCorrentes.Domain.Schemas;
using System.Linq;
using Xunit;

namespace ContasCorrentes.Tests
{
    public class LancamentoControllerTests
    {
        protected readonly ILancamentoService _lancamentoService;

        public LancamentoControllerTests(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        [Fact]
        public void OperacaoRealizada()
        {
            LancamentoSchema _mock = new LancamentoSchema()
            {
                ContaDestinoId = 1,
                ContaOrigemId = 1,
                Valor = 10
            };

            var retorno = _lancamentoService.Lancamento(_mock);

            Assert.Equal("Operação efetuada com sucesso!", retorno);
        }

        [Fact]
        public void SaldoInsuficiente()
        {
            LancamentoSchema _mock = new LancamentoSchema()
            {
                ContaDestinoId = 1,
                ContaOrigemId = 1,
                Valor = 100000000000
            };

            string retorno = _lancamentoService.Lancamento(_mock);

            Assert.Equal("Conta não possui saldo para realizar a transação.", retorno);
        }
    }
}
