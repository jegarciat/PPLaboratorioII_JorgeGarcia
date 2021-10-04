using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace PetShopApp
{
    public partial class FrmVender : Form
    {
        private Usuario usuario;
        private Cliente cliente;
        private Producto producto;
        private Dictionary<int, int> carrito;
        private static double iva;

        static FrmVender()
        {
            iva = 0.21;
        }

        /// <summary>
        /// Instancia los componentes y el diccionario.
        /// </summary>
        public FrmVender()
        {
            InitializeComponent();
            carrito = new Dictionary<int, int>();
        }

        /// <summary>
        /// Constructor que recibe un empleado que va a realizar la vneta y lo setea en atributo privado del formulario.
        /// </summary>
        /// <param name="empleado"></param>
        public FrmVender(Usuario vendedor) : this()
        {
            this.usuario = vendedor;
        }

        /// <summary>
        /// Setea algunos controles del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVender_Load(object sender, EventArgs e)
        {
            this.txtID.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido.Enabled = false;
            this.txtDni.Enabled = false;
            this.btnAgregarProducto.Enabled = false;
            this.numCantidad.Maximum = int.MaxValue;
            this.txtSubtotal.Text = "0";
            this.txtPrecioTotal.Text = "0";
            this.cmbFiltroCliente.Items.Add("DNI");
            this.cmbFiltroCliente.Items.Add("ID");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Abre un formulario para dar de alta un nuevo cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmAltaCliente frmAltaCliente = new FrmAltaCliente();

            if (frmAltaCliente.ShowDialog() == DialogResult.OK)
            {
                this.cliente = PetShop.Clientes.Last();
                this.txtID.Text = cliente.ID.ToString();
                this.txtNombre.Text = cliente.Nombre;
                this.txtApellido.Text = cliente.Apellido;
                this.txtDni.Text = cliente.DNI.ToString();
            }
        }

        /// <summary>
        /// Busca un cliente según el criterio de busqueda elegido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            switch (this.cmbFiltroCliente.SelectedItem)
            {
                case "DNI":
                    BuscarClientePorDNI();
                    break;
                case "ID":
                    BuscarClientePorID();
                    break;
                default:
                    this.txtBuscarCliente.PlaceholderText = "Selecciona una opción";
                    break;
            }
        }

        /// <summary>
        /// Abre un formulario con la lista de productos y setea los datos del producto seleccionado en campos correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmListaProductos listaProductos = new FrmListaProductos();

            if (listaProductos.ShowDialog() == DialogResult.OK && listaProductos.ProductoSeleccionado is not null)
            {
                this.txtDescripcion.Text = listaProductos.ProductoSeleccionado.Descripcion;
                this.txtPrecioUnitario.Text = listaProductos.ProductoSeleccionado.PrecioUnitario.ToString();
                this.txtTipo.Text = listaProductos.ProductoSeleccionado.TipoDeProducto();
                this.producto = listaProductos.ProductoSeleccionado;
            }
        }

        /// <summary>
        /// Busca un cliente a partir del ID escrito en el textBox.
        /// </summary>
        private void BuscarClientePorID()
        {
            if (int.TryParse(this.txtBuscarCliente.Text, out int auxClienteID))
            {
                this.cliente = PetShop.BuscarClientePorID(auxClienteID);

                if (this.cliente is not null)
                {
                    this.txtID.Text = cliente.ID.ToString();
                    this.txtNombre.Text = cliente.Nombre;
                    this.txtApellido.Text = cliente.Apellido;
                    this.txtDni.Text = cliente.DNI.ToString();
                }
                else
                {
                    MessageBox.Show("¡El ID ingresado no existe!", "¡Ojo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                this.txtBuscarCliente.Clear();
                this.txtBuscarCliente.PlaceholderText = "ID inválido";
            }
        }

        /// <summary>
        /// Busca un cliente a partir del DNI escrito en el textBox.
        /// </summary>
        private void BuscarClientePorDNI()
        {
            if (Validaciones.ValidarDNI(this.txtBuscarCliente.Text))
            {
                this.cliente = PetShop.BuscarClientePorDNI(this.txtBuscarCliente.Text);

                if (this.cliente is not null)
                {
                    this.txtID.Text = cliente.ID.ToString();
                    this.txtNombre.Text = cliente.Nombre;
                    this.txtApellido.Text = cliente.Apellido;
                    this.txtDni.Text = cliente.DNI.ToString();
                }
                else
                {
                    MessageBox.Show("¡El DNI ingresado no existe!", "¡Ojo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                this.txtBuscarCliente.Clear();
                this.txtBuscarCliente.PlaceholderText = "DNI inválido";
            }
        }

        /// <summary>
        /// Valida que exista la cantidad requeridda y suma al producto a listBox o muestra un mensaje de advertencia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (ValidarProducto())
            {
                if (carrito.ContainsKey(this.producto.ID))
                    carrito[this.producto.ID] += (int)numCantidad.Value;
                else
                    carrito.Add(this.producto.ID, (int)numCantidad.Value);

                lstCarrito.Items.Add($"{this.producto.Descripcion} x{this.numCantidad.Value}");

                //Se calcula el subtotal y el total para mostrarlo a medida que se van sumando productos.
                double auxSubTotal = this.producto.PrecioUnitario * (int)this.numCantidad.Value;
                this.txtSubtotal.Text = (int.Parse(txtSubtotal.Text) + auxSubTotal).ToString();
                double auxPrecioTotal = (int.Parse(txtSubtotal.Text) + int.Parse(txtSubtotal.Text) * iva);
                this.txtPrecioTotal.Text = auxPrecioTotal.ToString();
            }
            else
            {
                MessageBox.Show($"No hay stock suficiente. \nCantidad disponible: {this.producto.Cantidad}", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (numCantidad.Value > 0)
                this.btnAgregarProducto.Enabled = true;
            else
                this.btnAgregarProducto.Enabled = false;
        }

        /// <summary>
        /// Comprueba que los datos escritos por el usuario sean válidos.
        /// </summary>
        /// <returns>true si es válido, false en caso contrario.</returns>
        private bool ValidarProducto()
        {
            if (!string.IsNullOrWhiteSpace(this.txtDescripcion.Text) && !string.IsNullOrWhiteSpace(this.txtTipo.Text) && !string.IsNullOrWhiteSpace(this.txtPrecioUnitario.Text)
                && numCantidad.Value <= this.producto.Cantidad)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Realiza una venta si las condiciones están dadas o muestra un mensaje de error en caso contrario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            SoundPlayer sound;
            double precioTotal = double.Parse(this.txtPrecioTotal.Text);
            string mensaje;

            if (DatosCompletosVenta())
            {
                if (PetShop.Vender(cliente, usuario, carrito, precioTotal, out mensaje))
                {
                    sound = new SoundPlayer(@"C:\Users\jorge\source\1erParcial\PetShopApp_JorgeGarcia2E\Sonidos\ExitoVenta.wav");
                    sound.Play();

                    if (MessageBox.Show($"{mensaje}.\n¿Desea generar factura?", "Venta realizada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GenerarTXT();
                        MessageBox.Show("Factura generada");
                    }
                }
                else
                {
                    sound = new SoundPlayer(@"C:\Users\jorge\source\1erParcial\PetShopApp_JorgeGarcia2E\Sonidos\VentaNegada.wav");
                    sound.Play();
                    MessageBox.Show(mensaje, "Venta cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Limpiar();
            }

        }

        /// <summary>
        /// Comprueba están todos los datos necesarios para poder realizar una venta.
        /// </summary>
        /// <returns>false si no lo están, true en caso contrario.</returns>
        private bool DatosCompletosVenta()
        {
            if (lstCarrito.Items.Count > 0 && !string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Datos incompletos para la venta", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// Genera un archivo txt con todos los datos de la venta realizada.
        /// </summary>
        private void GenerarTXT()
        {
            StringBuilder datosProductos = new StringBuilder();

            foreach (KeyValuePair<int, int> item in carrito)
            {
                datosProductos.AppendLine(PetShop.BuscarProductoPorID(item.Key).MostrarDatos());
                datosProductos.AppendLine($"Cantidad: {item.Value}");
            }

            TextWriter factura = new StreamWriter("Factura.txt");
            factura.WriteLine("---- FACTURA ----");
            factura.WriteLine(PetShop.RazonSocial);
            factura.WriteLine(PetShop.Cuit);
            factura.WriteLine("\n- Cliente -");
            factura.WriteLine(cliente.MostrarDatos());
            factura.WriteLine($"Precio total: {this.txtPrecioTotal.Text}\n");
            factura.WriteLine("Compras realizadas");
            factura.WriteLine(datosProductos);
            factura.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Limpia los datos del producto y el carrito.
        /// </summary>
        private void Limpiar()
        {
            this.txtPrecioTotal.Text = "0";
            this.txtSubtotal.Text = "0";
            this.lstCarrito.Items.Clear();

            this.txtDescripcion.Clear();
            this.numCantidad.Value = 0;
            this.txtTipo.Clear();
            this.txtPrecioUnitario.Clear();
        }

        private void FrmVender_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
