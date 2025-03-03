using System;
using System.IO; // Importamos lo necesario para trabajar con archivos y carpetas

class Program
{
    static void Main()
    {
        // Llamo a la función que muestra el menú interactivo
        MostrarMenu();
    }

    //Función para crear el archivo inventos.txt con contenido inicial
    static void CrearArchivo()
    {
        string ruta = "inventos.txt"; // Nombre del archivo

        // Creo el archivo y escribo el contenido inicial
        using (StreamWriter writer = new StreamWriter(ruta))
        {
            writer.WriteLine("1. Traje Mark I");
            writer.WriteLine("2. Reactor Arc");
            writer.WriteLine("3. Inteligencia Artificial JARVIS");
        }

        Console.WriteLine("Archivo 'inventos.txt' creado exitosamente.");
    }

    //Función para agregar un invento sin sobrescribir el archivo
    static void AgregarInvento(string invento)
    {
        string ruta = "inventos.txt";

        // Agrega una nueva línea al archivo sin borrar lo que ya tiene
        using (StreamWriter writer = new StreamWriter(ruta, true))
        {
            writer.WriteLine(invento);
        }

        Console.WriteLine("Invento agregado exitosamente.");
    }

    //Función para leer el archivo línea por línea
    static void LeerLineaPorLinea()
    {
        string ruta = "inventos.txt"; // Nombre del archivo

        // Verifico si el archivo existe antes de leerlo
        if (File.Exists(ruta))
        {
            string[] lineas = File.ReadAllLines(ruta); // Guardo todas las líneas en un arreglo

            // Uso un bucle simple para mostrar cada línea
            for (int i = 0; i < lineas.Length; i++)
            {
                Console.WriteLine(lineas[i]); // Muestro cada línea en la consola
            }
        }
        else
        {
            Console.WriteLine("Error: No se encontró el archivo inventos.txt"); // Mensaje si el archivo no existe
        }
    }

    //Función para leer todo el contenido del archivo
    static void LeerTodoElTexto()
    {
        string ruta = "inventos.txt"; // Nombre del archivo

        // Verifico si el archivo existe antes de leerlo
        if (File.Exists(ruta))
        {
            string contenido = File.ReadAllText(ruta); // Leo todo el contenido del archivo y lo guardo en una variable
            Console.WriteLine("Contenido completo del archivo:");
            Console.WriteLine(contenido); // Muestro el contenido completo en la consola
        }
        else
        {
            Console.WriteLine("Error: No se encontró el archivo inventos.txt"); // Mensaje si el archivo no existe
        }
    }
    static void LeerArchivoConExcepciones()
 {
     string ruta = "inventos.txt"; // Nombre del archivo

     try
     {
         // Intento leer el archivo completo
         string contenido = File.ReadAllText(ruta);
         Console.WriteLine("Lectura exitosa:");
         Console.WriteLine(contenido);
     }
     catch (FileNotFoundException) // Capturo el error si el archivo no existe
     {
         Console.WriteLine("Error: El archivo inventos.txt no existe. ¡Ultron debe haberlo borrado!");
     }
     catch (UnauthorizedAccessException) // Capturo el error si no tengo permisos
     {
         Console.WriteLine("Error: No tienes permisos para leer el archivo.");
     }
     catch (Exception ex) // Capturo cualquier otro error desconocido
     {
         Console.WriteLine($"Error inesperado: {ex.Message}");
     }
 }

    //Función para copiar un archivo
    static void CopiarArchivo(string origen, string destino)
    {
        if (File.Exists(origen))
        {
            string carpetaDestino = Path.GetDirectoryName(destino);
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            File.Copy(origen, destino, true);
            Console.WriteLine($"Archivo copiado de {origen} a {destino}");
        }
        else
        {
            Console.WriteLine($"Error: El archivo {origen} no existe.");
        }
    }

