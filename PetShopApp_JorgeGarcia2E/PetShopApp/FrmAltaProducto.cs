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
    public partial class FrmAltaProducto : Form
    {
        public FrmAltaProducto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga los tipos de productos en el comboBox y el estado de algunos controles. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAltaProducto_Load(object sender, EventArgs e)
        {
            this.cmbTipo.Items.Add("Alimento");
            this.cmbTipo.Items.Add("Cuidado");
            this.cmbTipo.Items.Add("Accesorio");
            this.cmbCategoria.Visible = false;
            this.numCantidad.Minimum = 1;
            this.numCantidad.Maximum = int.MaxValue;
            this.btnAceptar.Enabled = false;
        }

        /// <summary>
        /// Cambia la visibilidad del comboBox dependiendo del tipo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbCategoria.Visible = true;
            this.cmbCategoria.Visible = true;
            this.btnAceptar.Enabled = true;

            if (this.cmbTipo.SelectedItem.ToString() == "Alimento")
            {
                this.cmbCategoria.DataSource = Enum.GetValues(typeof(EMascota));
            }
            else if (this.cmbTipo.SelectedItem.ToString() == "Cuidado")
            {
                this.cmbCategoria.DataSource = Enum.GetValues(typeof(ECuidado));
            }
            else
            {
                this.cmbCategoria.DataSource = Enum.GetValues(typeof(EAccesorio));
            }
        }

        /// <summary>
        /// Si no hay errores en los datos se instancia un producto del tipo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!HayError())
            {
                Producto producto = null;

                switch (this.cmbTipo.SelectedItem)
                {
                    case "Alimento":
                        producto = new Alimento(txtDescripcion.Text, double.Parse(txtPrecio.Text), ((int)numCantidad.Value), (EMascota)this.cmbCategoria.SelectedItem);
                        break;
                    case "Cuidado":
                        producto = new Cuidado(txtDescripcion.Text, double.Parse(txtPrecio.Text), ((int)numCantidad.Value), (ECuidado)this.cmbCategoria.SelectedItem);
                        break;
                    case "Accesorio":
                        producto = new Accesorio(txtDescripcion.Text, double.Parse(txtPrecio.Text), ((int)numCantidad.Value), (EAccesorio)this.cmbCategoria.SelectedItem);
                        break;
                }

                if (producto is not null)
                {
                    PetShop.Productos.Add(producto);
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Valida cada uno de los textos y si el dato es inválido escribe un mensaje en el placeholder indicando el error.
        /// </summary>
        /// <returns>false si no hay errores, true en caso contrario.</returns>
        private bool HayError()
        {
            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                this.txtDescripcion.Clear();
                this.txtDescripcion.PlaceholderText = "Descripción inválida";
                return true;
            }

            if (string.IsNullOrWhiteSpace(this.txtPrecio.Text) || !double.TryParse(txtPrecio.Text, out _))
            {
                this.txtPrecio.Clear();
                this.txtPrecio.PlaceholderText = "Precio inválido";
                return true;
            }

            return false;
        }
    }
}
