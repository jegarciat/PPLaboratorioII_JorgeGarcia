using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        protected int id;
        protected string descripcion;
        protected double precioUnitario;
        protected int cantidad;

        private static int ultimoID;

        static Producto()
        {
            ultimoID = 0;
        }

        protected Producto(string descripcion, double precio, int cantidad)
        {
            ultimoID++;
            this.id = ultimoID;
            this.descripcion = descripcion;
            this.precioUnitario = precio;
            this.cantidad = cantidad;
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                    this.descripcion = value;
            }
        }

        public double PrecioUnitario
        {
            get
            {
                return this.precioUnitario;
            }
            set
            {
                if(value > 0)
                    this.precioUnitario = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                if (value > -1)
                    this.cantidad = value;
            }
        }

        public int ID
        {
            get { return this.id; }
        }

        public abstract string TipoDeProducto();

        /// <summary>
        /// Publica la descripción y el precio unitario de un producto.
        /// </summary>
        /// <returns>string con los datos del producto</returns>
        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------------------------\n");
            sb.AppendLine($"Descripción: {this.Descripcion}\n");
            sb.AppendLine($"Precio unitario: {this.PrecioUnitario}");
            
            return sb.ToString();
        }

        /// <summary>
        /// Comprueba si 2 productos son iguales a partir de su ID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son iguales, false en caso contrario</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1 is not null && p2 is not null && p1.ID == p1.ID);
        }

        /// <summary>
        /// Comprueba si 2 productos son distintos a partir de su ID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son distintos, false en caso contrario</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
    }
}
