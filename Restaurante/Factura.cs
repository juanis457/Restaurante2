using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    internal class Factura
    {
        private string fecha;        
        private string medio_pago;
        private float iva = Constantes.IMPUESTO;
        private float total;             
        private int numero_factura;
        private int mesa;
        private string[,] pedido;
        private string[] precios; //Esta aquí declarada pero no se llega a usar
        string[,] factura = new string[17,3];


        public Factura(string fecha, string medio_pago,  float total, int numero_factura, int mesa, string[,] pedido, string[] precios)
        {
            this.fecha = fecha;
            this.medio_pago = medio_pago;            
            this.total = total;            
            this.numero_factura = numero_factura;
            this.mesa = mesa;
            this.pedido = pedido;
            this.precios = precios; //en caso de que se use es importante ponerla acá
        }

        public string Fecha { get => fecha; set => fecha = value; }
        public string Medio_pago { get => medio_pago; set => medio_pago = value; }
        public float Total { get => total; set => total = value; }
        public int Numero_factura { get => numero_factura; set => numero_factura = value; }
        public int Mesa { get => mesa; set => mesa = value; }
        public string[,] Pedido { get => pedido; set => pedido = value; }
        

        public void Organizardatos()
        {
            for (int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(j == 0 && i < 10)
                    {
                        factura[i,j] = Pedido[i,0];
                    }
                    else if (j == 1 && i < 10)
                    { 
                        factura[i,j] = pedido[i,1];
                    }
                    else if(j == 2 && i < 10)
                    {
                        factura[i,j] = pedido[i,2];
                    }                    
                }
                if (i >= 10 && i < 17)
                {
                    if(i == 10)
                    {
                        factura[i, 0] = "fecha";
                        factura[i, 1] = fecha;
                    }
                    else if(i == 11)
                    {
                        factura[i, 0] = "medio-pago";
                        factura[i, 1] = medio_pago;
                    }
                    else if(i == 12)
                    {
                        factura[i, 0] = "iva";
                        factura[i, 1] = Convert.ToString(iva);
                    }
                    else if (i == 13)
                    {
                        factura[i, 0] = "subtotal";
                        factura[i, 1] = Convert.ToString(total);
                    }
                    else if (i == 14)
                    {
                        factura[i, 0] = "numero-factura";
                        factura[i, 1] = Convert.ToString(numero_factura);
                    }
                    else if (i == 15)
                    {
                        factura[i, 0] = "mesa";
                        factura[i, 1] = Convert.ToString(mesa);
                    }
                    else if(i == 16)
                    {
                        factura[i, 0] = "Total";
                        factura[i, 1] = Convert.ToString(((total)*(iva))+(total));
                    }
                }
            }
        }
        public void GenerarFactura()
        {
            Console.WriteLine("F F F F F   A A A     C C C     T T T T    U     U  R R R R    A A A  ");
            Console.WriteLine("F          A     A   C             T       U     U  R     R   A     A ");
            Console.WriteLine("F F F      A A A A   C             T       U     U  R R R     A A A A ");
            Console.WriteLine("F          A     A   C             T       U     U  R   R     A     A ");
            Console.WriteLine("F          A     A    C C C        T         U U    R    R    A     A ");
            for (int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(factura[i,j] + "|");
                }
                Console.WriteLine();
            }
        }
    }
}
