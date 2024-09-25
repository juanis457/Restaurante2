using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    // Clase que contiene constantes utilizadas en el sistema del restaurante
    internal class Constante
    {
        // Nombre del negocio, usado para imprimir encabezados o referencias al nombre del restaurante
        public const string NOMBRE_NEGOCIO = "EL RINCON GOURMET";

        // Mensaje de error que se muestra cuando una factura no se encuentra por su id
        public const string ERROR_AL_BUSCAR_FACTURA = "El id de la factura no existe";

        // Definición del ancho máximo de la tirilla impresa para las facturas
        public const int ANCHO_TIRILLA = 32;

        // Cantidad máxima de caracteres permitidos para el nombre de un producto en la tirilla o factura
        public const int CANTIDAD_CARACTERES_NOMBRE_PRODUCTO = 12;

        // Cantidad máxima de caracteres para mostrar el precio unitario de un producto
        public const int CANTIDAD_CARACTERES_PRECIO_UNITARIO = 5;

        // Cantidad máxima de caracteres para mostrar el subtotal del precio de un producto (cantidad * precio unitario)
        public const int CANTIDAD_CARACTERES_PRECIO_SUBTOTAL = 10;

        // Constante que define el porcentaje de IVA aplicado a los productos
        public const float IMPUESTO = .19F;
    }
}

