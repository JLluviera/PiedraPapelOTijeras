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

        [Fact]
        public void Jugador_Con_Mas_Puntaje_Que_Limite_Gana()
        {
            int limite = 2;

            for (int i = 0; i <= 3; i++)
            {
                _jugador1.IncrementarPuntaje();
            }

            Juego juego1 = new Juego(_jugador1, _jugador2, limite);

            Jugador? ganador = juego1.ObtenerGanador();

            Assert.Equal(_jugador1.Nombre, ganador!.Nombre);
        }

        [Fact]
        public void Da_Null_Si_No_Hay_Ganador()
        {
            int limite = 5;

            Juego juego1 = new Juego(_jugador1, _jugador2, limite);

            Jugador? ganador = juego1.ObtenerGanador();

            Assert.Null(ganador);
        }

        [Fact]
        public void Juego_Terminado_Devulve_Bien_Ganador()
        {
            Juego juego1 = new Juego(_jugador1, _jugador2);

            for (int i = 0; i < 3; i++)
            {
                juego1.JugarRonda(Juego.Jugada.Piedra, Juego.Jugada.Tijeras);
            }

            string resultado = juego1.ObtenerEstadoJuego();

            Assert.Contains($"¡Ana ha ganado la partida! (3-0)", resultado);

        }
    }
}
