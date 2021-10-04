using Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PetShopApp
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        /// <summary>
        /// Carga el DataGridView con la lista de clientes del comercio.
        /// </summary>
        private void CargarClientes()
        {
            int n;

            foreach (Cliente item in PetShop.Clientes)
            {
                n = this.dgvClientes.Rows.Add();
                this.dgvClientes.Rows[n].Cells[0].Value = item.ID;
                this.dgvClientes.Rows[n].Cells[1].Value = item.Nombre;
                this.dgvClientes.Rows[n].Cells[2].Value = item.Apellido;
                this.dgvClientes.Rows[n].Cells[3].Value = item.DNI;
                this.dgvClientes.Rows[n].Cells[4].Value = item.CantidadDeCompras;
            }

            dgvClientes.AutoResizeColumns();
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente cliente;

            if (this.dgvClientes.SelectedRows.Count == 1)
            {
                int id = int.Parse(this.dgvClientes.CurrentRow.Cells[0].Value.ToString());
                cliente = PetShop.BuscarClientePorID(id);
                FrmEditarCliente frmEditar = new FrmEditarCliente(cliente);

                if (frmEditar.ShowDialog() == DialogResult.OK)
                {
                    this.dgvClientes.Rows.Clear();
                    CargarClientes();
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaCliente altaCliente = new FrmAltaCliente();

            if (altaCliente.ShowDialog() == DialogResult.OK)
            {
                Cliente clienteAgregado = PetShop.Clientes.Last();

                int n = this.dgvClientes.Rows.Add();
                this.dgvClientes.Rows[n].Cells[0].Value = clienteAgregado.ID;
                this.dgvClientes.Rows[n].Cells[1].Value = clienteAgregado.Nombre;
                this.dgvClientes.Rows[n].Cells[2].Value = clienteAgregado.Apellido;
                this.dgvClientes.Rows[n].Cells[3].Value = clienteAgregado.DNI;
                this.dgvClientes.Rows[n].Cells[4].Value = clienteAgregado.CantidadDeCompras;
            }
        }
    }
}
