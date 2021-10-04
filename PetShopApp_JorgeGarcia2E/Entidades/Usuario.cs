namespace Entidades
{
    public abstract class Usuario : Persona
    {
        protected string user;
        protected string clave;
        protected double sueldoBase; //Mensual

        public Usuario(string nombre, string apellido, int dni, string usuario, string clave, double sueldo)
            : base(nombre, apellido, dni)
        {
            this.user = usuario;
            this.clave = clave;
            this.sueldoBase = sueldo;
        }

        public string User
        {
            get
            {
                return this.user;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    this.user = value;
            }
        }

        public string Clave
        {
            get
            {
                return this.clave;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    this.clave = value;
            }
        }

        public abstract double CalcularSueldo();
    }
}
