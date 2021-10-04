using System;
using System.Text;

namespace Entidades
{
    public abstract class Persona
    {
        protected int dni;
        protected string nombre;
        protected string apellido;

        protected Persona(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public int DNI
        {
            get { return this.dni; }
        }

        /// <summary>
        /// Comprueba si 2 personas son iguales a partir del DNI.
        /// </summary>
        /// <param name="persona1"></param>
        /// <param name="persona2"></param>
        /// <returns></returns>
        public static bool operator ==(Persona persona1, Persona persona2)
        {
            return (persona1 is not null && persona2 is not null && persona1.DNI == persona2.DNI);
        }

        /// <summary>
        /// Comprueba si 2 personas son distintas a partir del DNI.
        /// </summary>
        /// <param name="persona1"></param>
        /// <param name="persona2"></param>
        /// <returns></returns>
        public static bool operator !=(Persona persona1, Persona persona2)
        {
            return !(persona1 == persona2);
        }

        /// <summary>
        /// Publica los datos de una persona.
        /// </summary>
        /// <returns>Stringbuilder con los datos de la persona.</returns>
        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"DNI: {this.dni}");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Apellido: {this.apellido}");

            return sb.ToString();
        }
    }
}
