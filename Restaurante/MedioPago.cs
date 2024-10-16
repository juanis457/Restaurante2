using System;

namespace sistemarestaurante
{
    public abstract class MedioPago
    {
        public decimal Monto { get; set; }
        public string Tipo { get; set; } // Efectivo, Tarjeta de Crédito, Débito, Transferencia
        public string NumeroTransaccion { get; set; }

        // Método para procesar el pago (debe ser implementado por las clases derivadas)
        public abstract bool ProcesarPago();

        // Método para obtener el detalle del pago
        public virtual string ObtenerDetallePago()
        {
            return $"Tipo de Pago: {Tipo}\nMonto: {Monto:C}\nNúmero de Transacción: {NumeroTransaccion}";
        }
    }

    // Clase derivada: Efectivo
    public class Efectivo : MedioPago
    {
        public decimal Cambio { get; set; }

        public Efectivo(decimal monto, decimal montoPagado)
        {
            Tipo = "Efectivo";
            Monto = monto;
            Cambio = montoPagado - monto;
            NumeroTransaccion = Guid.NewGuid().ToString(); // Generar un ID de transacción único
        }

        // Método para calcular el cambio
        public decimal CalcularCambio()
        {
            return Cambio;
        }

        public override bool ProcesarPago()
        {
            Console.WriteLine("Pago procesado en efectivo.");
            Console.WriteLine($"Cambio: {Cambio:C}");
            return true;
        }
    }

    // Clase derivada: TarjetaCredito
    public class TarjetaCredito : MedioPago
    {
        public string NumeroTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }

        public TarjetaCredito(string numeroTarjeta, string nombreTitular, string cvv, string fechaExpiracion, decimal monto)
        {
            Tipo = "Tarjeta de Crédito";
            NumeroTarjeta = numeroTarjeta;
            NombreTitular = nombreTitular;
            CVV = cvv;
            FechaExpiracion = fechaExpiracion;
            Monto = monto;
            NumeroTransaccion = Guid.NewGuid().ToString();
        }

        public override bool ProcesarPago()
        {
            // Lógica para autorizar la tarjeta de crédito
            Console.WriteLine("Pago autorizado con tarjeta de crédito.");
            return true;
        }
    }

    // Clase derivada: TarjetaDebito
    public class TarjetaDebito : MedioPago
    {
        public string NumeroTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }

        public TarjetaDebito(string numeroTarjeta, string nombreTitular, string cvv, string fechaExpiracion, decimal monto)
        {
            Tipo = "Tarjeta de Débito";
            NumeroTarjeta = numeroTarjeta;
            NombreTitular = nombreTitular;
            CVV = cvv;
            FechaExpiracion = fechaExpiracion;
            Monto = monto;
            NumeroTransaccion = Guid.NewGuid().ToString();
        }

        public override bool ProcesarPago()
        {
            // Lógica para autorizar la tarjeta de débito
            Console.WriteLine("Pago autorizado con tarjeta de débito.");
            return true;
        }
    }

    // Clase derivada: Transferencia
    public class Transferencia : MedioPago
    {
        public string BancoOrigen { get; set; }
        public string NumeroCuenta { get; set; }

        public Transferencia(string bancoOrigen, string numeroCuenta, decimal monto)
        {
            Tipo = "Transferencia Bancaria";
            BancoOrigen = bancoOrigen;
            NumeroCuenta = numeroCuenta;
            Monto = monto;
            NumeroTransaccion = Guid.NewGuid().ToString();
        }

        public override bool ProcesarPago()
        {
            // Lógica para confirmar la transferencia
            Console.WriteLine("Pago confirmado por transferencia bancaria.");
            return true;
        }
    }
}
