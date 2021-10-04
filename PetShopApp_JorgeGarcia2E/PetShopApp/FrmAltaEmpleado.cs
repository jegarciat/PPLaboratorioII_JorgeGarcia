using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PetShopApp
{
    public partial class FrmAltaEmpleado : Form
    {
        SoundPlayer sonido;

        public FrmAltaEmpleado()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Instancia el sonido que se va a usar en caso de que la alta sea exitosa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAltaEmpleado_Load(object sender, EventArgs e)
        {
            sonido = new SoundPlayer(@"C:\Users\jorge\source\1erParcial\PetShopApp_JorgeGarcia2E\Sonidos\InicioExitoso.wav");
        }

        /// <summary>
        /// Si no hay errores instancia un nuevo empleado con los datos recibidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!HayError())
            {
                Empleado nuevoEmpleado = new Empleado(this.txtNombre.Text, this.txtApellido.Text, int.Parse(this.txtDni.Text), this.txtUsuario.Text, this.txtClave.Text, double.Parse(this.txtSueldo.Text));

                if(PetShop.Empleados != nuevoEmpleado)
                {
                    PetShop.Empleados.Add(nuevoEmpleado);
                    PetShop.Usuarios.Add(nuevoEmpleado);
                    sonido.Play();
                    this.DialogResult = DialogResult.OK;
                    
                }
                else
                {
                    MessageBox.Show("¡El DNI ingresado ya existe!", "¡Ojo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Valida cada uno de los textos y si el dato es inválido escribe un mensaje en el placeholder indicando el error.
        /// </summary>
        /// <returns>false si no hay errores, true en caso contrario.</returns>
        private bool HayError()
        {
            bool returnAux = false;

            if (!Validaciones.SoloLetras(this.txtNombre.Text))
            {
                this.txtNombre.Clear();
                this.txtNombre.PlaceholderText = "Nombre inválido";
                returnAux = true;
            }

            if (!Validaciones.SoloLetras(this.txtApellido.Text))
            {
                this.txtApellido.Clear();
                this.txtApellido.PlaceholderText = "Apellido inválido";
                returnAux = true;
            }

            if (!Validaciones.ValidarSueldo(this.txtSueldo.Text))
            {
                this.txtSueldo.Clear();
                this.txtSueldo.PlaceholderText = "Sueldo inválido";
                returnAux = true;
            }

            if (!Validaciones.ValidarDNI(this.txtDni.Text))
            {
                this.txtDni.Clear();
                this.txtDni.PlaceholderText = "DNI inválido";
                returnAux = true;
            }

            if (string.IsNullOrWhiteSpace(this.txtUsuario.Text))
            {
                this.txtUsuario.Clear();
                this.txtUsuario.PlaceholderText = "Usuario inválido";
                returnAux = true;
            }

            if (string.IsNullOrWhiteSpace(this.txtClave.Text))
            {
                this.txtClave.Clear();
                this.txtClave.PlaceholderText = "Clave inválida";
                returnAux = true;
            }

            return returnAux;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
