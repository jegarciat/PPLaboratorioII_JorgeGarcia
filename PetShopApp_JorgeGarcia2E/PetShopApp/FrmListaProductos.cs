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
    public partial class FrmListaProductos : Form
    {
        private Producto producto;

        public FrmListaProductos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga el comboBox con los tipos de productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmListaProductos_Load(object sender, EventArgs e)
        {
            ListarProductos();
            this.cmbTipos.Items.Add("Todos");
            this.cmbTipos.Items.Add("Alimento");
            this.cmbTipos.Items.Add("Cuidado");
            this.cmbTipos.Items.Add("Accesorio");
        }

        /// <summary>
        /// Propiedad de solo lectura del producto seleccionado por el usuario.
        /// </summary>
        public Producto ProductoSeleccionado
        {
            get
            {
                return this.producto;
            }
        }

        /// <summary>
        /// Lista todos los productos en el datagridview
        /// </summary>
        private void ListarProductos()
        {
            int n;

            foreach (Producto item in PetShop.Productos)
            {
                n = this.dgvProductos.Rows.Add();
                this.dgvProductos.Rows[n].Cells[0].Value = item.ID;
                this.dgvProductos.Rows[n].Cells[1].Value = item.Descripcion;
                this.dgvProductos.Rows[n].Cells[2].Value = item.PrecioUnitario;
                this.dgvProductos.Rows[n].Cells[3].Value = item.Cantidad;
                this.dgvProductos.Rows[n].Cells[4].Value = item.GetType().Name;
            }

            dgvProductos.AutoResizeColumns();
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Selecciona un producto y lo busca en la lista de productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElegir_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.SelectedRows.Count == 1)
            {
                int id = int.Parse(this.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                this.producto = PetShop.BuscarProductoPorID(id);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Debes seleccionar un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Lista los productos por el tipo seleccionado en el comboBox.
        /// </summary>
        /// <param name="tipo"></param>
        private void ListarPorTipo(string tipo)
        {
            int n;

            if (tipo != "Todos")
            {
                foreach (Producto item in PetShop.Productos)
                {
                    if (item.GetType().Name == tipo)
                    {
                        n = this.dgvProductos.Rows.Add();
                        this.dgvProductos.Rows[n].Cells[0].Value = item.ID;
                        this.dgvProductos.Rows[n].Cells[1].Value = item.Descripcion;
                        this.dgvProductos.Rows[n].Cells[2].Value = item.PrecioUnitario;
                        this.dgvProductos.Rows[n].Cells[3].Value = item.Cantidad;
                        this.dgvProductos.Rows[n].Cells[4].Value = item.GetType().Name;
                    }
                }
            }
            else
                ListarProductos();
        }

        private void cmbTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTipos.SelectedIndex != -1)
            {
                this.dgvProductos.Rows.Clear();
                ListarPorTipo(this.cmbTipos.SelectedItem.ToString());
            }
        }
    }
}
