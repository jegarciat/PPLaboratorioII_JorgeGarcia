using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alimento : Producto
    {
        private EMascota mascota;

        public Alimento(string descripcion, double precio, int cantidad, EMascota mascota): base(descripcion, precio, cantidad)
        {
            this.mascota = mascota;
        }

        public EMascota Mascota
        {
            get
            {
                return this.mascota;
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

        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Alimento para: {this.Mascota}");

            return sb.ToString();
        }
    }
}
