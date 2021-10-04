using Entidades;
using System;
using System.Windows.Forms;

namespace PetShopApp
{
    public partial class FrmAdministradores : Form
    {
        public FrmAdministradores()
        {
            InitializeComponent();
        }

        private void FrmAdministradores_Load(object sender, EventArgs e)
        {
            CargarAdministradores();
        }

        /// <summary>
        /// Carga el DataGridView con la lista de administradores del comercio.
        /// </summary>
        private void CargarAdministradores()
        {
            int n;

            foreach (Administrador item in PetShop.Administradores)
            {
                n = this.dgvAdministradores.Rows.Add();
                this.dgvAdministradores.Rows[n].Cells[0].Value = item.DNI;
                this.dgvAdministradores.Rows[n].Cells[1].Value = item.Nombre;
                this.dgvAdministradores.Rows[n].Cells[2].Value = item.Apellido;
                this.dgvAdministradores.Rows[n].Cells[3].Value = item.Sueldo;
            }

            dgvAdministradores.AutoResizeColumns();
            dgvAdministradores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void FrmAdministradores_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
