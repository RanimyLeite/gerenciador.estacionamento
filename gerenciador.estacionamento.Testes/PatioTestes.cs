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

        [Theory] //Permite que o método de teste seja rodado várias vezes usando as informações dos InLineDatas como parametros.
        [InlineData("Ranimy Leite", "OHD-5468", "Preto", "Gol")]
        [InlineData("Kassia Andrade", "GVB-5468", "Verde", "Renegade")]
        [InlineData("André Arruda", "SDG-5468", "Azul", "Chevet")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo); //Cria uma entrada de veiculo
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa); //Cria uma saida e calcula o faturamento

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
    }
}
