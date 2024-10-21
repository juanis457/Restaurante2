using System;
using System.Collections.Generic;
using System.Linq;

namespace sistemarestaurante
{
    public class Estado
    {
        private Inventario inventario;
        private List<Mesa> mesas;

        // Constructor para inicializar el estado con el inventario y las mesas
        public Estado(Inventario inventario, List<Mesa> mesas)
        {
            this.inventario = inventario;
            this.mesas = mesas;
        }

        // Método para imprimir el estado actual del inventario
        public void ImprimirEstadoInventario()
        {
            Console.Clear();
            foreach (var producto in inventario.Productos)
            {
                Console.WriteLine($"Producto: {producto.Nombre,-15} | Cantidad: {producto.Cantidad,-5} | Precio: {producto.Precio,6:C}");
            }

            Console.WriteLine();
        }

        // Método para imprimir el estado del pedido actual de una mesa específica
        public void ImprimirEstadoMesa(int numeroMesa)
        {
            Console.Clear();
            Mesa mesa = mesas.FirstOrDefault(m => m.NumeroMesa == numeroMesa);

            if (mesa == null)
            {
                Console.WriteLine($"La mesa #{numeroMesa} no existe.");
                return;
            }
            if (!mesa.EstaOcupada)
            {
                Console.WriteLine($"La mesa #{numeroMesa} está libre.");
                return;
            }
            Console.WriteLine($"Estado del Pedido - Mesa #{numeroMesa}");
        
            float totalPedido = 0f;
            var pedidoLista = mesa.Pedido.ToList(); // Asegúrate de que `mesa.Pedido` se pueda convertir a una lista.

            for (int i = 0; i < pedidoLista.Count; i++) // Acceder a la propiedad Count
{
    var producto = pedidoLista[i]; // Acceder al elemento por índice
                Console.WriteLine($"Producto: {producto.Nombre,-15} | Cantidad: {producto.Cantidad,-5} | Precio Unitario: {producto.Precio,6:C} | Total: {(producto.Cantidad * producto.Precio),8:C}");
                totalPedido += (float)producto.Cantidad * (float)producto.Precio;
            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Total del Pedido: {totalPedido,35:C}");
            Console.WriteLine();
        }

        // Método para imprimir el estado completo de inventario, pedido de la mesa y cuenta
        public void ImprimirEstadoCompleto(int numeroMesa)
        {
            // Estado del Inventario
            ImprimirEstadoInventario();

            // Estado de la Mesa
            Mesa mesa = mesas.FirstOrDefault(m => m.NumeroMesa == numeroMesa);

            if (mesa == null)
            {
                Console.WriteLine($"La mesa #{numeroMesa} no existe.");
                return;
            }

            if (!mesa.EstaOcupada)
            {
                Console.WriteLine($"La mesa #{numeroMesa} está libre.");
                return;
            }
            ImprimirEstadoMesa(numeroMesa);

            // Estado de la Cuenta de la Mesa
            Mesa mesa = mesas.FirstOrDefault(m => m.NumeroMesa == numeroMesa);
            GenerarTirilla generarTirilla = new GenerarTirilla();
            Console.WriteLine("Tirilla de la Cuenta:");
            generarTirilla.ImprimirTirilla(mesa.factura, false, (float)mesa.factura.CalcularTotal());
        }

        // Método para actualizar el estado del inventario después de realizar una venta
        public void ActualizarInventario(List<Producto> productosVendidos)
        {
            foreach (var producto in productosVendidos)
            {
                var productoInventario = inventario.Productos.FirstOrDefault(p => p.Nombre == producto.Nombre);
                if (productoInventario != null)
                {
                    if (productoInventario.Cantidad < producto.Cantidad)
                    {
                        Console.WriteLine($"No hay suficiente inventario para el producto {producto.Nombre}. Venta no procesada.");
                        continue; // O maneja este caso según las reglas de negocio
                    }
                    productoInventario.Cantidad -= producto.Cantidad;
                    if (productoInventario.Cantidad < 0) productoInventario.Cantidad = 0; // Evitar cantidades negativas
                }
            }
            Console.WriteLine("Inventario actualizado después de la venta.");
        }
    }
}