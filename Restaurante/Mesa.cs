using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemarestaurante
{
    public class Mesa
    {
        // Variables privadas para almacenar la información de las mesas
        private int mesasdisponibles; // Almacena la cantidad de mesas disponibles en el restaurante
        private string producto; // Almacena el nombre del producto asignado a la mesa
        private int mesaatendida; // Almacena el número de la mesa que está siendo atendida

        // Propiedades públicas para acceder y modificar las variables privadas
        public int Mesasdispo { get => mesasdisponibles; set => mesasdisponibles = value; }
        public string Producto { get => producto; set => producto = value; }
        public int Mesaatendida { get => mesaatendida; set => mesaatendida = value; }

        public int NumeroMesa;

        public bool EstaOcupada;

        public List<Producto> Pedido;

        public Factura factura { get ; set ;}

        // Constructor de la clase Mesa
        // Recibe dos parámetros: 'Mesa' que representa el número de mesa atendida, y 'cantidadmesa' que representa la cantidad de mesas disponibles
        public Mesa(byte Mesa, byte cantidadmesa) 
        {    
            // Asignamos el número de la mesa atendida al campo correspondiente
            mesaatendida = Mesa;

            // Asignamos la cantidad de mesas disponibles
            mesasdisponibles = cantidadmesa;

            // Inicializamos la variable 'producto' como una cadena vacía ya que no tiene producto asignado inicialmente
            producto = string.Empty; 
            
            factura=null;
        }

        // Método para mostrar los datos de la mesa en la consola
        public void MostrarDatos()
        {
            // Muestra la cantidad de mesas disponibles
            Console.WriteLine($"Número de mesas disponibles: {Mesasdispo}");
            
            // Muestra el número de la mesa que está siendo atendida
            Console.WriteLine($"Número de mesa seleccionada: {Mesaatendida}"); //! REVISAR !!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
}
