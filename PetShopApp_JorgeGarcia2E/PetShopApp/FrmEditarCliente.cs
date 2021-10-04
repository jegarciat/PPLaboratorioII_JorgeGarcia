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

namespace PetShopApp
{
    public partial class FrmEditarCliente : Form
    {
        private Cliente cliente;

        public FrmEditarCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibe un cliente y lo setea en atributo privado del formulario.
        /// </summary>
        /// <param name="empleado"></param>
        public FrmEditarCliente(Cliente cliente): this()
        {
            this.cliente = cliente;
        }

        /// <summary>
        /// Carga los textBoxs con los datos del cliente recibido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditarCliente_Load(object sender, EventArgs e)
        {
            this.txtID.Text = cliente.ID.ToString();
            this.txtNombreEdit.Text = cliente.Nombre;
            this.txtApellidoEdit.Text = cliente.Apellido;
            this.txtDniEdit.Text = cliente.DNI.ToString();
        }

        /// <summary>
        /// Edita los datos de un cliente en la lista del comercio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cliente is not null && !HayError())
            {
                cliente.Nombre = this.txtNombreEdit.Text;
                cliente.Apellido = this.txtApellidoEdit.Text;

                this.DialogResult = DialogResult.OK;
            }
        }


        /// <summary>
        /// Valida cada uno de los textos y si el dato es inválido escribe un mensaje en el placeholder indicando el error.
        /// </summary>
        /// <returns>false si no hay errores, true en caso contrario.</returns>
        private bool HayError()
        {
            bool returnAux = false;

            if (!Validaciones.SoloLetras(this.txtNombreEdit.Text))
            {
                this.txtNombreEdit.Clear();
                this.txtNombreEdit.PlaceholderText = "Nombre inválido";
                returnAux = true;
            }
            if (!Validaciones.SoloLetras(this.txtApellidoEdit.Text))
            {
                this.txtApellidoEdit.Clear();
                this.txtApellidoEdit.PlaceholderText = "Apellido inválido";
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
