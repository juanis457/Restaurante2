using System;
using System.Text;

namespace sistemarestaurante
{
    internal class Utilitario //La clase Utilitario sirve como un conjunto de funciones auxiliares o de utilidad que facilitan la realización de tareas comunes 
    {
        public static string CARACTER_ESPACIO = " ";       

        // Convierte una cadena a flotante, devuelve -1 si no puede convertir
        public static float ConvertirFlotante(string temp)
        {
            float salida = -1f; // Para validar si la conversión falla
            if (!float.TryParse(temp, out salida))
            {
                Console.WriteLine("Error al intentar convertir a flotante: " + temp);
            }
            return salida;
        }

        // Convierte una cadena a entero, devuelve -1 si no puede convertir
        public static int ConvertirEntero(string temp)
        {
            int salida = -1; // Para validar si la conversión falla
            if (!int.TryParse(temp, out salida))
            {
                Console.WriteLine("Error al intentar convertir a entero: " + temp);
            }
            return salida;
        }

        // Separa una cadena usando un delimitador especificado
        public static string[] SepararCadena(string cadena, char separador)
        {
            return cadena.Split(separador);
        }

        // Imprime un número específico de espacios en la consola
        public static void ImprimirEspacios(int total)
        {
            Console.Write(new string(CARACTER_ESPACIO[0], total));
        }

        // Minifica un nombre eliminando los espacios
        public static string MinificarNombre(string nombre)
        {
            string[] temp = SepararCadena(nombre, ' ');
            StringBuilder salida = new StringBuilder();
            foreach (var item in temp)
            {
                salida.Append(item);
            }
            return salida.ToString();
        }

        // Añade espacios antes o después de una cadena, dependiendo de la posición
        public static string ImprimirEspacios(string cadena, int total, bool posicion)
        {
            int cantidad = total - cadena.Length;
            if (cantidad > 0)
            {
                string espacios = new string(' ', cantidad);
                return posicion ? cadena + espacios : espacios + cadena;
            }
            else
            {
                return TruncarTexto(cadena, total);
            }
        }

        // Centra una palabra en la consola con un ancho específico
        internal static void CentrarPalabra(string palabra, int ancho)
        {
            int medio = (ancho - palabra.Length) / 2;
            int ajuste = (2 * medio + palabra.Length < ancho) ? 1 : 0;
            
            ImprimirEspacios(medio);
            Console.Write(palabra);
            ImprimirEspacios(medio + ajuste);
            Console.WriteLine();
        }

        // Añade espacios antes de una cadena
        public static string ImprimirEspaciosInicio(string cadena, int total)
        {
            return ImprimirEspacios(cadena, total, false);
        }

        // Añade espacios después de una cadena
        public static string ImprimirEspaciosFin(string cadena, int total)
        {
            return ImprimirEspacios(cadena, total, true);
        }

        // Imprime un separador con un carácter repetido
        public static void ImprimirSeparador(char caracter, int total)
        {
            Console.WriteLine(new string(caracter, total));
        }

        // Formatea un dígito, agregando un 0 al inicio si es menor a 10
        public static string FormatearDigito(string digitos)
        {
            return (ConvertirEntero(digitos) < 10) ? "0" + digitos : digitos;
        }

        // Trunca un texto si excede un límite de caracteres :)
        public static string TruncarTexto(string cadena, int total_caracteres)
        {
            return cadena.Length > total_caracteres ? cadena.Substring(0, total_caracteres) : cadena;
        }
    }
}
