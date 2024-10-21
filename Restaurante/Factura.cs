using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    internal class Factura
    {
        
        // Atributos privados de la clase Factura
        public string fecha { get; set; } // Almacena la fecha de la factura      
        public string medio_pago { get; set; } // Almacena el medio de pago (efectivo, tarjeta, etc.)
        private float iva = Constante.IMPUESTO;  // IVA, que se inicializa con un valor constante
        private float total;  // Total de la factura antes de impuestos           
        public int numero_factura { get; set; }  // Número de la factura
        private int mesa;  // Número de la mesa en el restaurante
        private string[,] pedido;  // Arreglo bidimensional que almacena detalles de los pedidos (nombre, cantidad, precio)

        public EstadoFactura estadoActual { get; set; }
        private List<Producto> Productos = new List<Producto>(); 
        private string[] precio;  // Atributo para almacenar los precios individuales
        
        // Arreglo que almacenará la factura final con todos los datos organizados (17 filas, 3 columnas)
        string[,] factura = new string[17, 3]; 

        public decimal MontoPagado;
        public int Subtotal;
        public int Impuestos;
        public int Descuento;

        public int cantidad;

        // Constructor que inicializa los atributos de la clase con los parámetros recibidos
        public Factura(string fecha, string medio_pago, float total, int numero_factura, int mesa, string[,] pedido, string[] precios, EstadoFactura estadoActual)
        {
            this.fecha = fecha;
            this.medio_pago = medio_pago;            
            this.total = total;            
            this.numero_factura = numero_factura;
            this.mesa = mesa;
            this.pedido = pedido;
            
            /*List<Producto> Productos = new List<Producto>(); */
        }





    // Método para agregar productos a la factura, se le añade parámetro para aplicar descuento
    public void AgregarProductos(string[] nombres, string[] precios, bool aplicarDescuento = false)
    {
        for (int i = 0; i < nombres.Length; i++)
        {
            float precio = float.Parse(precios[i]);
            if (aplicarDescuento)
            {
                // Aplicar un 10% de descuento como ejemplo
                precio = precio * 0.9f;
            }
            
            Producto producto = new Producto(nombres[i], precio, cantidad);
            Productos.Add(producto);
            
            Console.WriteLine($"Producto: {nombres[i]}, Precio: {precio}");
        }
    }

        // Propiedades públicas para acceder y modificar los atributos privados
        public string Fecha { get => fecha; set => fecha = value; }
        public string Medio_pago { get => medio_pago; set => medio_pago = value; }
        public float Total { get => total; set => total = value; }
        public int Numero_factura { get => numero_factura; set => numero_factura = value; }
        public int Mesa { get => mesa; set => mesa = value; }
        public string[,] Pedido { get => pedido; set => pedido = value; }
        
        // Método que organiza los datos de la factura en el arreglo bidimensional 'factura'
        public void Organizardatos()
        {
            for (int i = 0; i < 16; i++)  // Se recorre un máximo de 16 filas
            {
                for (int j = 0; j < 3; j++)  // Cada fila tiene 3 columnas
                {
                    if (j == 0 && i < 10)  // Columna 0: se asigna el nombre del pedido
                    {
                        factura[i, j] = Pedido[i, 0];
                    }
                    else if (j == 1 && i < 10)  // Columna 1: se asigna la cantidad del pedido
                    { 
                        factura[i, j] = pedido[i, 1];
                    }
                    else if (j == 2 && i < 10)  // Columna 2: se asigna el precio del pedido
                    {
                        factura[i, j] = pedido[i, 2];
                    }                    
                }

                // Para las últimas filas (10-16), se asignan los datos adicionales de la factura
                if (i >= 10 && i < 17)
                {
                    if (i == 10)
                    {
                        factura[i, 0] = "fecha";  // Asigna el texto "fecha"
                        factura[i, 1] = fecha;  // Asigna el valor de la fecha
                    }
                    else if (i == 11)
                    {
                        factura[i, 0] = "medio-pago";  // Asigna el texto "medio-pago"
                        factura[i, 1] = medio_pago;  // Asigna el valor del medio de pago
                    }
                    else if (i == 12)
                    {
                        factura[i, 0] = "iva";  // Asigna el texto "iva"
                        factura[i, 1] = Convert.ToString(iva);  // Convierte el valor del IVA a string y lo asigna
                    }
                    else if (i == 13)
                    {
                        factura[i, 0] = "subtotal";  // Asigna el texto "subtotal"
                        factura[i, 1] = Convert.ToString(total);  // Convierte el subtotal a string y lo asigna
                    }
                    else if (i == 14)
                    {
                        factura[i, 0] = "numero-factura";  // Asigna el texto "numero-factura"
                        factura[i, 1] = Convert.ToString(numero_factura);  // Asigna el número de factura
                    }
                    else if (i == 15)
                    {
                        factura[i, 0] = "mesa";  // Asigna el texto "mesa"
                        factura[i, 1] = Convert.ToString(mesa);  // Asigna el número de la mesa
                    }
                    else if (i == 16)
                    {
                        factura[i, 0] = "Total";  // Asigna el texto "Total"
                        // Calcula el total con IVA y lo asigna
                        factura[i, 1] = Convert.ToString((total * iva) + total);
                    }
                }
            }
        }

        // Método que genera y muestra la factura en la consola
        public void GenerarFactura()
        {
            // Imprime un encabezado artístico de "FACTURA"
            Console.WriteLine("F F F F F   A A A     C C C     T T T T    U     U  R R R R    A A A  ");
            Console.WriteLine("F          A     A   C             T       U     U  R     R   A     A ");
            Console.WriteLine("F F F      A A A A   C             T       U     U  R R R     A A A A ");
            Console.WriteLine("F          A     A   C             T       U     U  R   R     A     A ");
            Console.WriteLine("F          A     A    C C C        T         U U    R    R    A     A ");
            
            // Imprime el contenido de la factura
            for (int i = 0; i < 16; i++)  // Recorre las 16 filas de la factura
            {
                for (int j = 0; j < 3; j++)  // Recorre las 3 columnas por cada fila
                {
                    Console.Write(factura[i, j] + "|");  // Imprime cada valor separado por "|"
                }
                Console.WriteLine();  // Salta a la siguiente línea
            }
        }
        public void PagarParcialmente(decimal monto)
        {

        MontoPagado = monto + MontoPagado;

        }

        public decimal CalcularTotal()
        {

        return Subtotal + Impuestos - Descuento;
        }
    }
}
