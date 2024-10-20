using System;
using System.Collections.Generic;
using System.Linq;

namespace sistemarestaurante
{
    public class Estado
    {
        private Inventario inventario;
        private List<Mesa> mesas;

        public InterfazUsuario InterfazUsuario;

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
            //InterfazUsuario.ImprimirTitulo("Estado Actual del Inventario");
            
            foreach (var producto in inventario.productos)
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

            if (mesa != null && mesa.EstaOcupada)
            {
                InterfazUsuario.ImprimirTitulo($"Estado del Pedido - Mesa #{numeroMesa}");
                
                float totalPedido = 0f;
                foreach (var producto in mesa.Pedido)
                {
                    Console.WriteLine($"Producto: {producto.Nombre,-15} | Cantidad: {producto.Cantidad,-5} | Precio Unitario: {producto.Precio,6:C} | Total: {(producto.Cantidad * producto.Precio),8:C}");
                    totalPedido += producto.Cantidad * producto.Precio;
                }

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"Total del Pedido: {totalPedido,35:C}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"La mesa #{numeroMesa} está libre o no existe.");
            }
        }

        // Método para imprimir el estado completo de inventario, pedido de la mesa y cuenta
        public void ImprimirEstadoCompleto(int numeroMesa)
        {
            // Estado del Inventario
            ImprimirEstadoInventario();

            // Estado de la Mesa
            ImprimirEstadoMesa(numeroMesa);

            // Estado de la Cuenta de la Mesa
            if (mesas.Any(m => m.NumeroMesa == numeroMesa && m.EstaOcupada))
            {
                Mesa mesa = mesas.FirstOrDefault(m => m.NumeroMesa == numeroMesa);
                GenerarTirilla generarTirilla = new GenerarTirilla();
                Console.WriteLine("Tirilla de la Cuenta:");
                generarTirilla.ImprimirTirilla(mesa.Factura, false, mesa.Factura.CalcularTotal());
            }
        }

        // Método para actualizar el estado del inventario después de realizar una venta
        public void ActualizarInventario(List<Producto> productosVendidos)
        {
            foreach (var producto in productosVendidos)
            {
                var productoInventario = inventario.Productos.FirstOrDefault(p => p.Nombre == producto.Nombre);
                if (productoInventario != null)
                {
                    productoInventario.Cantidad -= producto.Cantidad;
                    if (productoInventario.Cantidad < 0) productoInventario.Cantidad = 0; // Asegurarse de no tener cantidades negativas
                }
            }
            Console.WriteLine("Inventario actualizado después de la venta.");
        }
    }
}