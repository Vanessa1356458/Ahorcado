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
using static Ahorcado.LogicaJuego;

namespace Ahorcado
{
    public partial class Juego : Form
    {
        private readonly LogicaJuego _logica;

        public Juego()
        {
            InitializeComponent();
            _logica = new LogicaJuego();
            ConfigurarInterfaz();
            NuevaPartida();
        }
        private void ConfigurarInterfaz()
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

        private void NuevaPartida()
        {
            _logica.IniciarNuevoJuego();
            MostrarEstado();
        }

        private void MostrarEstado()
        {
            var estado = _logica.ObtenerEstado();

            lblPalabra.Text = estado.PalabraOculta;
            lblIncorrectas.Text = estado.LetrasIncorrectas;
            picAhorcado.Image = estado.ImagenAhorcado;
            lblPista.Text = "Pista: " + estado.Pista;
            lblVictorias.Text = estado.Victorias.ToString();
            lblDerrotas.Text = estado.Derrotas.ToString();

            if (estado.MostrarMensaje)
            {
                MostrarMensajePersonalizado(
                    estado.Mensaje,
                    estado.TituloMensaje,
                    estado.NombreImagenMensaje);
            }
        }

        private void MostrarMensajePersonalizado(string mensaje, string titulo, string nombreImagen)
        {
            try
            {
                Image icono = !string.IsNullOrWhiteSpace(nombreImagen)
                ? LogicaJuego.ObtenerImagenRecurso(nombreImagen)
                    : null;

                using (var mensajeForm = new MensajePersonalizado(mensaje, titulo, icono))
                {
                    mensajeForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar mensaje: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var resultado = _logica.ProcesarIntento(txtLetra.Text);

            if (resultado.MostrarMensaje)
                MostrarMensajePersonalizado(resultado.Mensaje, resultado.Titulo, resultado.NombreImagen);

            if (resultado.ReiniciarJuego)
            {
                _logica.IniciarNuevoJuego();
            }

            MostrarEstado();
            txtLetra.Clear();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            using (var confirmarForm = new ConfirmarSalir())
            {
                var resultado = confirmarForm.ShowDialog();

                if (resultado == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
    }
}
