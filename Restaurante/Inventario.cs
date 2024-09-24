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

      
    }
}