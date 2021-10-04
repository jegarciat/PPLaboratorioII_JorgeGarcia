using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopApp
{
    public partial class FrmAltaCliente : Form
    {
        SoundPlayer sonido;

        public FrmAltaCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instancia el sonido que se va a usar en caso de que la alta sea exitosa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAltaCliente_Load(object sender, EventArgs e)
        {
            sonido = new SoundPlayer(@"C:\Users\jorge\source\1erParcial\PetShopApp_JorgeGarcia2E\Sonidos\InicioExitoso.wav");
        }

        /// <summary>
        /// Si no hay errores instancia un nuevo cliente con los datos recibidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!HayError())
            {
                Cliente nuevoCliente = new Cliente(this.txtNombre.Text, this.txtApellido.Text, int.Parse(this.txtDni.Text));

                if (PetShop.Clientes != nuevoCliente)
                {
                    PetShop.Clientes.Add(nuevoCliente);
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

            if (!Validaciones.ValidarDNI(this.txtDni.Text))
            {
                this.txtDni.Clear();
                this.txtDni.PlaceholderText = "DNI inválido";
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
