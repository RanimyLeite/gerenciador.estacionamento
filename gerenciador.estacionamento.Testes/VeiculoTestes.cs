using gerenciador.estacionamento.Estacionamento.Modelos;
using System;
using Xunit;

namespace gerenciador.estacionamento.Testes
{
    public class VeiculoTestes
    {
        public string Proprietario { get; set; }
        public string Cor { get; set; }
        public double Largura { get; set; }
        public string Modelo { get; set; }

        [Fact]
        //Teste do método Acelerar da classe Veiculo
        public void TestaVeiculoAcelerar()
        {
            //Arrange - Criação de variável e instancia de objeto necessário para o teste
            var veiculo = new Veiculo();

            //Act - Teste do método passando um valor
            veiculo.Acelerar(10); 

            //Assert - Checagem do retorno esperado e onde verificar!
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        //Teste do método Frear da classe Veiculo
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Tipo = TipoVeiculo.Automovel;

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaVeiculoPlaca()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Placa = "abc-1234";

            //Assert
            Assert.Equal("abc-1234", veiculo.Placa);

        }

        [Fact]
        public void TestaProprietarioVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Proprietario = "Ranimy";

            //Assert
            Assert.Equal("Ranimy", veiculo.Proprietario);
        }

        [Fact]
        public void TestaHorarioEntrada()
        {
            //Arrange
            var veiculo = new Veiculo();
            var horarioEntrada = DateTime.Now;

            //Act
            veiculo.HoraEntrada = horarioEntrada;

            //Assert
            Assert.Equal(horarioEntrada, veiculo.HoraEntrada);
        }

        [Fact]
        public void TestaHorarioSaida()
        {
            //Arrange
            var veiculo = new Veiculo();
            var horarioSaida = DateTime.Now;

            //Act
            veiculo.HoraSaida = horarioSaida;

            //Assert
            Assert.Equal(horarioSaida, veiculo.HoraSaida);
        }

        [Fact]
        public void TesteAlteraDadosVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            var veiculoAlterado = new Veiculo
            (
                Proprietario = "Ranimy",
                Modelo = "Classic",
                Largura = 1.45,
                Cor = "preto"
            );

            //Act
            veiculo.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(
                (veiculoAlterado.Proprietario, veiculoAlterado.Modelo, veiculoAlterado.Largura, veiculoAlterado.Cor),
                (veiculo.Proprietario, veiculo.Modelo, veiculo.Largura, veiculo.Cor));
        }
    }
}
