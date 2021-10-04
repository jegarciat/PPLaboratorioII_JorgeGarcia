using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuidado : Producto
    {
        private ECuidado cuidado;

        public Cuidado(string descripcion, double precio, int cantidad, ECuidado cuidado) : base(descripcion, precio, cantidad)
        {
            this.cuidado = cuidado;
        }

        public ECuidado Articulo
        {
            get
            {
                return this.cuidado;
            }
        }

        /// <summary>
        /// Muestra el tipo de la clase.
        /// </summary>
        /// <returns></returns>
        public override string TipoDeProducto()
        {
            return this.GetType().Name;
        }

        /// <summary>
        /// Muestra los datos del producto.
        /// </summary>
        /// <returns>Stringbuilder con los datos del producto.</returns>
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Articulo de cuidado: {this.Articulo}");

            return sb.ToString();
        }
    }
}
