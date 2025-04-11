using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    public class EstadoJuego
    {
        public string PalabraOculta { get; set; }
        public string LetrasIncorrectas { get; set; }
        public Image ImagenAhorcado { get; set; }
        public string Pista { get; set; }
        public string Victorias { get; set; }
        public string Derrotas { get; set; }
        public int IntentosRestantes { get; set; }
        public bool MostrarMensaje { get; set; }
        public string Mensaje { get; set; }
        public string TituloMensaje { get; set; }
        public string NombreImagenMensaje { get; set; }
    }
}
