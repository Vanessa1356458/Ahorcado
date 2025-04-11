using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    public class PalabraPista
    {
        public string Palabra { get; }
        public string Pista { get; }

        public PalabraPista(string palabra, string pista)
        {
            Palabra = palabra;
            Pista = pista;
        }
    }
}
