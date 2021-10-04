using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona
    {
        private int id;
        private double dineroDisponible;
        private int cantidadCompras;

        private static int ultimoID;
        private static Random random;
        
        static Cliente()
        {
            ultimoID = 0;
            random = new Random();
        }

        public Cliente(string nombre, string apellido, int dni) : base(nombre, apellido, dni)
        {
            ultimoID++;
            this.id = ultimoID;
            this.cantidadCompras = 0;
            this.dineroDisponible = random.Next(0, 30000);
        }

        public Cliente(string nombre, string apellido, int dni, int dineroDisponible) : this(nombre, apellido, dni)
        {
            this.dineroDisponible = dineroDisponible;
        }

        public double DineroDisponible
        {
            get
            {
                return this.dineroDisponible;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
        }

        public int CantidadDeCompras
        {
            get
            {
                return this.cantidadCompras;
            }
            set
            {
                this.cantidadCompras = value;
            }
        }

        /// <summary>
        /// Comprueba que un cliente se encuentra en la lista pasada por parámetro.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="empleado"></param>
        /// <returns>true si se encuentra, false en caso contrario</returns>
        public static bool operator ==(List<Cliente> lista, Cliente cliente)
        {
            foreach (Cliente item in lista)
            {
                if (item == cliente)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Comprueba que un cliente no se encuentra en la lista pasada por parámetro.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="empleado"></param>
        /// <returns>true si no es encuentra, false en caso contrario.</returns>
        public static bool operator !=(List<Cliente> lista, Cliente cliente)
        {
            return !(lista == cliente);
        }

        /// <summary>
        /// Conversor explicito que devuelve el cliente con más compras en la lista.
        /// </summary>
        /// <param name="clientes"></param>
        public static explicit operator Cliente(List<Cliente> clientes)
        {
            Cliente clienteMasComprador = null;

            foreach (Cliente item in clientes)
            {
                if (clienteMasComprador is null || item.CantidadDeCompras > clienteMasComprador.CantidadDeCompras)
                {
                    clienteMasComprador = item;
                }
            }

            return clienteMasComprador;
        }
    }
}
