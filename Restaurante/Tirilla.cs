using System;
using System.Text;
using sistemarestaurante;

namespace sistemarestaurante
{
    // Clase que genera la tirilla de una mesa específica
    public class GenerarTirilla
    {
        // Constantes para formatear la tirilla
        private const float PORCENTAJE_PROPINA = 0.1f; // 10% de propina sugerida
        private const float DESCUENTO_CUMPLEANOS = 0.1f; // 10% de descuento por cumpleaños

        // Método para generar e imprimir la tirilla de una mesa
        public void ImprimirTirilla(Factura factura, bool esCumpleanosCliente, float montoPagado)
        {
            StringBuilder tirilla = new StringBuilder();
            
            // Encabezado de la tirilla
            tirilla.AppendLine("================================");
            tirilla.AppendLine($"     {Constante.NOMBRE_NEGOCIO}");
            tirilla.AppendLine("================================");
            tirilla.AppendLine($"Fecha: {factura.Fecha}");
            tirilla.AppendLine("================================");
            tirilla.AppendLine("Producto       Cantidad  Precio U.  Total");
            tirilla.AppendLine("--------------------------------");

            float subtotal = 0f;

            // Detalle de los productos en la tirilla
            foreach (var producto in factura.Productos)
            {
                string nombre = producto.Nombre.Length > Constante.CANTIDAD_CARACTERES_NOMBRE_PRODUCTO 
                    ? producto.Nombre.Substring(0, Constante.CANTIDAD_CARACTERES_NOMBRE_PRODUCTO) 
                    : producto.Nombre;

                float totalProducto = decimal.Parse(producto.Cantidad) * decimal.Parse(producto.Precio);
                
                subtotal += totalProducto;

                tirilla.AppendLine($"{nombre,-15} {producto.Cantidad,8} {producto.Precio,10:C} {totalProducto,10:C}");
            }

            // Calcular descuentos e impuestos
            float descuento = esCumpleanosCliente ? subtotal * DESCUENTO_CUMPLEANOS : 0;
            float impuestos = subtotal * Constante.IMPUESTO;
            float propina = subtotal * PORCENTAJE_PROPINA;
            float total = subtotal - descuento + impuestos + propina;

            // Detalle de precios, descuentos, impuestos y total
            tirilla.AppendLine("--------------------------------");
            tirilla.AppendLine($"Subtotal:        {subtotal,20:C}");
            tirilla.AppendLine($"Descuento:       -{descuento,20:C}");
            tirilla.AppendLine($"Impuesto ({Constante.IMPUESTO * 100}%): {impuestos,14:C}");
            tirilla.AppendLine($"Propina Sugerida: {propina,14:C}");
            tirilla.AppendLine("--------------------------------");
            tirilla.AppendLine($"Total:           {total,20:C}");

            // Información de pago
            tirilla.AppendLine("================================");
            tirilla.AppendLine($"Medio de Pago: {factura.Medio_pago}");
            tirilla.AppendLine($"Monto Pagado:  {montoPagado,20:C}");

            // Calcular devuelta
            float devuelta = montoPagado - total;
            if (devuelta >= 0)
            {
                tirilla.AppendLine($"Devuelta:       {devuelta,20:C}");
            }
            else
            {
                tirilla.AppendLine($"Monto Adeudado: {-devuelta,20:C}");
            }

            // Pie de la tirilla
            tirilla.AppendLine("================================");
            tirilla.AppendLine("   Gracias por su visita!");
            tirilla.AppendLine("================================");

            // Imprimir la tirilla en consola (o podría redirigirse a una impresora o archivo)
            Console.WriteLine(tirilla.ToString());
        }
    }
}