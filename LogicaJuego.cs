using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;

namespace Ahorcado
{
    public class LogicaJuego
    {
        private const string IMAGEN_ERROR = "Error.png";
        private const string IMAGEN_CORRECTO = "Correcto.png";
        private const string IMAGEN_GANASTE = "Ganaste.png";
        private const string IMAGEN_PERDISTE = "Perdiste.png";

        private readonly List<string> palabras = new List<string>
        {
            "guayaba","arándano", "granadilla", "alcachofa", "berenjena", "armadillo", "ornitorrinco", "Neptuno", "Urano", "Mercurio", "Andrómeda", "Ganímedes"
        };
        private List<string> pistas = new List<string>
        {
           "Fruta tropical con muchas semillas", "Pequeña fruta morada", "Fruta tropical con semillas", "Verdura con muchas hojas", "Verdura morada", "Mamífero con caparazón",
           "Animal semiacuático raro", "Planeta gaseoso azul", "Planeta con nombre de dios", "El más cercano al Sol", "Galaxia vecina", "Luna más grande de Júpiter"
        };

        private readonly Random _random = new Random();

        private string _palabraActual;
        private string _pistaActual;
        private string _palabraOculta;
        private int _intentos = 6;
        private int _victorias = 0;
        private int _derrotas = 0;
        private readonly HashSet<char> _letrasIncorrectas = new HashSet<char>();
        private readonly HashSet<char> _letrasIngresadas = new HashSet<char>();

        public void IniciarNuevoJuego()
        {
            int indiceAleatorio = _random.Next(palabras.Count);
            _palabraActual = palabras[indiceAleatorio];
            _pistaActual = pistas[indiceAleatorio];
            _palabraOculta = _palabraActual[0] + new string('_', _palabraActual.Length - 1); _intentos = 6;
            _letrasIncorrectas.Clear();
            _letrasIngresadas.Clear();
        }

        public ResultadoJuego ProcesarIntento(string letra)
        {
            if (!ValidarLetra(letra, out var mensajeError))
                return new ResultadoJuego
                {
                    Mensaje = mensajeError,
                    Titulo = "Error",
                    MostrarMensaje = true,
                    NombreImagen = IMAGEN_ERROR
                };

            _letrasIngresadas.Add(letra[0]);

            if (_palabraActual.Contains(letra))
            {
                ActualizarPalabraOculta(letra[0]);
                if (_palabraOculta == _palabraActual)
                {
                    _victorias++;
                    return new ResultadoJuego
                    {
                        Mensaje = "¡Ganaste!",
                        Titulo = "Resultado",
                        MostrarMensaje = true,
                        ReiniciarJuego = true,
                        NombreImagen = IMAGEN_GANASTE
                    };
                }
                return VerificarResultado("¡Correcto!", "Acierto", IMAGEN_CORRECTO);
            }
            else
            {
                _letrasIncorrectas.Add(letra[0]);
                _intentos--;
                if (_intentos <= 0)
                {
                    _derrotas++;
                    return new ResultadoJuego
                    {
                        Mensaje = $"¡Perdiste! La palabra era: {_palabraActual}",
                        Titulo = "Resultado",
                        MostrarMensaje = true,
                        ReiniciarJuego = true,
                        NombreImagen = IMAGEN_PERDISTE
                    };
                }
                return VerificarResultado($"Incorrecto. Intentos: {_intentos}", "Error", IMAGEN_ERROR);
            }
        }

        public EstadoJuego ObtenerEstado()
        {
            return new EstadoJuego
            {
                PalabraOculta = string.Join(" ", _palabraOculta.ToCharArray()),
                LetrasIncorrectas = "Letras incorrectas: " + string.Join(", ", _letrasIncorrectas),
                ImagenAhorcado = ObtenerImagenAhorcado(),
                Pista = "Pista: " + _pistaActual,
                Victorias = "Victorias: " + _victorias,
                Derrotas = "Derrotas: " + _derrotas
            };
        }

        private bool ValidarLetra(string letra, out string mensaje)
        {
            mensaje = "";
            if (letra.Length != 1 || !char.IsLetter(letra[0]))
            {
                mensaje = "Ingresa una letra válida";
                return false;
            }
            if (_letrasIngresadas.Contains(letra[0]))
            {
                mensaje = "Letra ya ingresada";
                return false;
            }
            return true;
        }

        private void ActualizarPalabraOculta(char letra)
        {
            var array = _palabraOculta.ToCharArray();
            for (int i = 0; i < _palabraActual.Length; i++)
                if (_palabraActual[i] == letra)
                    array[i] = letra;
            _palabraOculta = new string(array);
        }

        private ResultadoJuego VerificarResultado(string mensaje, string titulo, string nombreImagen)
        {
            return new ResultadoJuego
            {
                Mensaje = mensaje,
                Titulo = titulo,
                MostrarMensaje = true,
                NombreImagen = nombreImagen,
                ReiniciarJuego = false
            };
        }


        public Image ObtenerImagenAhorcado()
        {
            string nombreImagen = $"ahorcado_{6 - _intentos}.png"; 
            return ObtenerImagenRecurso(nombreImagen);
        }

        public static Image ObtenerImagenRecurso(string nombreImagen)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                string[] posiblesNombres = {
                $"Ahorcado.Resources.{nombreImagen}",
                $"Ahorcado.Resources.{Path.GetFileNameWithoutExtension(nombreImagen)}{Path.GetExtension(nombreImagen).ToLower()}",
                $"Ahorcado.Resources.{Path.GetFileNameWithoutExtension(nombreImagen)}{Path.GetExtension(nombreImagen).ToUpper()}"
            };

                foreach (var resourceName in posiblesNombres)
                {
                    using (var stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (stream != null)
                        {
                            return Image.FromStream(stream);
                        }
                    }
                }
                Console.WriteLine("Recursos disponibles:");
                foreach (var res in assembly.GetManifestResourceNames())
                {
                    Console.WriteLine(res);
                }

                throw new FileNotFoundException($"No se encontró la imagen: {nombreImagen}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar imagen: {ex.Message}"); return null;

            }
        }
    }
}

