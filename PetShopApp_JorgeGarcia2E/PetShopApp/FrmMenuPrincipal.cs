using Entidades;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetShopApp
{
    public partial class FrmMenuPrincipal : Form
    {
        private Usuario usuario;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        public FrmMenuPrincipal(Usuario auxUsuario) : this()
        {
            this.usuario = auxUsuario;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.lblSaludo.Text = $"¡Hola {usuario.Nombre} {usuario.Apellido}!";
            this.lblRol.Text = $"Cargo: {usuario.GetType().Name}";

            if (usuario is Empleado)
            {
                this.btnAdministradores.Visible = false;
                this.btnEmpleados.Visible = false;
                this.btnInformes.Visible = false;
                this.BackColor = Color.RoyalBlue;
                this.dgvProductos.BackgroundColor = Color.RoyalBlue;
            }
            else
            {
                this.BackColor = Color.SteelBlue;
                this.dgvProductos.BackgroundColor = Color.SteelBlue;
            }

            this.ListarProductos();
            this.cmbTipo.Items.Add("Todos");
            this.cmbTipo.Items.Add("Alimento");
            this.cmbTipo.Items.Add("Cuidado");
            this.cmbTipo.Items.Add("Accesorio");
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleados frmEmpleados = new FrmEmpleados();

            this.Hide();

            if (frmEmpleados.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();

            this.Hide();

            if (frmClientes.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnAdministradores_Click(object sender, EventArgs e)
        {
            FrmAdministradores frmAdministradores = new FrmAdministradores();

            this.Hide();

            if (frmAdministradores.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmAltaProducto frmAltaProducto = new FrmAltaProducto();

            if (frmAltaProducto.ShowDialog() == DialogResult.OK)
            {
                this.dgvProductos.Rows.Clear();
                this.ListarProductos();
            }
        }

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro/a de salir?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            FrmVender frmVender = new FrmVender(usuario);

            this.Hide();

            if (frmVender.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            FrmInformes informes = new FrmInformes();
            informes.Show();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTipo.SelectedIndex != -1)
            {
                this.dgvProductos.Rows.Clear();
                ListarPorTipo(this.cmbTipo.SelectedItem.ToString());
            }
        }

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
    }
}