    //Función para mover un archivo
    static void MoverArchivo(string origen, string destino)
    {
        if (File.Exists(origen))
        {
            string carpetaDestino = Path.GetDirectoryName(destino);
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            File.Move(origen, destino);
            Console.WriteLine($"Archivo movido de {origen} a {destino}");
        }
        else
        {
            Console.WriteLine($"Error: El archivo {origen} no existe.");
        }
    }

    //Función para crear una nueva carpeta
    static void CrearCarpeta(string nombreCarpeta)
    {
        if (!Directory.Exists(nombreCarpeta))
        {
            Directory.CreateDirectory(nombreCarpeta);
            Console.WriteLine($"Carpeta '{nombreCarpeta}' creada exitosamente.");
        }
        else
        {
            Console.WriteLine($"La carpeta '{nombreCarpeta}' ya existe.");
        }
    }

    //Función para listar archivos en una carpeta
    static void ListarArchivos(string ruta)
    {
        if (Directory.Exists(ruta))
        {
            Console.WriteLine($"Contenido de la carpeta '{ruta}':");

            // Obtengo todas las subcarpetas dentro de la ruta indicada
            string[] carpetas = Directory.GetDirectories(ruta);

            // Muestro las carpetas que encontré
            for (int i = 0; i < carpetas.Length; i++)
            {
                Console.WriteLine("[Carpeta] " + Path.GetFileName(carpetas[i]));
            }

            // Obtengo todos los archivos dentro de la ruta indicada
            string[] archivos = Directory.GetFiles(ruta);

            // Muestro los archivos que encontré
            for (int i = 0; i < archivos.Length; i++)
            {
                Console.WriteLine("[Archivo] " + Path.GetFileName(archivos[i]));
            }

            // Si no hay archivos ni carpetas, aviso al usuario
            if (carpetas.Length == 0 && archivos.Length == 0)
            {
                Console.WriteLine("La carpeta está vacía.");
            }
        }
        else
        {
            Console.WriteLine($"Error: La carpeta '{ruta}' no existe.");
        }
    }


    static void MostrarMenu()
    {
        int opcion;

        do
        {
            // Muestro las opciones disponibles
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Crear archivo inventos.txt");
            Console.WriteLine("2. Agregar un nuevo invento");
            Console.WriteLine("3. Leer archivo línea por línea");
            Console.WriteLine("4. Leer todo el archivo");
            Console.WriteLine("5. Copiar un archivo");
            Console.WriteLine("6. Mover un archivo");
            Console.WriteLine("7. Crear una carpeta");
            Console.WriteLine("8. Listar archivos en una carpeta");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");

            // Leo la opción del usuario
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                // Llamo a la función correspondiente según la opción elegida
                switch (opcion)
                {
                    case 1:
                        CrearArchivo();
                        break;
                    case 2:
                        Console.Write("Ingrese el nuevo invento: ");
                        string nuevoInvento = Console.ReadLine();
                        AgregarInvento(nuevoInvento);
                        break;
                    case 3:
                        LeerLineaPorLinea();
                        break;
                    case 4:
                        LeerTodoElTexto();
                        break;
                    case 5:
                        LeerArchivoConExcepciones();
                        break;
                    case 6:
                        CopiarArchivo("inventos.txt", "Backup/inventos_backup.txt");
                        break;
                    case 7:
                        MoverArchivo("inventos.txt", "ArchivosClasificados/inventos.txt");
                        break;
                    case 8:
                        Console.Write("Ingrese el nombre de la carpeta a crear: ");
                        string nuevaCarpeta = Console.ReadLine();
                        CrearCarpeta(nuevaCarpeta);
                        break;
                    case 9:
                        Console.Write("Ingrese la ruta de la carpeta a listar: ");
                        string ruta = Console.ReadLine();
                        ListarArchivos(ruta);
                        break;
                    case 10:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }

        } while (opcion != 9); // Repetir hasta que el usuario elija salir
    }
}



