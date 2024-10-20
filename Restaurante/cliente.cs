using System;
using System.Collections.Generic;
using System.IO;

namespace sistemarestaurante
{
    // Clase que representa un cliente del restaurante
    internal class Cliente
    {
        // Atributos de la clase Cliente
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Factura> HistorialFacturas { get; set; }
        public Factura []Facturas;

        public EstadoFactura EstadoFactura;

        public int LimiteCredito= 1000000;

        // Constructor de la clase Cliente
        public Cliente(string nombre, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            HistorialFacturas = new List<Factura>();
        }

        // Método para agregar una factura al historial del cliente
        public void AgregarFactura(Factura factura)
        {
            HistorialFacturas.Add(factura);
        }

        // Método para verificar si el cliente cumple años en el mes actual
        public bool EsCumpleanos()
        {
            return FechaNacimiento.Month == DateTime.Now.Month;
        }

        // Método estático para cargar clientes desde un archivo CSV
        public static List<Cliente> CargarClientesDesdeArchivo(string rutaArchivo)
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                // Leer todas las líneas del archivo
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    string nombre = datos[0];
                    DateTime fechaNacimiento = DateTime.Parse(datos[1]);

                    Cliente cliente = new Cliente(nombre, fechaNacimiento);

                    // Procesar historial de facturas del cliente (suponiendo que esté separado por ";")
                    for (int i = 2; i < datos.Length; i++)
                    {
                        string[] infoFactura = datos[i].Split(';');
                        Factura factura = new Factura
                        {
                            fecha = infoFactura[0],
                            medio_pago = infoFactura[1],
                            estadoActual = (infoFactura[2]),
                            numero_factura = int.Parse(infoFactura[3])
                        };
                        cliente.AgregarFactura(factura);
                    }

                    clientes.Add(cliente);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Archivo de clientes no encontrado: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar el archivo de clientes: " + ex.Message);
            }

            return clientes;
        }

        // Método para dar descuento a clientes que cumplen años en el mes
        public static void AplicarDescuentoCumpleanos(List<Cliente> clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.EsCumpleanos())
                {
                    Console.WriteLine($"¡Feliz cumpleaños, {cliente.Nombre}! Recibes un descuento en tu próxima compra.");
                    // Implementar lógica para aplicar el descuento
                }
            }
        }
        public decimal ObtenerTotalDeuda()
    {
        return Facturas.Where(f => f.estadoActual == EstadoFactura.Pendiente).Sum(f => f.CalcularTotal() - f.MontoPagado);
    }

    public bool AbonarCuenta(int numeroFactura, decimal monto)
    {
        var factura = Facturas.FirstOrDefault(f => f.Numero_factura == numeroFactura && f.estadoActual == EstadoFactura.Pendiente);
        if (factura != null)
        {
            if (monto <= ObtenerTotalDeuda() && monto <= LimiteCredito)
            {
                factura.PagarParcialmente(monto);
                if (factura.CalcularTotal() - factura.MontoPagado <= 0)
                {
                    factura.estadoActual = EstadoFactura.Pagada;
                }
                return true;
            }
        }
        return false;
    }
    }
    public enum EstadoFactura
{
    Pendiente = 1,
    Pagada = 2,
    Cancelada = 3
}
}