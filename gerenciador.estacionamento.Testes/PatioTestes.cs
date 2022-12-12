using gerenciador.estacionamento.Estacionamento.Modelos;
using Xunit;

namespace gerenciador.estacionamento.Testes
{
    public class PatioTestes
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        public PatioTestes()
        {
            //Setup - Preparação do cenário de testes
            //A criação do Setup dessa forma evita a instancia de um novo veiculo e estacionamento em cada Arrange
            veiculo = new Veiculo();
            estacionamento = new Patio();
        }

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
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

        [Theory]
        [InlineData("Ranimy Leite", "OHD-5468", "Preto", "Gol")]
        [InlineData("Luiz Ajota", "ASI-7841", "Azul", "Renegade")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo); //Cria uma entrada de veiculo

            //Act
            estacionamento.PesquisaVeiculoPorPlaca(veiculo.Placa);

            //Assert
            Assert.Equal(placa, veiculo.Placa);
        }
    }
}
