using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class MensajePersonalizado: Form
    {
        public MensajePersonalizado(string mensaje, string titulo, Image icono)
        {
            InitializeComponent();

            picIcono.Image = icono;
            this.Text = string.Empty;
            lblMensaje.Text = mensaje;
            
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(400, 300);

            picIcono.SizeMode = PictureBoxSizeMode.StretchImage; 
            picIcono.Size = new Size(64, 64);
            picIcono.Location = new Point((this.ClientSize.Width - picIcono.Width) / 2, 20);

            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = Color.DarkSlateGray;
            lblMensaje.Font = new Font("Arial", 12, FontStyle.Bold);
            lblMensaje.AutoSize = false;
            lblMensaje.Size = new Size(350, 100);
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            lblMensaje.Location = new Point((this.ClientSize.Width - lblMensaje.Width) / 2, picIcono.Bottom + 10);

            btnAceptar.BackColor = Color.SteelBlue; 
            btnAceptar.ForeColor = Color.White; 
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.Size = new Size(100, 35);
            btnAceptar.Location = new Point((this.ClientSize.Width - btnAceptar.Width) / 2, lblMensaje.Bottom + 10);

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MensajePersonalizado_Load(object sender, EventArgs e)
        {

        }
    }
}
