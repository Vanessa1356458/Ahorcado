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
    public partial class ConfirmarSalir : Form
    {
        public ConfirmarSalir()
        {
            InitializeComponent();

            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(400, 200);

            lblMensaje.Text = "¿Está seguro que desea salir?";
            lblMensaje.ForeColor = Color.DarkSlateGray;
            lblMensaje.Font = new Font("Arial", 12, FontStyle.Bold);
            lblMensaje.AutoSize = false;
            lblMensaje.Size = new Size(350, 100);
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            lblMensaje.Location = new Point((this.ClientSize.Width - lblMensaje.Width) / 2,  20);

            int buttonWidth = 100;
            int buttonHeight = 35;
            int buttonY = lblMensaje.Bottom + 20;
            int spacing = 20;

            btnSi.Text = "Sí";
            btnSi.BackColor = Color.SteelBlue;
            btnSi.ForeColor = Color.White;
            btnSi.FlatStyle = FlatStyle.Flat;
            btnSi.FlatAppearance.BorderSize = 0;
            btnSi.Size = new Size(buttonWidth, buttonHeight);
            int totalButtonsWidth = (buttonWidth * 2) + spacing;
            int startX = (this.ClientSize.Width - totalButtonsWidth) / 2;
            btnSi.Location = new Point(startX, buttonY);

            btnNo.Text = "No";
            btnNo.BackColor = Color.SteelBlue;
            btnNo.ForeColor = Color.White;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.FlatAppearance.BorderSize = 0;
            btnNo.Size = new Size(buttonWidth, buttonHeight);
            btnNo.Location = new Point(startX + buttonWidth + spacing, buttonY);
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
