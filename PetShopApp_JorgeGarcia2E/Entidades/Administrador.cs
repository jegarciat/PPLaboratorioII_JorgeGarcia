using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Administrador: Usuario
    {
        public Administrador(string nombre, string apellido, int dni, string usuario, string clave, double sueldo)
            : base(nombre, apellido, dni, usuario, clave, sueldo)
        {

        }

        public double Sueldo
        {
            get
            {
                return this.CalcularSueldo();
            }
            set
            {
                if (value > 0)
                    this.sueldoBase = value;
            }
        }

        /// <summary>
        /// Calcula el sueldo de un Administrador que recibe un bono por la cantidad de ventas totales del comercio.
        /// </summary>
        /// <returns>Sueldo bonificado un 20% si las ventas totales del comercio fueron mayores a 20 en el mes.</returns>
        public override double CalcularSueldo()
        {
            double sueldoBonificado;
            if (PetShop.VentasTotales > 20)
                sueldoBonificado = this.sueldoBase + this.sueldoBase * 0.20;
            else
                sueldoBonificado = this.sueldoBase;

            return sueldoBonificado;
        }
    }
}
