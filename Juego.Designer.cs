namespace Ahorcado
{
    partial class Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPalabra = new System.Windows.Forms.Label();
            this.lblIncorrectas = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblPista = new System.Windows.Forms.Label();
            this.lblVictorias = new System.Windows.Forms.Label();
            this.lblDerrotas = new System.Windows.Forms.Label();
            this.picAhorcado = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAhorcado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPalabra
            // 
            this.lblPalabra.AutoSize = true;
            this.lblPalabra.Location = new System.Drawing.Point(114, 426);
            this.lblPalabra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalabra.Name = "lblPalabra";
            this.lblPalabra.Size = new System.Drawing.Size(79, 22);
            this.lblPalabra.TabIndex = 0;
            this.lblPalabra.Text = "Palabra";
            // 
            // lblIncorrectas
            // 
            this.lblIncorrectas.AutoSize = true;
            this.lblIncorrectas.Location = new System.Drawing.Point(415, 265);
            this.lblIncorrectas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIncorrectas.Name = "lblIncorrectas";
            this.lblIncorrectas.Size = new System.Drawing.Size(76, 22);
            this.lblIncorrectas.TabIndex = 1;
            this.lblIncorrectas.Text = "Errores";
            // 
            // txtLetra
            // 
            this.txtLetra.Location = new System.Drawing.Point(118, 452);
            this.txtLetra.Margin = new System.Windows.Forms.Padding(4);
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(49, 29);
            this.txtLetra.TabIndex = 3;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(118, 495);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(135, 55);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(274, 495);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(134, 55);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblPista
            // 
            this.lblPista.AutoSize = true;
            this.lblPista.Location = new System.Drawing.Point(415, 304);
            this.lblPista.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPista.Name = "lblPista";
            this.lblPista.Size = new System.Drawing.Size(54, 22);
            this.lblPista.TabIndex = 6;
            this.lblPista.Text = "Pista";
            // 
            // lblVictorias
            // 
            this.lblVictorias.AutoSize = true;
            this.lblVictorias.Location = new System.Drawing.Point(415, 179);
            this.lblVictorias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVictorias.Name = "lblVictorias";
            this.lblVictorias.Size = new System.Drawing.Size(88, 22);
            this.lblVictorias.TabIndex = 7;
            this.lblVictorias.Text = "Victorias";
            // 
            // lblDerrotas
            // 
            this.lblDerrotas.AutoSize = true;
            this.lblDerrotas.Location = new System.Drawing.Point(414, 221);
            this.lblDerrotas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDerrotas.Name = "lblDerrotas";
            this.lblDerrotas.Size = new System.Drawing.Size(89, 22);
            this.lblDerrotas.TabIndex = 8;
            this.lblDerrotas.Text = "Derrotas";
            // 
            // picAhorcado
            // 
            this.picAhorcado.Location = new System.Drawing.Point(107, 110);
            this.picAhorcado.Name = "picAhorcado";
            this.picAhorcado.Size = new System.Drawing.Size(301, 313);
            this.picAhorcado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAhorcado.TabIndex = 9;
            this.picAhorcado.TabStop = false;
            this.picAhorcado.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(179, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 36);
            this.label1.TabIndex = 10;
            this.label1.Text = "Juego del Ahorcado";
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(723, 634);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picAhorcado);
            this.Controls.Add(this.lblDerrotas);
            this.Controls.Add(this.lblVictorias);
            this.Controls.Add(this.lblPista);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.lblIncorrectas);
            this.Controls.Add(this.lblPalabra);
            this.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Juego";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picAhorcado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPalabra;
        private System.Windows.Forms.Label lblIncorrectas;
        private System.Windows.Forms.TextBox txtLetra;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblPista;
        private System.Windows.Forms.Label lblVictorias;
        private System.Windows.Forms.Label lblDerrotas;
        private System.Windows.Forms.PictureBox picAhorcado;
        private System.Windows.Forms.Label label1;
    }
}