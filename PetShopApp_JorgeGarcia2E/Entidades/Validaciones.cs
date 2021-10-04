namespace Entidades
{
    public static class Validaciones
    {
        /// <summary>
        /// Valida que el string este compuesto por solo letras.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>true si esta compuesto por solo letras, false en caso contrario.</returns>
        public static bool SoloLetras(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            foreach (char caracter in nombre.ToCharArray())
            {
                //if (!char.IsLetter(caracter))
                if (char.IsDigit(caracter))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Valida si los strings son nulos o están vacios.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns>true si son strings válidos, false en caso contrario. </returns>
        public static bool ValidarCredenciales(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida que el string sea un DNI válido.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>true si es un DNI válido, false en caso contrario.</returns>
        public static bool ValidarDNI(string dni)
        {
            return (!string.IsNullOrWhiteSpace(dni) && int.TryParse(dni, out int auxiliar) && auxiliar > 0 && auxiliar.ToString().Length <= 8);
        }

        /// <summary>
        /// Valida que el string sea un sueldo válido.
        /// </summary>
        /// <param name="sueldo"></param>
        /// <returns>true si es un sueldo valido, false en caso contrario.</returns>
        public static bool ValidarSueldo(string sueldo)
        {
            return !string.IsNullOrWhiteSpace(sueldo) && double.TryParse(sueldo, out double auxiliar) && auxiliar > 0;
        }
    }
}
