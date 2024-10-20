using System;

using System.IO;
using System;

namespace sistemarestaurante
{
    // Clase Inventario que maneja los productos del restaurante
    public class Inventario
    {
    public List<Producto> Productos { get; set; }

    public void CrearInventario()
    {
        Productos = new List<Producto>
        {
            new Producto ("Sushi",10000,10 ),
            new Producto ("Ramen", 20000, 10 ),
            new Producto ("Filete", 5000, 20 ),
            new Producto ("Pollo", 20000, 29 ),
            new Producto ("Papas Francesas", 7000, 16 ),
            new Producto ("Ensalada Cesar", 10000, 14 ),
            new Producto ("Gaseosa", 2000, 7 ),
            new Producto ("Jugo natural", 5000, 33 ),
            new Producto ("Helado", 3000, 22 ),
            new Producto ("Pizza", 8000, 60 ),
            new Producto ("Bandeja paisa", 20000, 30 ),
            new Producto ("Langostinos", 25000, 10 )
        };
    
    
        
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


                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] datosProducto = lineas[i].Split(',');
                    new Producto(datosProducto[0],float.Parse(datosProducto[1]),int.Parse(datosProducto[2]));
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
                    for (int i = 0; i < Productos.Count; i++)
                    {
                        string linea = $"{Productos[i].Nombre},{Productos[i].Precio},{Productos[i].Cantidad}";
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
            for (int i = 0; i < Productos.Count; i++)
            {
                Console.WriteLine($"{Productos[i].Nombre} - Precio: {Productos[i].Precio} - Cantidad: {Productos[i].Cantidad}");
            }
        }

        // Método para actualizar el inventario después de una venta
        public void ActualizarInventario(string nombre, int cantidadVendida)
        {
            int index = Array.IndexOf(Productos.Nombre, nombre);
            if (index != -1)
            {
                int cantidadActual = int.Parse(Productos.Cantidad[index]);
                if (cantidadActual >= cantidadVendida)
                {
                    Productos.cantidad[index] = (cantidadActual - cantidadVendida).ToString();
                    Console.WriteLine($"Se actualizó la cantidad de {nombre} a {Productos.Cantidad[index]}.");
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
