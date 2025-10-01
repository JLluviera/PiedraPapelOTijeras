using PiedraPapelOTijeras.Dominio;
using static PiedraPapelOTijeras.Dominio.Juego;

namespace PiedraPapelOTijeras.Tests
{
    public class ResultadoRondaTests
    {
        private readonly Jugador _jugador1;
        private readonly Jugador _jugador2;

        public ResultadoRondaTests()
        {
            _jugador1 = new Jugador("Jugador1");
            _jugador2 = new Jugador("Jugador2");
        }

        [Theory]
        [InlineData(Juego.Jugada.Tijeras, Juego.Jugada.Papel, "Jugador1")]
        [InlineData(Juego.Jugada.Tijeras, Juego.Jugada.Piedra, "Jugador2")]
        [InlineData(Juego.Jugada.Piedra, Juego.Jugada.Tijeras, "Jugador1")]
        [InlineData(Juego.Jugada.Papel, Juego.Jugada.Tijeras, "Jugador2")]
        [InlineData(Juego.Jugada.Piedra, Juego.Jugada.Papel, "Jugador2")]
        [InlineData(Juego.Jugada.Papel, Juego.Jugada.Piedra, "Jugador1")]

        public void Testeo_Reglas_Basicas(Juego.Jugada jugada1, Juego.Jugada jugada2, string nombreGanador)
        {

            ResultadoRonda ServicioResultado = new ResultadoRonda(_jugador1, jugada1, _jugador2, jugada2);

            Jugador? ganadorRecibido = ServicioResultado.Ganador;



            Assert.Equal(nombreGanador, ganadorRecibido!.Nombre);
        }

        [Theory]
        [InlineData(Juego.Jugada.Papel, Juego.Jugada.Papel)]
        [InlineData(Juego.Jugada.Tijeras, Juego.Jugada.Tijeras)]
        [InlineData(Juego.Jugada.Piedra, Juego.Jugada.Piedra)]


        public void Misma_Jugada_DaEmpate(Juego.Jugada jugada1, Juego.Jugada jugada2)
        {
            ResultadoRonda ServiciosResultados = new ResultadoRonda(_jugador1, jugada1, _jugador2, jugada2);

            bool ResultadoEmpate = ServiciosResultados.EsEmpate;

            Assert.True(ResultadoEmpate);
        }

        [Fact]
        public void GanarDescripcion_Jugador1Gana_DescripcionCorrecta()
        {
            var resultado = new ResultadoRonda(_jugador1, Juego.Jugada.Piedra, _jugador2, Juego.Jugada.Tijeras);

            Assert.Equal("Jugador1 gana: Piedra aplasta a Tijeras", resultado.Descripcion);
        }

        [Fact]
        public void No_Hay_Ganador_EsEmpate()
        {
            ResultadoRonda resultado = new ResultadoRonda(_jugador1, Juego.Jugada.Piedra, _jugador2, Juego.Jugada.Piedra);

            Assert.True(resultado.EsEmpate);
        }

    }
}
