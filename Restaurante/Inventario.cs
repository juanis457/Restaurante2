using System;

using System.IO;
using System;

namespace sistemarestaurante
{
    // Clase Inventario que maneja los productos del restaurante
    internal class Inventario
    {
        // Atributo privado que representa una instancia de la clase Producto
        private List<Producto> productos;

        // Constructor de la clase Inventario
        public Inventario()
        {
            productos = new List<Producto> (); // Inicializamos la instancia de Producto al crear un inventario
            CargarInventarioDesdeArchivo(); // Carga el inventario automáticamente al iniciar
        }

        // Método para cargar el inventario desde un archivo CSV
       public void CargarInventarioDesdeArchivo()
{
    try
    {
        // Leer todas las líneas del archivo CSV
        string[] lineas = File.ReadAllLines(@"../../archivo/inventario.csv");

        // Procesar las líneas para llenar el inventario
        foreach (string linea in lineas)
        {
            string[] datosProducto = linea.Split(',');

            // Crear un nuevo producto y agregarlo a la lista
            Producto nuevoProducto = new Producto
            {
                Nombre = datosProducto[0],
                Precio = datosProducto[1],
                Cantidad = datosProducto[2]
            };
            productos.Add(nuevoProducto); // Agregar a la lista de productos
        }

        Console.WriteLine("Inventario cargado exitosamente.");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("El archivo de inventario no se encontró.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al cargar el inventario: " + ex.Message);
    }
}


        // Método para guardar el inventario en el archivo CSV
        public void GuardarInventarioEnArchivo()
{
    try
    {
        using (StreamWriter sw = new StreamWriter(@"../../archivo/inventario.csv"))
        {
            foreach (var producto in productos)
            {
                string linea = $"{producto.Nombre},{producto.Precio},{producto.Cantidad}";
                sw.WriteLine(linea);
            }
        }
        Console.WriteLine("Inventario guardado exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al guardar el inventario: " + ex.Message);
    }
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

        // Método para actualizar el inventario después de una venta
        public void ActualizarInventario(string nombre, int cantidadVendida)
        {
            int index = Array.IndexOf(productos.Nombre, nombre);
            if (index != -1)
            {
                int cantidadActual = int.Parse(productos.Cantidad[index]);
                if (cantidadActual >= cantidadVendida)
                {
                    productos.Cantidad[index] = (cantidadActual - cantidadVendida).ToString();
                    Console.WriteLine($"Se actualizó la cantidad de {nombre} a {productos.Cantidad[index]}.");
                }
                else
                {
                    Console.WriteLine("No hay suficiente cantidad en el inventario para esta venta.");
                }
            }
            else
            {
                Console.WriteLine($"El producto {nombre} no existe en el inventario.");
            }
        }

        // Otros métodos de la clase...
    }
}
