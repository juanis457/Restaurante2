using System;
using System.IO; // Agregamos la biblioteca necesaria para manejar archivos
using sistemarestaurante; // Asumimos que este espacio de nombres contiene la clase Factura y otros elementos necesarios

namespace Restaurante
{
    public class IODatos
    {
        // Constante para organizar los CSV por comas
        public const char ORGANIZAR_CSV = ',';

        // Método para cargar facturas desde un archivo CSV
        public Factura[] CargarFacturasCSV()
        {
            Factura[] facturas = null; // Inicializamos el array de facturas como null

            try
            {
                // Leemos todas las líneas del archivo CSV
                string[] lineas = File.ReadAllLines(@"../../archivo/facturas.csv");
                Console.WriteLine("Estamos cargando facturas desde CSV");
                
                // Si el archivo no tiene líneas, lanzamos una excepción
                if (lineas.Length == 0)
                {
                    throw new Exception("El archivo CSV está vacío.");
                }

                // Procesamos las líneas y creamos las facturas
                facturas = ProcesarLineas(lineas);
            }
            catch (FileNotFoundException ex)
            {
                // Manejo específico si el archivo no existe
                Console.WriteLine("Archivo de facturas no encontrado: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                Console.WriteLine("Error al cargar el archivo de facturas: " + ex.Message);
            }

            return facturas;
        }

        // Método para procesar las líneas del archivo CSV y convertirlas en facturas
        public Factura[] ProcesarLineas(string[] lineas)
        {
            // Creamos el array de facturas basado en la cantidad de líneas del archivo
            Factura[] facturas = new Factura[lineas.Length - 1]; // -1 para evitar el encabezado

            for (int i = 1; i < lineas.Length; i++) // Comenzamos en 1 para saltar el encabezado
            {
                string[] temp = lineas[i].Split(ORGANIZAR_CSV); // Dividimos la línea en columnas

                Factura factura = new Factura(); // Creamos una nueva factura

                factura.Fecha = temp[0]; // Asignamos la fecha

                string[] nombres = temp[1].Split('-'); // Dividimos los nombres de productos
                string[] precios = temp[2].Split('#'); // Dividimos los precios de productos

                factura.AgregarProductos(nombres, precios); // Asumimos que este método existe para agregar productos

                factura.Medio_pago = temp[3]; // Asignamos el medio de pago
                factura.EstadoActual = int.Parse(temp[4]); // Convertimos el estado a entero
                factura.Numero_factura = int.Parse(temp[5]); // Corregido el nombre de la propiedad

                facturas[i - 1] = factura; // Asignamos la factura al array
            }

            return facturas;
        }
    }

    // Método agregado como suposición para la clase Factura, ya que no estaba incluido en el código original
    public class Factura
    {
        public string Fecha { get; set; }
        public string Medio_pago { get; set; }
        public int EstadoActual { get; set; }
        public int Numero_factura { get; set; }

        // Método para agregar productos a la factura
        public void AgregarProductos(string[] nombres, string[] precios)
        {
            // Aquí podrías implementar la lógica para agregar productos a la factura
            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine($"Producto: {nombres[i]}, Precio: {precios[i]}");
            }
        }
    }
}
