namespace AppEscritorioPortafolio
{
    partial class Menu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTipo = new System.Windows.Forms.Button();
            this.btnDestino = new System.Windows.Forms.Button();
            this.btnCiudad = new System.Windows.Forms.Button();
            this.btnRol = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnPais = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cerrar Sesion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Mantenedor de Actividades";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTipo
            // 
            this.btnTipo.Location = new System.Drawing.Point(62, 143);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(164, 23);
            this.btnTipo.TabIndex = 2;
            this.btnTipo.Text = "Mantenedor de Tipo Sevicios";
            this.btnTipo.UseVisualStyleBackColor = true;
            this.btnTipo.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDestino
            // 
            this.btnDestino.Location = new System.Drawing.Point(62, 114);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(164, 23);
            this.btnDestino.TabIndex = 3;
            this.btnDestino.Text = "Mantenedor de Destinos";
            this.btnDestino.UseVisualStyleBackColor = true;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // btnCiudad
            // 
            this.btnCiudad.Location = new System.Drawing.Point(62, 85);
            this.btnCiudad.Name = "btnCiudad";
            this.btnCiudad.Size = new System.Drawing.Size(164, 23);
            this.btnCiudad.TabIndex = 4;
            this.btnCiudad.Text = "Mantenedor de Ciudad";
            this.btnCiudad.UseVisualStyleBackColor = true;
            this.btnCiudad.Click += new System.EventHandler(this.btnCiudad_Click);
            // 
            // btnRol
            // 
            this.btnRol.Location = new System.Drawing.Point(62, 172);
            this.btnRol.Name = "btnRol";
            this.btnRol.Size = new System.Drawing.Size(164, 23);
            this.btnRol.TabIndex = 5;
            this.btnRol.Text = "Mantenedor de Roles";
            this.btnRol.UseVisualStyleBackColor = true;
            this.btnRol.Click += new System.EventHandler(this.btnRol_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(62, 201);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(164, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Mantenedor de Usuarios";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnPais
            // 
            this.btnPais.Location = new System.Drawing.Point(62, 56);
            this.btnPais.Name = "btnPais";
            this.btnPais.Size = new System.Drawing.Size(164, 23);
            this.btnPais.TabIndex = 7;
            this.btnPais.Text = "Mantenedor de Paises";
            this.btnPais.UseVisualStyleBackColor = true;
            this.btnPais.Click += new System.EventHandler(this.btnPais_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnPais);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnRol);
            this.Controls.Add(this.btnCiudad);
            this.Controls.Add(this.btnDestino);
            this.Controls.Add(this.btnTipo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTipo;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.Button btnCiudad;
        private System.Windows.Forms.Button btnRol;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnPais;
    }
}