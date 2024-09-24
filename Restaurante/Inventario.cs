using System;

namespace sistemarestaurante
{
    internal class Inventario
    {
        private Producto productos;

        public Inventario()
        {
            productos = new Producto(); // Inicializamos la instancia de Producto
        }

        // Método para mostrar el inventario completo
        public void MostrarInventario()
        {
            Console.WriteLine("Inventario de Productos:");
            for (int i = 0; i < productos.Nombre.Length; i++)
            {
                Console.WriteLine($"{productos.Nombre[i]} - Precio: {productos.Precio[i]} - Cantidad: {productos.Cantidad[i]}");
            }
        }
  // Método para agregar un producto modificando sus propiedades
        public void AgregarProducto(string nombre, string precio, string cantidad)
        {
            int index = Array.IndexOf(productos.Nombre, nombre);

            if (index != -1) // Si el producto ya existe
            {
                productos.Precio[index] = precio;
                productos.Cantidad[index] = cantidad;
            }
            else
            {
                Console.WriteLine($"El producto {nombre} no existe en el inventario.");
            }
        }

      
      
    }
}