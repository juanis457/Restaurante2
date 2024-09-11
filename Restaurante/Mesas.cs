using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    internal class Mesas
    {
        private int mesasdisponibles;
        private string producto;
        private int mesaatendida;

        public int Mesasdispo { get => mesasdisponibles; set => mesasdisponibles = value; }
        public string Producto { get => producto; set => producto = value; }
        public int Mesaatendida { get => mesaatendida; set => mesaatendida = value; }
        public Mesas( byte Mesa, byte cantidadmesa) 
        {    
            
            this.mesaatendida = Mesa;
            this.mesasdisponibles = cantidadmesa;
            this.producto = string.Empty; //porque puede ser nulo
    
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Número de mesas disponibles: {Mesasdispo}");
            Console.WriteLine($"Número de mesa seleccionada: {Mesaatendida}");
        }


    }
}
