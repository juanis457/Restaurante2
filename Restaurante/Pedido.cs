using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    internal class Pedido
    {
        // Arreglo bidimensional 'pedidos' para almacenar la información de hasta 10 pedidos
        // Cada fila representa un pedido, y las tres columnas pueden representar atributos como:
        // 1) Nombre del producto, 2) Cantidad del producto, 3) Precio del producto.
        private string[,] pedidos = new string[10, 3];

        // Propiedad pública para acceder o modificar el arreglo 'pedidos'
        // 'get' devuelve el valor actual del arreglo 'pedidos'
        // 'set' permite asignar un nuevo valor al arreglo 'pedidos'
        public string[,] Pedidos { get => pedidos; set => pedidos = value; }
    }
}

