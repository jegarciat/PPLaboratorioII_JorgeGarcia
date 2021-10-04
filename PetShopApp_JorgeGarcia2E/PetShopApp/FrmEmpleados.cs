using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace PetShopApp
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarListaEmpleados();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaEmpleado altaEmpleado = new FrmAltaEmpleado();

            if (altaEmpleado.ShowDialog() == DialogResult.OK)
            {
                Empleado empleadoAgregado = PetShop.Empleados.Last();

                int n = this.dgvListaEmpleados.Rows.Add();
                this.dgvListaEmpleados.Rows[n].Cells[0].Value = empleadoAgregado.DNI;
                this.dgvListaEmpleados.Rows[n].Cells[1].Value = empleadoAgregado.Nombre;
                this.dgvListaEmpleados.Rows[n].Cells[2].Value = empleadoAgregado.Apellido;
                this.dgvListaEmpleados.Rows[n].Cells[3].Value = empleadoAgregado.Sueldo;
                this.dgvListaEmpleados.Rows[n].Cells[4].Value = empleadoAgregado.User;
                this.dgvListaEmpleados.Rows[n].Cells[5].Value = empleadoAgregado.Clave;
            }           
        }

        private void CargarListaEmpleados()
        {
            int n;

            foreach (Empleado item in PetShop.Empleados)
            {
                n = this.dgvListaEmpleados.Rows.Add();
                this.dgvListaEmpleados.Rows[n].Cells[0].Value = item.DNI;
                this.dgvListaEmpleados.Rows[n].Cells[1].Value = item.Nombre;
                this.dgvListaEmpleados.Rows[n].Cells[2].Value = item.Apellido;
                this.dgvListaEmpleados.Rows[n].Cells[3].Value = item.Sueldo;
                this.dgvListaEmpleados.Rows[n].Cells[4].Value = item.User;
                this.dgvListaEmpleados.Rows[n].Cells[5].Value = item.Clave;
            }

            this.dgvListaEmpleados.AutoResizeColumns();
            this.dgvListaEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Empleado empleadoEdit;

            if (this.dgvListaEmpleados.SelectedRows.Count == 1)
            {
                int dni = int.Parse(this.dgvListaEmpleados.CurrentRow.Cells[0].Value.ToString());
                empleadoEdit = Empleado.BuscarEmpleado(dni);
                FrmEditarEmpleado frmEditar = new FrmEditarEmpleado(empleadoEdit);

                if (frmEditar.ShowDialog() == DialogResult.OK)
                {
                    this.dgvListaEmpleados.Rows.Clear();
                    CargarListaEmpleados();
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmEmpleados_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
