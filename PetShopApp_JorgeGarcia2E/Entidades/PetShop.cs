using System.Collections.Generic;

namespace Entidades
{
    public static class PetShop
    {
        private static List<Usuario> usuarios;
        private static List<Empleado> empleados;
        private static List<Administrador> administradores;
        private static List<Cliente> clientes;
        private static List<Producto> productos;

        private static string razonSocial;
        private static string cuit;
        private static int ventasTotales;
        private static double facturacionTotal;

        static PetShop()
        {
            razonSocial = "Pet Shop Garcia S.L.";
            cuit = "30-68537634-9";
            ventasTotales = 0;
            facturacionTotal = 0;

            usuarios = new List<Usuario>();
            empleados = new List<Empleado>();
            administradores = new List<Administrador>();
            clientes = new List<Cliente>();
            productos = new List<Producto>();

            CargarEmpleados();
            CargarAdministradores();
            CargarClientes();
            CargarProductos();
        }

        public static string RazonSocial { get { return razonSocial; } }
        public static string Cuit { get { return cuit; } }
        public static int VentasTotales { get { return ventasTotales; } set { ventasTotales = value; } }
        public static double FacturacionTotal { get { return facturacionTotal; } set { facturacionTotal = value; } }
        public static List<Usuario> Usuarios { get { return usuarios; } }
        public static List<Empleado> Empleados { get { return empleados; } }
        public static List<Administrador> Administradores { get { return administradores; } }
        public static List<Cliente> Clientes { get { return clientes; } }
        public static List<Producto> Productos { get { return productos; } }

        #region Hardcodeo

        private static void CargarEmpleados()
        {
            empleados.Add(new Empleado("Pepe", "Gonzales", 12345, "pepe", "pizza12", 100950));
            empleados.Add(new Empleado("Maria", "Suarez", 22345, "maria", "tomate34", 105900));
            empleados.Add(new Empleado("Carla", "Perez", 32345, "lisa", "empanadas56", 110500));
            empleados.Add(new Empleado("Omar", "Villegas", 42345, "omar", "excelente78", 150780));
            empleados.Add(new Empleado("Andrea", "Martinez", 52345, "andrea12", "utn555", 164500));
            empleados.Add(new Empleado("Bruce", "Wayne", 62345, "bruce", "batman666", 124000));
            empleados.Add(new Empleado("Manuel", "Carrasco", 52345, "carrasco", "asd123", 124000));
            empleados.Add(new Empleado("Mario", "Neta", 53347, "mario", "bross45", 124000));
            usuarios.AddRange(empleados);
        }

        private static void CargarAdministradores()
        {
            administradores.Add(new Administrador("Jorge", "Garcia", 99100210, "admin", "admin1", 200000));
            administradores.Add(new Administrador("Ezequiel", "Oggioni", 99100211, "eze", "admin2", 200000));
            administradores.Add(new Administrador("Lucas", "Rodriguez", 99100213, "lucas", "admin3", 200000));
            administradores.Add(new Administrador("Carolina", "Scrofani", 99100214, "caro", "admin4", 200000));
            administradores.Add(new Administrador("Juan Pablo", "Dos Santos", 99100215, "juanpi", "admin5", 200000));
            usuarios.AddRange(administradores);
        }

        private static void CargarClientes()
        {
            clientes.Add(new Cliente("Antonella", "Martini", 40785412));
            clientes.Add(new Cliente("Marcos", "Garcia", 32412563));
            clientes.Add(new Cliente("Pablo", "Diaz", 25789654));
            clientes.Add(new Cliente("Gabriela", "Torres", 12456789));
            clientes.Add(new Cliente("Gabriel", "Martinez", 32852147));
            clientes.Add(new Cliente("Andrea", "Ruiz", 45896321));
            clientes.Add(new Cliente("Susana", "Oria", 46896321, 15420));
            clientes.Add(new Cliente("Aitor", "Tilla", 47896321, 0));
            clientes.Add(new Cliente("Felipe", "Salguero", 48896321, 3850));
            clientes.Add(new Cliente("Carlos", "Perez", 49896321, 87000));
            clientes.Add(new Cliente("Teresa", "Flores", 50896321, 6000));
            clientes.Add(new Cliente("Ricky", "Ricon", 53896321, 150000));
            clientes.Add(new Cliente("Peter", "Parker", 52896321, 85000));
            clientes.Add(new Cliente("Mary", "Jane", 51896321, 76500));
        }

