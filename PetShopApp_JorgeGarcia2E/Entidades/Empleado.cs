using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Usuario
    {
        private int cantidadDeVentas;

        public Empleado(string nombre, string apellido, int dni, string usuario, string clave, double sueldo)
            : base(nombre, apellido, dni, usuario, clave, sueldo)
        {
            this.cantidadDeVentas = 0;
        }

        public int VentasRealizadas
        {
            get
            {
                return this.cantidadDeVentas;
            }
            set
            {
                this.cantidadDeVentas = value;
            }
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
        /// Calcula el sueldo de un empleado que recibe un bono por la cantidad de ventas que haga.
        /// </summary>
        /// <returns>Sueldo bonificado un 10% si las ventas realizadas fueron mayores a 5.</returns>
        public override double CalcularSueldo()
        {
            double sueldoBonificado;
            if (cantidadDeVentas > 5)
                sueldoBonificado = this.sueldoBase + this.sueldoBase * 0.10;
            else
                sueldoBonificado = this.sueldoBase;

            return sueldoBonificado;
        }


        /// <summary>
        /// Busca el empleado con más ventas en la lista pasada por parámetro.
        /// </summary>
        /// <param name="empleados"></param>
        public static explicit operator Empleado(List<Empleado> empleados)
        {
            Empleado empleadoConMasVentas = null;

            foreach (Empleado item in empleados)
            {
                if (empleadoConMasVentas is null || item.VentasRealizadas > empleadoConMasVentas.VentasRealizadas)
                {
                    empleadoConMasVentas = item;
                }
            }

            return empleadoConMasVentas;
        }

        /// <summary>
        /// Comprueba que un empleado se encuentra en la lista pasada por parámetro.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="empleado"></param>
        /// <returns>true si se encuentra, false en caso contrario</returns>
        public static bool operator ==(List<Empleado> lista, Empleado empleado)
        {
            foreach (Empleado item in lista)
            {
                if (item == empleado)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Comprueba que un empleado no se encuentra en la lista pasada por parámetro.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="empleado"></param>
        /// <returns>true si no es encuentra, false en caso contrario.</returns>
        public static bool operator !=(List<Empleado> lista, Empleado empleado)
        {
            return !(lista == empleado);
        }

        /// <summary>
        /// Busca un empleado a partir del dni pasado por parámetro.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static Empleado BuscarEmpleado(int dni)
        {
            if (Validaciones.ValidarDNI(dni.ToString()))
            {
                foreach (Empleado item in PetShop.Empleados)
                {
                    if (item.DNI == dni)
                    {
                        return item;
                    }
                }
            }

            return null;
        }
    }
}
