using PiedraPapelOTijeras.Dominio;
using Xunit;
using Xunit.Sdk;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PiedraPapelOTijeras.Tests
{
    public class JugadorTests
    {
        [Fact]
        public void Jugador_No_Tiene_Nombre_Null()
        {
            string nombre = "";

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Jugador jugador1 = new Jugador(nombre);
            });
            

            Assert.Contains("El nombre del jugador no puede estar vacío", ex.Message);
        }

        [Fact]
        public void Incrementar_Puntaje_Funciona()
        {
            Jugador jugador = new Jugador("Juan");
            int puntaje = 0;

            for (int i = 0; i < 2; i++)
            {
                jugador.IncrementarPuntaje();
                puntaje++;
            }

            Assert.Equal(puntaje, jugador.Puntaje);
        }
    }

    
}
