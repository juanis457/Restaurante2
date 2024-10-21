using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{

    // Clase Producto que almacena información de diferentes productos disponibles en el restaurante
    public class Producto
    {
        // Arreglo unidimensional 'precio' que almacena el precio de 12 productos diferentes.


    public string Nombre { get; set; }
    public float Precio { get; set; }
    public int Cantidad { get; set; }


        public Producto(string nombre, float precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        
        
    }
}
