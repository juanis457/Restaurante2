using System;

namespace sistemarestaurante
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            byte num = 0; // Número de mesas
            byte id = 0; // ID de la mesa seleccionada
            string[,] carta;// Menú de productos
            carta = new string[10, 3]; // Control para mostrar el menú
            bool mostrar = false; // Control para mostrar el menú
            string[,] compramesa = new string[10, 3]; // Productos comprados
            Mesa[] numeroMesa = null; // Array de mesas
            Mesa administrarmesa; // Mesa administrada           
            Producto producto;
            producto = new Producto();
            Pedido pedido;
            pedido = new Pedido();
            Factura factura;
            Constante constante = new Constante();


            Saludo();// Mostrar saludo inicial
            Console.Clear();// Limpiar la consola
            Menu(); // Mostrar menú principal
// Método que muestra un saludo en formato de texto
void Saludo()
{
    // Muestra un diseño textual de la palabra "BIENVENIDO" en la consola
    Console.WriteLine("BBBB   IIIII  EEEEE  N   N  V   V  EEEEE  N   N  IIIII  DDDD    OOO ");
    Console.WriteLine("B   B    I    E      NN  N  V   V  E      NN  N    I    D   D  O   O");
    Console.WriteLine("BBBB     I    EEEE   N N N  V   V  EEEE   N N N    I    D   D  O   O");
    Console.WriteLine("B   B    I    E      N  NN   V V   E      N  NN    I    D   D  O   O");
    Console.WriteLine("BBBB   IIIII  EEEEE  N   N    V    EEEEE  N   N  IIIII  DDDD    OOO ");

    // Línea en blanco para separar
    Console.WriteLine(" ");
    // Muestra un mensaje de bienvenida y una instrucción al usuario
    Console.WriteLine("Sea Bienvenido al Rincón gourmet, donde encontrará gran variedad de preparaciones que deleitarán su paladar.");
    Console.WriteLine("Oprima cualquier tecla para continuar");
    // Espera a que el usuario presione una tecla para continuar
    Console.ReadKey();
}

