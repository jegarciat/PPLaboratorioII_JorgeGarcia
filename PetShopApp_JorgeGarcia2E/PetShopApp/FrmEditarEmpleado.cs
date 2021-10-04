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
    public partial class FrmEditarEmpleado : Form
    {
        private Empleado empleado;

        public FrmEditarEmpleado()
        {
            InitializeComponent();
        }

        public FrmEditarEmpleado(Empleado empleado) : this()
        {
            this.empleado = empleado;
        }

        private void FrmEditarEmpleado_Load(object sender, EventArgs e)
        {
            this.txtDniEdit.Text = empleado.DNI.ToString();
            this.txtNombreEdit.Text = empleado.Nombre;
            this.txtApellidoEdit.Text = empleado.Apellido;
            this.txtSueldoEdit.Text = empleado.Sueldo.ToString();
            this.txtUsuarioEdit.Text = empleado.User;
            this.txtClaveEdit.Text = empleado.Clave;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (empleado is not null && !HayError())
            {
                empleado.Nombre = this.txtNombreEdit.Text;
                empleado.Apellido = this.txtApellidoEdit.Text;
                empleado.Sueldo = double.Parse(this.txtSueldoEdit.Text);
                empleado.User = this.txtUsuarioEdit.Text;
                empleado.Clave = this.txtClaveEdit.Text;

                PetShop.ModificarEmpleado(empleado);

                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Comprueba si hay un dato inválido en cada textBox.
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
            if (!Validaciones.ValidarSueldo(this.txtSueldoEdit.Text))
            {
                this.txtSueldoEdit.Clear();
                this.txtSueldoEdit.PlaceholderText = "Sueldo inválido";
                returnAux = true;
            }
            if (string.IsNullOrWhiteSpace(this.txtUsuarioEdit.Text))
            {
                this.txtUsuarioEdit.Clear();
                this.txtUsuarioEdit.PlaceholderText = "Usuario inválido";
                returnAux = true;
            }
            if (string.IsNullOrWhiteSpace(this.txtClaveEdit.Text))
            {
                this.txtClaveEdit.Clear();
                this.txtClaveEdit.PlaceholderText = "Clave inválida";
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
