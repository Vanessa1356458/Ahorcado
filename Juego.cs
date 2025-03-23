using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Ahorcado
{
    public partial class Juego : Form
    {
        private List<string> palabras = new List<string>
        {
            "guayaba","arándano", "granadilla", "alcachofa", "berenjena", "armadillo", "ornitorrinco", "Neptuno", "Urano", "Mercurio", "Andrómeda", "Ganímedes"
        };
        private List<string> pistas = new List<string>
        {
           "Fruta tropical con muchas semillas", "Pequeña fruta morada", "Fruta tropical con semillas", "Verdura con muchas hojas", "Verdura morada", "Mamífero con caparazón",     
           "Animal semiacuático raro", "Planeta gaseoso azul", "Planeta con nombre de dios", "El más cercano al Sol", "Galaxia vecina", "Luna más grande de Júpiter"
        };

        private string palabraActual;
        private string pistaActual;
        private string palabraOculta;
        private int intentosRestantes = 6;
        private int victorias = 0;
        private int derrotas = 0;
        private HashSet<char> letrasIncorrectas = new HashSet<char>();
        private HashSet<char> letrasIngresadas = new HashSet<char>();

        public Juego()
        {
            InitializeComponent();
            IniciarJuego();
            ConfigurarColores();
        }
        private void ConfigurarColores()
        {
            lblPalabra.ForeColor = Color.DarkSlateGray;
            lblIncorrectas.ForeColor = Color.DarkRed;
            lblPista.ForeColor = Color.DarkGreen;
            lblVictorias.ForeColor = Color.DarkBlue;
            lblDerrotas.ForeColor = Color.DarkRed;
            btnEnviar.BackColor = Color.SteelBlue;
            btnEnviar.ForeColor = Color.White;
            btnSalir.BackColor = Color.IndianRed;
            btnSalir.ForeColor = Color.White;
        }
        private void IniciarJuego()
        {
            Random rnd = new Random();
            int index = rnd.Next(palabras.Count);
            palabraActual = palabras[index];
            pistaActual = pistas[index];
            char letraRevelada = palabraActual[0];
            palabraOculta = letraRevelada + new string('_', palabraActual.Length - 1);
            intentosRestantes = 6;
            letrasIncorrectas.Clear();
            letrasIngresadas.Clear();
            ActualizarInterfaz();
        }
        private void ActualizarInterfaz()
        {
            lblPalabra.Text = string.Join(" ", palabraOculta.ToCharArray());
            lblIncorrectas.Text = "Letras incorrectas: " + string.Join(", ", letrasIncorrectas);
            picAhorcado.Image = ObtenerImagenAhorcado();
            lblPista.Text = "Pista: " + pistaActual;
            lblVictorias.Text = "Victorias: " + victorias;
            lblDerrotas.Text = "Derrotas: " + derrotas;
        }
        private Image ObtenerImagenAhorcado()
        {
            string nombreImagen = $"ahorcado_{6 - intentosRestantes}.PNG";
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream($"Ahorcado.Resources.{nombreImagen}"))
            {
                if (stream != null)
                {
                    return Image.FromStream(stream);
                }
            }
            return null;
        }
        private void Juego_Load(object sender, EventArgs e)
        {

        }

        private Image ObtenerImagenMensaje(string nombreImagen)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string nombreRecurso = $"Ahorcado.Resources.{nombreImagen}";
            using (var stream = assembly.GetManifestResourceStream(nombreRecurso))
            {
                if (stream != null)
                {
                    return Image.FromStream(stream);
                }
            }
            throw new FileNotFoundException($"No se pudo cargar la imagen: {nombreImagen}");
        }
        private void MostrarMensajePersonalizado(string mensaje, string titulo, string nombreImagen)
        {
            Image icono = ObtenerImagenMensaje(nombreImagen);
            MensajePersonalizado mensajeForm = new MensajePersonalizado(mensaje, titulo, icono);
            mensajeForm.ShowDialog();
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string letra = txtLetra.Text.ToLower();

            if (letra.Length != 1 || !char.IsLetter(letra[0]))
            {
                MostrarMensajePersonalizado("Por favor, ingresa una sola letra válida.", "Error", "Error.png");
                txtLetra.Clear();
                return;
            }

            if (letrasIngresadas.Contains(letra[0]))
            {
                MostrarMensajePersonalizado("Ya ingresaste esta letra. Intenta con otra.", "Error", "Error.png");
                txtLetra.Clear();
                return;
            }

            letrasIngresadas.Add(letra[0]);

            if (palabraActual.Contains(letra))
            {
                char[] palabraOcultaArray = palabraOculta.ToCharArray();
                for (int i = 0; i < palabraActual.Length; i++)
                {
                    if (palabraActual[i] == letra[0])
                    {
                        palabraOcultaArray[i] = letra[0];
                    }
                }
                palabraOculta = new string(palabraOcultaArray);

                MostrarMensajePersonalizado("¡Letra correcta!", "Correcto", "Correcto.png");
            }
            else
            {
                letrasIncorrectas.Add(letra[0]);
                intentosRestantes--;

                MostrarMensajePersonalizado("Letra incorrecta. Intentos restantes: " + intentosRestantes, "Error", "Error.png");
            }

            if (palabraOculta == palabraActual)
            {
                victorias++;
                MostrarMensajePersonalizado("¡Ganaste!", "Resultado", "Ganaste.png");
                IniciarJuego(); 
            }
            else if (intentosRestantes == 0)
            {
                derrotas++;
                MostrarMensajePersonalizado("¡Perdiste! La palabra era: " + palabraActual, "Resultado", "Perdiste.png");
                IniciarJuego(); 
            }

            ActualizarInterfaz();
            txtLetra.Clear();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            ConfirmarSalir confirmarSalir = new ConfirmarSalir();
            confirmarSalir.ShowDialog();
        }

    }
}
