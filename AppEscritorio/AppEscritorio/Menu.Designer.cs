namespace AppEscritorio
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btn_TipoContrato = new System.Windows.Forms.Button();
            this.btn_TipoCliente = new System.Windows.Forms.Button();
            this.btn_TipoServicio = new System.Windows.Forms.Button();
            this.btn_TipoRol = new System.Windows.Forms.Button();
            this.btn_Clientes_Click = new System.Windows.Forms.Button();
            this.btnDestinox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Mantenedor de Tipo de Actividad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido a Mantenedores";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(179, 287);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(93, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar Sesion";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btn_TipoContrato
            // 
            this.btn_TipoContrato.Location = new System.Drawing.Point(57, 118);
            this.btn_TipoContrato.Name = "btn_TipoContrato";
            this.btn_TipoContrato.Size = new System.Drawing.Size(175, 23);
            this.btn_TipoContrato.TabIndex = 3;
            this.btn_TipoContrato.Text = "Mantenedor de Tipo de Contrato";
            this.btn_TipoContrato.UseVisualStyleBackColor = true;
            this.btn_TipoContrato.Click += new System.EventHandler(this.btn_TipoContrato_Click);
            // 
            // btn_TipoCliente
            // 
            this.btn_TipoCliente.Location = new System.Drawing.Point(57, 89);
            this.btn_TipoCliente.Name = "btn_TipoCliente";
            this.btn_TipoCliente.Size = new System.Drawing.Size(175, 23);
            this.btn_TipoCliente.TabIndex = 4;
            this.btn_TipoCliente.Text = "Mantenedor de Tipo de Cliente";
            this.btn_TipoCliente.UseVisualStyleBackColor = true;
            this.btn_TipoCliente.Click += new System.EventHandler(this.btn_TipoCliente_Click);
            // 
            // btn_TipoServicio
            // 
            this.btn_TipoServicio.Location = new System.Drawing.Point(57, 147);
            this.btn_TipoServicio.Name = "btn_TipoServicio";
            this.btn_TipoServicio.Size = new System.Drawing.Size(175, 23);
            this.btn_TipoServicio.TabIndex = 5;
            this.btn_TipoServicio.Text = "Mantenedor de Tipo de Servicio";
            this.btn_TipoServicio.UseVisualStyleBackColor = true;
            this.btn_TipoServicio.Click += new System.EventHandler(this.btn_TipoServicio_Click);
            // 
            // btn_TipoRol
            // 
            this.btn_TipoRol.Location = new System.Drawing.Point(57, 176);
            this.btn_TipoRol.Name = "btn_TipoRol";
            this.btn_TipoRol.Size = new System.Drawing.Size(175, 23);
            this.btn_TipoRol.TabIndex = 6;
            this.btn_TipoRol.Text = "Mantenedor de Tipo de Roles";
            this.btn_TipoRol.UseVisualStyleBackColor = true;
            this.btn_TipoRol.Click += new System.EventHandler(this.btn_TipoRol_Click);
            // 
            // btn_Clientes_Click
            // 
            this.btn_Clientes_Click.Location = new System.Drawing.Point(57, 206);
            this.btn_Clientes_Click.Name = "btn_Clientes_Click";
            this.btn_Clientes_Click.Size = new System.Drawing.Size(175, 23);
            this.btn_Clientes_Click.TabIndex = 7;
            this.btn_Clientes_Click.Text = "Mantenedor de Clientes";
            this.btn_Clientes_Click.UseVisualStyleBackColor = true;
            this.btn_Clientes_Click.Click += new System.EventHandler(this.btn_Clientes_Click_Click);
            // 
            // btnDestinox
            // 
            this.btnDestinox.Location = new System.Drawing.Point(57, 235);
            this.btnDestinox.Name = "btnDestinox";
            this.btnDestinox.Size = new System.Drawing.Size(175, 23);
            this.btnDestinox.TabIndex = 8;
            this.btnDestinox.Text = "Mantenedor de Destinos";
            this.btnDestinox.UseVisualStyleBackColor = true;
            this.btnDestinox.Click += new System.EventHandler(this.btnDestinox_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 347);
            this.Controls.Add(this.btnDestinox);
            this.Controls.Add(this.btn_Clientes_Click);
            this.Controls.Add(this.btn_TipoRol);
            this.Controls.Add(this.btn_TipoServicio);
            this.Controls.Add(this.btn_TipoCliente);
            this.Controls.Add(this.btn_TipoContrato);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btn_TipoContrato;
        private System.Windows.Forms.Button btn_TipoCliente;
        private System.Windows.Forms.Button btn_TipoServicio;
        private System.Windows.Forms.Button btn_TipoRol;
        private System.Windows.Forms.Button btn_Clientes_Click;
        private System.Windows.Forms.Button btnDestinox;
    }
}