using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    
    internal class Producto
    {
        private string[] precio = new string[10] {"10000", "20000", "5000", "20000", "7000", "10000", "2000", "5000", "3000", "8000"};
        private string[] cantidad = new string[10] { "10", "10", "20", "29", "16", "14", "7", "33", "22", "60"};
        private string[] nombre = new string[10] { "Sushi", "Ramen", "Filete", "Pollo", "Papas Francesas", "Ensalada Cesar", "Gaseosa", 
            "Jugo natural", "Helado", "Pizza"};
        
        public string[] Precio { get => precio; set => precio = value; }
        public string[] Cantidad { get => cantidad; set => cantidad = value; }
        public string[] Nombre { get => nombre; set => nombre = value; }
        

      
    }
}
