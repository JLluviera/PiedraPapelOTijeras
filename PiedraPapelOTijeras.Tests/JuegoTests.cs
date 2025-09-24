using PiedraPapelOTijeras.Dominio;
using Xunit;

namespace PiedraPapelOTijeras.Tests
{
    public class JuegoTests
    {
        private readonly Jugador _jugador1;
        private readonly Jugador _jugador2;

        public JuegoTests()
        {
            _jugador1 = new Jugador("Ana");
            _jugador2 = new Jugador("Luis");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        
        public void Puntaje_Para_Ganar_Tiene_Que_Ser_Mayor_A_0(int Puntaje) 
        {

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Juego juego1 = new Juego(_jugador1, _jugador2, Puntaje);
            });

            Assert.Contains("El puntaje para ganar debe ser mayor a 0", ex.Message);

        }

        [Fact]
        public void No_Se_Puede_Jugar_Ronda_Terminada()
        {
            int limiteParaGanar = 20;

            for (int i = 0; i < 20; i++)
            {
                _jugador1.IncrementarPuntaje();
            }

            Juego juego1 = new Juego(_jugador1, _jugador2, limiteParaGanar);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                juego1.JugarRonda(Juego.Jugada.Piedra, Juego.Jugada.Tijeras);
            });

            Assert.Contains("El juego ya ha terminado", ex.Message);
        }

    }
}
