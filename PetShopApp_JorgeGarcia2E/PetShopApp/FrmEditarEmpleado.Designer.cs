
namespace PetShopApp
{
    partial class FrmEditarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarEmpleado));
            this.txtNombreEdit = new System.Windows.Forms.TextBox();
            this.txtDniEdit = new System.Windows.Forms.TextBox();
            this.txtApellidoEdit = new System.Windows.Forms.TextBox();
            this.txtSueldoEdit = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblSueldo = new System.Windows.Forms.Label();
            this.lblTituloEdit = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuarioEdit = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClaveEdit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNombreEdit
            // 
            this.txtNombreEdit.Location = new System.Drawing.Point(72, 42);
            this.txtNombreEdit.Name = "txtNombreEdit";
            this.txtNombreEdit.Size = new System.Drawing.Size(202, 23);
            this.txtNombreEdit.TabIndex = 0;
            // 
            // txtDniEdit
            // 
            this.txtDniEdit.Enabled = false;
            this.txtDniEdit.Location = new System.Drawing.Point(72, 100);
            this.txtDniEdit.Name = "txtDniEdit";
            this.txtDniEdit.Size = new System.Drawing.Size(202, 23);
            this.txtDniEdit.TabIndex = 1;
            // 
            // txtApellidoEdit
            // 
            this.txtApellidoEdit.Location = new System.Drawing.Point(72, 71);
            this.txtApellidoEdit.Name = "txtApellidoEdit";
            this.txtApellidoEdit.Size = new System.Drawing.Size(202, 23);
            this.txtApellidoEdit.TabIndex = 2;
            // 
            // txtSueldoEdit
            // 
            this.txtSueldoEdit.Location = new System.Drawing.Point(72, 129);
            this.txtSueldoEdit.Name = "txtSueldoEdit";
            this.txtSueldoEdit.Size = new System.Drawing.Size(202, 23);
            this.txtSueldoEdit.TabIndex = 3;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.Location = new System.Drawing.Point(95, 232);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 32);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(176, 232);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(12, 45);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(55, 16);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.Location = new System.Drawing.Point(12, 74);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(57, 16);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellido";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDNI.Location = new System.Drawing.Point(12, 103);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(28, 16);
            this.lblDNI.TabIndex = 8;
            this.lblDNI.Text = "DNI";
            // 
            // lblSueldo
            // 
            this.lblSueldo.AutoSize = true;
            this.lblSueldo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSueldo.Location = new System.Drawing.Point(12, 132);
            this.lblSueldo.Name = "lblSueldo";
            this.lblSueldo.Size = new System.Drawing.Size(47, 16);
            this.lblSueldo.TabIndex = 9;
            this.lblSueldo.Text = "Sueldo";
            // 
            // lblTituloEdit
            // 
            this.lblTituloEdit.AutoSize = true;
            this.lblTituloEdit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTituloEdit.Location = new System.Drawing.Point(120, 18);
            this.lblTituloEdit.Name = "lblTituloEdit";
            this.lblTituloEdit.Size = new System.Drawing.Size(117, 21);
            this.lblTituloEdit.TabIndex = 10;
            this.lblTituloEdit.Text = "Nuevos datos";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsuario.Location = new System.Drawing.Point(12, 161);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 16);
            this.lblUsuario.TabIndex = 12;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuarioEdit
            // 
            this.txtUsuarioEdit.Location = new System.Drawing.Point(72, 158);
            this.txtUsuarioEdit.Name = "txtUsuarioEdit";
            this.txtUsuarioEdit.Size = new System.Drawing.Size(202, 23);
            this.txtUsuarioEdit.TabIndex = 11;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClave.Location = new System.Drawing.Point(12, 190);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(42, 16);
            this.lblClave.TabIndex = 14;
            this.lblClave.Text = "Clave";
            // 
            // txtClaveEdit
            // 
            this.txtClaveEdit.Location = new System.Drawing.Point(72, 187);
            this.txtClaveEdit.Name = "txtClaveEdit";
            this.txtClaveEdit.Size = new System.Drawing.Size(202, 23);
            this.txtClaveEdit.TabIndex = 13;
            // 
            // FrmEditarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(315, 276);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClaveEdit);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuarioEdit);
            this.Controls.Add(this.lblTituloEdit);
            this.Controls.Add(this.lblSueldo);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtSueldoEdit);
            this.Controls.Add(this.txtApellidoEdit);
            this.Controls.Add(this.txtDniEdit);
            this.Controls.Add(this.txtNombreEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Empleado";
            this.Load += new System.EventHandler(this.FrmEditarEmpleado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreEdit;
        private System.Windows.Forms.TextBox txtDniEdit;
        private System.Windows.Forms.TextBox txtApellidoEdit;
        private System.Windows.Forms.TextBox txtSueldoEdit;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblSueldo;
        private System.Windows.Forms.Label lblTituloEdit;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuarioEdit;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClaveEdit;
    }
}