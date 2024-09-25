using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    // Clase Producto que almacena información de diferentes productos disponibles en el restaurante
    internal class Producto
    {
        // Arreglo unidimensional 'precio' que almacena el precio de 12 productos diferentes.
        private string[] precio = new string[12] 
        { 
            "10000", "20000", "5000", "20000", "7000", "10000", "2000", 
            "5000", "3000", "8000", "20000", "25000" 
        };

        // Arreglo unidimensional 'cantidad' que almacena la cantidad disponible de cada uno de los 12 productos.
        private string[] cantidad = new string[12] 
        { 
            "10", "10", "20", "29", "16", "14", "7", 
            "33", "22", "60", "30", "10" 
        };

        // Arreglo unidimensional 'nombre' que almacena los nombres de 12 productos del restaurante.
        private string[] nombre = new string[12] 
        { 
            "Sushi", "Ramen", "Filete", "Pollo", "Papas Francesas", "Ensalada Cesar", 
            "Gaseosa", "Jugo natural", "Helado", "Pizza", "Bandeja paisa", "Langostinos" 
        };

        // Propiedad pública para acceder y modificar el arreglo 'precio'.
        public string[] Precio 
        { 
            get => precio; 
            set => precio = value; 
        }

        // Propiedad pública para acceder y modificar el arreglo 'cantidad'.
        public string[] Cantidad 
        { 
            get => cantidad; 
            set => cantidad = value; 
        }

        // Propiedad pública para acceder y modificar el arreglo 'nombre'.
        public string[] Nombre 
        { 
            get => nombre; 
            set => nombre = value; 
        }
    }
}