// Método que muestra un menú principal
void Menu()
{
    // Limpia la consola
    Console.Clear();
    bool confirmar = true; // Variable de control para mantener el ciclo del menú
    do
    {
        // Muestra un diseño textual en la consola
        Console.WriteLine(" **    **  *******  **    **  **    ** ");
        Console.WriteLine(" ***  ***  **       ***   **  **    ** ");
        Console.WriteLine(" ** ** **  *****    ** ** **  **    ** ");
        Console.WriteLine(" **    **  **       **  ****  **    ** ");
        Console.WriteLine(" **    **  *******  **   ***   ******  ");
        Console.WriteLine();
        // Opciones del menú
        Console.WriteLine("1.Configurar programa");
        Console.WriteLine("2.Registrar pedido y factura");
        Console.WriteLine("3.Salir");

        byte opcion; // Variable para almacenar la opción seleccionada por el usuario
        do
        {
            // Solicita al usuario seleccionar una opción del menú
            Console.WriteLine("Seleccione una opción del menu");
        } while (!byte.TryParse(Console.ReadLine(), out opcion)); // Valida que la entrada sea un byte

        // Ejecuta la acción correspondiente según la opción seleccionada
        switch (opcion)
        {
            case 1: Configurar(); confirmar = false; break; // Configura el programa
            case 2: RegistrarPedido(); confirmar = false; break; // Registra pedido y factura
            case 3: confirmar = false; break; // Salir del menú
            default:
                // Si la opción no es válida, muestra un mensaje y espera una tecla antes de limpiar la pantalla
                Console.WriteLine("Ingrese una opción valida");
                Console.WriteLine("Oprima cualquier tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    } while (confirmar); // Repite el ciclo mientras confirmar sea verdadero
}

// Método para configurar el programa
void Configurar()
{
    // Limpia la consola
    Console.Clear();
    bool confirmar = true; // Variable de control para mantener el ciclo de configuración
    do
    {
        // Muestra un diseño textual en la consola
        Console.WriteLine(" **    **  *******  **    **  **    ** ");
        Console.WriteLine(" ***  ***  **       ***   **  **    ** ");
        Console.WriteLine(" ** ** **  *****    ** ** **  **    ** ");
        Console.WriteLine(" **    **  **       **  ****  **    ** ");
        Console.WriteLine(" **    **  *******  **   ***   ******  ");
        Console.WriteLine();
        // Opciones del menú de configuración
        Console.WriteLine("1.Ingresar numero de mesas");
        Console.WriteLine("2.Ingresar producto");
        Console.WriteLine("3.Salir");

        byte opcion; // Variable para almacenar la opción seleccionada por el usuario
        do
        {
            // Solicita al usuario seleccionar una opción del menú
            Console.WriteLine("Seleccione una opción del menu");
        } while (!byte.TryParse(Console.ReadLine(), out opcion)); // Valida que la entrada sea un byte

        // Ejecuta la acción correspondiente según la opción seleccionada
        switch (opcion)
        {
            case 1:
                // Limpia la consola y solicita ingresar el número de mesas disponibles
                Console.Clear();
                do
                {
                    Console.WriteLine("Ingrese el numero de mesas disponibles");
                } while (!byte.TryParse(Console.ReadLine(), out num)); // Valida que la entrada sea un byte

                // Inicializa el arreglo de mesas según el número ingresado
                numeroMesa = new Mesa[num];
                confirmar = false; // Sale del ciclo
                Menu(); // Vuelve al menú principal
                break;
            case 2:
                confirmar = false;
                Carta(); // Llama al método Carta para ingresar productos
                break;
            case 3:
                Menu();  // Vuelve al menú principal
                confirmar = false;
                break;
            default:
                // Si la opción no es válida, muestra un mensaje y espera una tecla antes de limpiar la pantalla
                Console.WriteLine("Ingrese una opción valida");
                Console.WriteLine("Oprima una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    } while (confirmar); // Repite el ciclo mientras confirmar sea verdadero
}

// Método para registrar el pedido y generar la factura
void RegistrarPedido()
{
    // Verifica si las mesas han sido configuradas
    if(numeroMesa == null) {
        Console.WriteLine("Porfavor ingrese primero las mesas que hay disponibles en la sección de \"Ingresar número de mesas\"");
        Console.WriteLine("Oprima una tecla para continuar");
        Console.ReadKey();
        Menu(); // Vuelve al menú principal
    }

    Console.WriteLine(numeroMesa.Length); // Muestra el número de mesas disponibles
    Console.WriteLine("Seleccionar la mesa que se esta atendiendo");
    ImprimirMesas(); // Muestra las mesas disponibles para que el usuario elija

    // Verifica si hay productos registrados
    if (pedido.Pedidos[0,0] == null)
    {
        Console.WriteLine("Por favor ingrese primero los productos que desea comprar");
        Console.WriteLine("Oprima cualquier tecla para continuar");
        Console.ReadKey();
        Configurar(); // Llama al método Configurar para ingresar productos
    }

    // Solicita al usuario la fecha de hoy y el medio de pago
    Console.WriteLine("Ingrese la fecha de hoy");
    string fecha = Console.ReadLine();
    Console.WriteLine("Ingrese el medio de pago");
    string mediopago = Console.ReadLine();

    int subtotal;
    int total = 0; // Inicializa el total a 0

    // Calcula el total del pedido basado en los productos y cantidades
    for (int i = 0; i < 10; i++)
    {
        subtotal = 0;
        for (int j = 0; j < 10; j++)
        {
            if (pedido.Pedidos[i,0] != null)
            {
                if (pedido.Pedidos[i, 0].ToLower() == carta[j, 0].ToLower())
                {
                    Console.WriteLine("Calculando...");
                    subtotal = Convert.ToInt16(pedido.Pedidos[i, 2]) * Convert.ToInt16(carta[j, 1]); // Multiplica cantidad por precio
                    total += subtotal; // Acumula el total
                }
            }
        }
    }

    Console.WriteLine(total); // Muestra el total calculado

    int numfactura;
    do
    {
        // Solicita ingresar el número de factura
        Console.WriteLine("Ingrese el numero de factura");
    } while (!int.TryParse(Console.ReadLine(), out numfactura)); // Valida que la entrada sea un número entero
  // El método TryParse se utiliza para intentar convertir una cadena de texto en un tipo de dato específico, 
  //como int, byte, double, entre otros, de manera segura y sin lanzar una excepción si la conversión falla
    // Crea un arreglo de precios basado en los productos de la carta
    string[] precio = new string[10];
    for (int i = 0; i < 10; i++)
    {
        precio[i] = carta[i, 2];
    }

    // Crea un objeto Factura y organiza los datos, luego genera la factura
    factura = new Factura(fecha, mediopago, total, numfactura, id, pedido.Pedidos, precio);
    factura.Organizardatos();
    factura.GenerarFactura();

    Console.WriteLine("Oprima cualquier tecla para continuar");
    Console.ReadKey();
    Menu(); // Vuelve al menú principal
}

// Método para imprimir las mesas disponibles
void ImprimirMesas()
{
    bool confirmar = true;
    Console.WriteLine("Mesa");
    // Recorre el arreglo de mesas y las imprime en pantalla
    for (int i = 0; i < numeroMesa.Length; i++)
    {
        Console.WriteLine($"{i + 1}. Mesa {i + 1}");
    }

    do
    {
        // Solicita ingresar la mesa que se está atendiendo
        do
        {
            Console.WriteLine("Ingrese la mesa que se está atendiendo");
        } while (!byte.TryParse(Console.ReadLine(), out id)); // Valida que la entrada sea un byte

        // Verifica que la mesa seleccionada sea válida
        if (id > 0 && id < (numeroMesa.Length + 1))
        {
            Console.WriteLine("Perfecto, la mesa que esta atendiendo es la número " + id);
            administrarmesa = new Mesa(id, num); // Crea una instancia de la mesa seleccionada
            administrarmesa.MostrarDatos(); // Muestra los datos de la mesa
            confirmar = false; // Sale del ciclo
        }
        else
        {
            Console.WriteLine("Ingrese una mesa valida"); // Mensaje si la mesa seleccionada no es válida
        }
    } while (confirmar); // Repite el ciclo mientras confirmar sea verdadero
}
//metodo para mostrar y gestionar la carta de productos
            void Carta()
            {
                Console.Clear(); //limpia la consola para una presentacion limpia
                //Muestra el titulo del menú con una presentacion de ASCII
                Console.WriteLine("El menú es este con las cantidades de los productos");
                Console.WriteLine("PPPP   RRRR    OOO    DDDD   U  U   CCCC   TTTTT  OOO ");
                Console.WriteLine("P   P  R   R  O   O  D   D  U   U  C       T     O   O");
                Console.WriteLine("PPPP   RRRR   O   O  D   D  U   U  C       T     O   O");
                Console.WriteLine("P      R  R   O   O  D   D  U   U  C       T     O   O");
                Console.WriteLine("P      R   R   OOO   DDDD   UUUU   CCCC    T      OOO ");

//verifica si la carta ya ha sido mostrada anteriormente
                if (mostrar == false)
                {
                    //Itera sobre las diez filas de productos
                    for (int i = 0; i < 10; i++)
                    {
                        //Itera sobre las 3 columnas: Nombre, precio y cantidad
                        for (int j = 0; j < 3; j++)
                        {
                            if (j == 0)
                            {
                                //asigna el nombre del producto a la carta
                                carta[i, j] = producto.Nombre[i];
                            }
                            else if (j == 1)
                            {
                                 //asigna el precio del producto a la carta
                                carta[i, j] = producto.Precio[i];
                            }
                            else if (j == 2)
                            {
                                 //asigna la cantidad del producto a la carta
                                carta[i, j] = producto.Cantidad[i];
                            }
                            //muestra el contenido de la carta separado por |                            Console.Write(carta[i, j] + "|");
                        }
                        Console.WriteLine();
                    }
                    mostrar = true;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(carta[i, j] + "|");
                        }
                        Console.WriteLine();
                    }
                }               
                Console.WriteLine("Desea cambiar algo de la carta?");
                byte confirm;
                do
                {                    
                        Console.WriteLine("(1)Si    (2)No");                                     
                } while (!byte.TryParse(Console.ReadLine(), out confirm) || (confirm != 1 && confirm != 2));
                if (confirm == 1)
                {
                    byte respu;
                    byte respu2;
                    Console.WriteLine("E E E E E   D D D D    I I I I  T T T T    A A A   R R R R"  );
                    Console.WriteLine("E           D       D     I       T       A     A  R      R" );
                    Console.WriteLine("E E E       D       D     I       T       A A A A  R R R"    );
                    Console.WriteLine("E           D       D     I       T       A     A  R   R"    );
                    Console.WriteLine("E E E E E   D D D D     I I I     T       A     A  R    R"   );
                    do
                    {
                        Console.WriteLine("Que fila desea editar?");
                        
                    } while (!byte.TryParse(Console.ReadLine(), out respu) || (respu >= 10 && respu <= 1));                    
                    do
                    {
                        Console.WriteLine("Que columna desea editar?");
                    } while (!byte.TryParse(Console.ReadLine(), out respu2) || (respu2 >= 3 && respu2 <= 1));
                    string cambio;
                    bool valides = false;
                    do
                    {
                        Console.WriteLine("Ingrese el cambio que quiere hacerle a la carta");
                        cambio = Console.ReadLine() ??string.Empty;

                        if (respu2 == 1)
                        {
                            Console.WriteLine("Registrando cambio 1");
                            carta[respu-1, respu2-1] = cambio;                                                                              
                            valides = true;
                        }
                        else if (respu2 == 2)
                        {
                            Console.WriteLine("Registrando cambio 2");
                            if ((int.TryParse(cambio, out int numeroEntero)) && ((numeroEntero / 1000) >= 1))
                            {
                                carta[respu - 1, respu2 - 1] = cambio;
                                valides = true;
                            }
                            else 
                            {
                                Console.WriteLine("Ingrese un opción valida, el valor que ingresaste es demasido bajo para los productos que vendemos");
                                valides = false;
                            }
                        }
                        else if(respu2 == 3)
                        {
                            Console.WriteLine("Registrando cambio 2");
                            if ((int.TryParse(cambio, out int numeroEntero)) && ((numeroEntero / 1000) < 1))
                            {
                                carta[respu-1, respu2-1] = cambio;                                
                                valides = true;
                            }
                            else
                            {
                                Console.WriteLine("Ingrese una opción valida, el valor que ingresaste es demasido alto ó no tenemos tanta cantidad de productos");
                                valides = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un opción valida");
                            valides = false;
                        }                        
                    } while (valides == false);
                    Console.WriteLine("Continuo");
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {                            
                            Console.Write(carta[i, j] + "|");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Oprima cualquier tecla para continuar");
                    Console.ReadKey();
                    Carta();



                }
                else if(confirm == 2)
                {
                    Compra();
                        
                    
                }
            }
            
            void Compra()
            {
                
                Console.WriteLine("Ingrese el nombre del producto que desea comprar");
                string compra = Console.ReadLine();
                for (int i = 0; i < 10; i++)
                {                    
                    if (carta[i,0].ToLower() == compra.ToLower())
                    {                        
                        for (int j = 0; j < 10; j++)
                        {
                            if(compramesa[j, 0] != null)
                            {                                
                                if (compramesa[j, 0].ToLower() == compra.ToLower())
                                {
                                    Console.WriteLine("Registrando datos...");
                                    int suma;
                                    suma = Convert.ToInt16(compramesa[j, 2]);
                                    suma = suma + 1;
                                    pedido.Pedidos[j, 2] = Convert.ToString(suma);
                                    compramesa[j, 2] = Convert.ToString(suma);

                                }
                            }
                        }                        
                        bool ingresar = false;
                        bool revision = false;
                        for (int j = 0; j < 10; j++)
                        {
                            
                            if (compramesa[j, 0] == null && ingresar == false)
                            {                                
                                for (int k = 0; k < 10; k++)
                                {                                    
                                    if (compramesa[k, 0] != null && compramesa[k, 0].ToLower() == compra.ToLower())
                                    {                                        
                                        revision = true;
                                    }                                    
                                    if (k == 9 && revision == false) 
                                    {
                                        Console.WriteLine("Registrando datos...");
                                        pedido.Pedidos[j, 0] = compra;
                                        compramesa[j, 0] = compra;                                        
                                        pedido.Pedidos[j, 2] = "1";
                                        compramesa[j, 2] = "1";
                                        for(int l  = 0; l < 10; l++)
                                        {
                                            if (carta[l, 0].ToLower() == compra.ToLower())
                                            {
                                                pedido.Pedidos[j, 1] = carta[l,1];
                                                compramesa[j, 1] = carta[l, 1];
                                            }
                                        }
                                        ingresar = true;
                                    }
                                }                                
                            }
                        }                        
                    }                    
                }
                byte confirm2;
                Console.WriteLine("Quieres seguir comprando?");
                do
                {
                    Console.WriteLine("(1)Si    (2)No");
                } while (!byte.TryParse(Console.ReadLine(), out confirm2) || (confirm2 != 1 && confirm2 != 2));
                if (confirm2 == 1)
                {
                    Compra();
                }
                else if (confirm2 == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Estos son los productos que han pedido");
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0;j < 3; j++)
                        {
                            Console.Write(pedido.Pedidos[i,j] + "|");
                        }
                        Console.WriteLine();
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(compramesa[i, j] + "|");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Oprime una tecla para continuar");
                    Console.ReadKey();
                    Menu();
                }

            }
            

        }


    }
}
