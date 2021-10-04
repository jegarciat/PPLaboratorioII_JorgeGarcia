using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Accesorio : Producto
    {
        private EAccesorio accesorio;

        public Accesorio(string descripcion, double precio, int cantidad, EAccesorio accesorio) : base(descripcion, precio, cantidad)
        {
            this.accesorio = accesorio;
        }

        public EAccesorio Articulo
        {
            get
            {
                return this.accesorio;
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
            sb.AppendLine($"Accesorio: {this.Articulo}");

            return sb.ToString();
        }
    }
}
