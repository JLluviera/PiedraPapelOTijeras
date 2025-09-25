using PiedraPapelOTijeras.Dominio;
using PiedraPapelOTijeras.Servicios;

namespace PiedraPapelOTijeras.Tests
{
    public class ServicioJuegoTests
    {
        private readonly ServicioJuego _servicio;

        public ServicioJuegoTests()
        {
            _servicio = new ServicioJuego();
        }

        [Fact]
        public void IniciarNuevaPartida_ConParametrosValidos_DeberiaCrearJuego()
        {
            // Arrange
            string nombre1 = "Pedro";
            string nombre2 = "Maria";
            int puntaje = 5;

            // Act
            var juego = _servicio.IniciarNuevaPartida(nombre1, nombre2, puntaje);

            // Assert
            Assert.NotNull(juego);
            Assert.Equal(nombre1, juego.Jugador1.Nombre);
            Assert.Equal(nombre2, juego.Jugador2.Nombre);
            Assert.Equal(puntaje, juego.PuntajeParaGanar);
        }

        [Theory]
        [InlineData("Piedra")]
        [InlineData("Tijeras")]
        [InlineData("PAPEL")]
        [InlineData("  1")]
        [InlineData("  2 ")]
        [InlineData("3   ")]
        public void Validaciones_De_Jugadas_Correctas(string entrada)
        {
            ServicioJuego servicio = new ServicioJuego();

            Juego.Jugada Retorno;

            bool ResultadoBool;

            ResultadoBool = servicio.ValidarJugada(entrada, out Retorno);

            Assert.True(ResultadoBool);

        }

        [Theory]
        [InlineData("Pieda", Juego.Jugada.Piedra)]
        [InlineData("1", Juego.Jugada.Piedra)]
        [InlineData("PapEl", Juego.Jugada.Papel)]
        [InlineData("2", Juego.Jugada.Papel)]
        [InlineData("Tijeras", Juego.Jugada.Tijeras)]
        [InlineData("3", Juego.Jugada.Tijeras)]
        public void Devuelve_Jugada_Correcta(string entrada, Juego.Jugada esperado)
        {
            Juego.Jugada retorno;

            bool validacion = _servicio.ValidarJugada(entrada, out retorno);

            Assert.Equal(esperado, retorno);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData("Piedras")]
        [InlineData("Piedra papel")]
        [InlineData("nose")]

        public void Validaciones_De_Jugadas_Incorrectas(string entrada)
        {
            ServicioJuego servicio = new ServicioJuego();

            Juego.Jugada Retorno;

            bool ResultadoBool;

            ResultadoBool = servicio.ValidarJugada(entrada, out Retorno);

            Assert.False(ResultadoBool);
        }

        [Fact]

        public void Obtener_Juego_Actual_Debe_Devolver_El_Juego_Iniciado()
        {

            string nombre1 = "pablo";
            string nombre2 = "Elena";
            int puntaje = 8;

            var juego = _servicio.IniciarNuevaPartida(nombre1, nombre2, puntaje);

            Assert.Equal(juego, _servicio.ObtenerJuegoActual());
        }
    }
}
