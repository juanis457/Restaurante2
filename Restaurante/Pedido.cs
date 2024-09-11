using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    internal class pedidos
    {
        private string[,] pedidos = new string[10,3];

        public string[,] Pedidos { get => pedidos; set => pedidos = value; }

        
    }
}
