using gerenciador.estacionamento.Estacionamento.Modelos;
using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Xunit;

namespace gerenciador.estacionamento.Testes
{
    public class VeiculoTestes
    {
        public string Proprietario { get; set; }
        public string Cor { get; set; }
        public double Largura { get; set; }
        public string Modelo { get; set; }

        private Veiculo veiculo;
        public VeiculoTestes()
        {
            //Setup - Prepara��o do cen�rio de testes
            //A cria��o do Setup dessa forma evita a instancia de um novo veiculo em cada Arrange
            veiculo = new Veiculo();
        }

        [Fact]
        //Teste do m�todo Acelerar da classe Veiculo
        public void TestaVeiculoAcelerar()
        {
            //Arrange - Cria��o de vari�vel e instancia de objeto necess�rio para o teste
            //var veiculo = new Veiculo();

            //Act - Teste do m�todo passando um valor
            veiculo.Acelerar(10); 

            //Assert - Checagem do retorno esperado e onde verificar!
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        //Teste do m�todo Frear da classe Veiculo
        public void TestaVeiculoFrear()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Tipo = TipoVeiculo.Automovel;

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaVeiculoPlaca()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Placa = "abc-1234";

            //Assert
            Assert.Equal("abc-1234", veiculo.Placa);

        }

        [Fact]
        public void TestaProprietarioVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Proprietario = "Ranimy";

            //Assert
            Assert.Equal("Ranimy", veiculo.Proprietario);
        }

        [Fact]
        public void TestaHorarioEntrada()
        {
            //Arrange
            //var veiculo = new Veiculo();
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
            //var veiculo = new Veiculo();
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
            //var veiculo = new Veiculo();

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

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Lucas In�cio";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "XJC-5487";
            veiculo.Cor = "Rosa";
            veiculo.Modelo = "Cruze";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Ve�culo: Automovel", dados);
        }
    }
}