        private static void CargarProductos()
        {
            productos.Add(new Alimento("Pro Plan 15KG", 6880, 10, EMascota.Perro));
            productos.Add(new Alimento("Old Prince 15KG", 4940, 8, EMascota.Perro));
            productos.Add(new Alimento("Royal Canin 3KG", 2215, 6, EMascota.Perro));
            productos.Add(new Alimento("Vitalcan 15KG", 1475, 20, EMascota.Perro));
            productos.Add(new Alimento("Eukanuba 15KG", 6720, 15, EMascota.Perro));
            productos.Add(new Alimento("Cat Chow 3KG", 3240, 18, EMascota.Gato));
            productos.Add(new Alimento("Cat Chow 15KG", 5095, 10, EMascota.Gato));
            productos.Add(new Alimento("Roya Canin Cat 5KG", 7000, 9, EMascota.Gato));
            productos.Add(new Alimento("MV Hollyday 2KG", 1400, 3, EMascota.Gato));
            productos.Add(new Accesorio("Cama pequeña alcolchada", 4000, 1, EAccesorio.Cama));
            productos.Add(new Accesorio("Cama grande alcolchada", 3500, 4, EAccesorio.Cama));
            productos.Add(new Accesorio("Collar reforzado", 800, 20, EAccesorio.Collar));
            productos.Add(new Accesorio("Collar personalizado", 1000, 30, EAccesorio.Collar));
            productos.Add(new Accesorio("Dispenser MPets", 2240, 20, EAccesorio.Comedor));
            productos.Add(new Accesorio("Bebedero plástico", 200, 25, EAccesorio.Comedor));
            productos.Add(new Accesorio("Dispenser Agua/Comida", 1190, 18, EAccesorio.Comedor));
            productos.Add(new Accesorio("Kong Ball", 2230, 18, EAccesorio.Juguete));
            productos.Add(new Cuidado("Basken Plus", 800, 7, ECuidado.Antiparasito));
            productos.Add(new Cuidado("Basken Doble", 135, 10, ECuidado.Antiparasito));
            productos.Add(new Cuidado("Dermosedan 200gr", 270, 25, ECuidado.Shampoo));
            productos.Add(new Cuidado("Cepillo Ferplast", 1070, 100, ECuidado.Cepillo));
            productos.Add(new Cuidado("Rastrillo con puas", 1390, 42, ECuidado.Cepillo));
            productos.Add(new Cuidado("Nexgard", 2750, 80, ECuidado.Antipulgas));
            productos.Add(new Cuidado("Pipeta Frontile", 3500, 50, ECuidado.Antipulgas));

        }
        #endregion

        /// <summary>
        /// Comprueba si el usuario y la clave ingresada coinciden en la lista de usuarios.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns>true si el acceso es válido, false en caso contrario.</returns>
        public static bool Loguearse(string usuario, string clave)
        {
            if (Validaciones.ValidarCredenciales(usuario, clave))
            {
                foreach (Usuario item in usuarios)
                {
                    if (item.User.Trim() == usuario.Trim() && item.Clave.Trim() == clave.Trim())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Busca un Usuario a partir del string pasado por parámetro.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Si el Usuario existe lo retorna, si no existe retorna null.</returns>
        public static Usuario BuscarUsuario(string usuario)
        {
            foreach (Usuario item in usuarios)
            {
                if (item.User == usuario)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Busca un cliente en la lista de clientes a partir del dni pasado como parámetro.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>null si no encontró el cliente en la lista o el cliente en caso contrario.</returns>
        public static Cliente BuscarClientePorDNI(string dni)
        {
            foreach (Cliente item in PetShop.Clientes)
            {
                if (item.DNI.ToString() == dni)
                {
                    return item;
                }
            }

            return null;
        }


        /// <summary>
        /// Busca un cliente a partir del id pasado por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null si no encontró el cliente en la lista o el cliente en caso contrario.</returns>
        public static Cliente BuscarClientePorID(int id)
        {
            if (id > 0)
            {
                foreach (Cliente item in PetShop.Clientes)
                {
                    if (item.ID == id)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Busca un producto en la lista de productos del comercio a partir del id pasado por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null si no lo encontró o el producto en caso contrario.</returns>
        public static Producto BuscarProductoPorID(int id)
        {
            if (id > 0)
            {
                foreach (Producto item in PetShop.Productos)
                {
                    if (item.ID == id)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Trata de realizar una venta si el dinero del cliente es suficiente y existe stock.
        /// </summary>
        /// <param name="cliente">Cliente que realiza la compra.</param>
        /// <param name="usuario">Usuario que realiza la venta.</param>
        /// <param name="carrito">Diccionario compuesto por el id de los productos en las claves y la cantidad a comprar en los valore</param>
        /// <param name="precioTotal">Precio total a pagar</param>
        /// <param name="mensaje">Mensaje del resultado de la operación</param>
        /// <returns>true si se pudo vender, false en caso contrario.</returns>
        public static bool Vender(Cliente cliente, Usuario usuario, Dictionary<int, int> carrito, double precioTotal, out string mensaje)
        {
            if (cliente.DineroDisponible >= precioTotal)
            {
                if (ComprobarStock(carrito))
                {
                    cliente.CantidadDeCompras += 1;
                    VentasTotales += 1;
                    FacturacionTotal += precioTotal;

                    if (usuario.GetType() == typeof(Empleado))
                    {
                        foreach (Empleado item in Empleados)
                        {
                            if (item == usuario)
                            {
                                item.VentasRealizadas += 1;
                            }
                        }
                    }

                    mensaje = "Venta exitosa";
                    return true;
                }
                else
                {
                    mensaje = "Stock insuficiente";
                    return false;
                }
            }
            else
            {
                mensaje = "El cliente no tiene plata suficiente.";
                return false;
            }

        }

        /// <summary>
        /// Descuenta de la lista de productos la cantidad que se quiere comprar si el stock es suficiente.
        /// </summary>
        /// <param name="carrito"></param>
        /// <returns>false si alguna cantidad sobrepasaba el stock disponible, false en caso contrario.</returns>
        private static bool ComprobarStock(Dictionary<int, int> carrito)
        {
            //Clave: ID del producto
            //Valor: Cantidad que se quiere comprar. 
            foreach (Producto producto in Productos)
            {
                //Compruebo si es un producto que se quiere comprar.
                if (carrito.ContainsKey(producto.ID))
                {
                    //Si el valor es menor o igual a la cantidad del producto, resto del stock.
                    if (carrito[producto.ID] <= producto.Cantidad)
                    {
                        producto.Cantidad -= carrito[producto.ID];
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
