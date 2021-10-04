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
    public partial class FrmInformes : Form
    {
        public FrmInformes()
        {
            InitializeComponent();
        }

        private void FrmInformes_Load(object sender, EventArgs e)
        {
            lblComercioRS.Text = PetShop.RazonSocial;
            lblComercioCuit.Text = PetShop.Cuit;
            lblFacturacion.Text = PetShop.FacturacionTotal.ToString();


            if (((Empleado)PetShop.Empleados).VentasRealizadas > 0)
                lblMejorEmpleado.Text = $"{((Empleado)PetShop.Empleados).Nombre} {((Empleado)PetShop.Empleados).Apellido}";
            else
                lblMejorEmpleado.Text = "No hay ventas todavía";

            lblVentasTotales.Text = PetShop.VentasTotales.ToString();

            if (((Cliente)PetShop.Clientes).CantidadDeCompras > 0)
                lblMejorCliente.Text = $"{((Cliente)PetShop.Clientes).Nombre} {((Cliente)PetShop.Clientes).Apellido}";
            else
                lblMejorCliente.Text = "No hay ventas todavía";

            lbl_TotalClientes.Text = PetShop.Clientes.Count.ToString();
            lblTotalEmpleados.Text = PetShop.Usuarios.Count.ToString();
        }
    }
}
