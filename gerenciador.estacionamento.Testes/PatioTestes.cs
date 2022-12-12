using gerenciador.estacionamento.Estacionamento.Modelos;
using Xunit;

namespace gerenciador.estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Ranimy";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "xus-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo); //Cria uma entrada de veiculo
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa); //Cria uma saida e calcula o faturamento

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
    }
}
