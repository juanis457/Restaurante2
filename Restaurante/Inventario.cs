using System;

namespace sistemarestaurante
{
    // Clase Inventario que maneja los productos del restaurante
    internal class Inventario
    {
        // Atributo privado que representa una instancia de la clase Producto
        private Producto productos;

        // Constructor de la clase Inventario
        public Inventario()
        {
            productos = new Producto(); // Inicializamos la instancia de Producto al crear un inventario
        }

        // Método para mostrar todos los productos en el inventario
        public void MostrarInventario()
        {
            Console.WriteLine("Inventario de Productos:");
            // Recorre el arreglo de nombres de productos y muestra su nombre, precio y cantidad
            for (int i = 0; i < productos.Nombre.Length; i++)
            {
                Console.WriteLine($"{productos.Nombre[i]} - Precio: {productos.Precio[i]} - Cantidad: {productos.Cantidad[i]}");
            }
        }

        // Método para agregar o actualizar un producto en el inventario
        // Si el producto ya existe, se actualiza su precio y cantidad
        public void AgregarProducto(string nombre, string precio, string cantidad)
        {
            // Busca el índice del producto en el arreglo por su nombre
            int index = Array.IndexOf(productos.Nombre, nombre);

            if (index != -1) // Si el producto existe en el inventario
            {
                productos.Precio[index] = precio; // Actualiza el precio del producto
                productos.Cantidad[index] = cantidad; // Actualiza la cantidad del producto
            }
            else
            {
                // Muestra un mensaje si el producto no existe en el inventario
                Console.WriteLine($"El producto {nombre} no existe en el inventario.");
            }
        }

        // Método para buscar un producto en el inventario por su nombre
        public void BuscarProducto(string nombre)
        {
            // Busca el índice del producto en el arreglo por su nombre
            int index = Array.IndexOf(productos.Nombre, nombre);

            if (index != -1) // Si el producto existe
            {
                // Muestra el producto encontrado con su nombre, precio y cantidad
                Console.WriteLine($"Producto encontrado: {productos.Nombre[index]} - Precio: {productos.Precio[index]} - Cantidad: {productos.Cantidad[index]}");
            }
            else
            {
                // Muestra un mensaje si el producto no existe en el inventario
                Console.WriteLine($"El producto {nombre} no existe en el inventario.");
            }
        }

        // Método para actualizar la cantidad de un producto en el inventario
        public void ActualizarCantidad(string nombre, string nuevaCantidad)
        {
            // Busca el índice del producto en el arreglo por su nombre
            int index = Array.IndexOf(productos.Nombre, nombre);

            if (index != -1) // Si el producto existe
            {
                // Actualiza la cantidad del producto
                productos.Cantidad[index] = nuevaCantidad;
                Console.WriteLine($"Cantidad actualizada para {nombre}: {nuevaCantidad}");
            }
            else
            {
                // Muestra un mensaje si el producto no existe en el inventario
                Console.WriteLine($"El producto {nombre} no existe en el inventario.");
            }
        }
    }
}
