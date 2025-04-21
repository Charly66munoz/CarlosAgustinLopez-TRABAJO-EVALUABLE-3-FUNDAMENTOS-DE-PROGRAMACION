using System;
using System.Collections.Generic;
using System.IO;

public class GestorDeArchivos{





public static void ExportarTarea(List<Tarea> tareas)
    {
        var tareaOrdenada = tareas.OrderByDescending(t => t.GetPriority()).ThenBy(t => t.GetTipoTarea());

        string ruta = "lista.txt";

        using (StreamWriter writer = new StreamWriter(ruta))
        {
            foreach (Tarea t in tareaOrdenada)
            {
                string linea = $"{t.GetIdTarea()},{t.GetNombre()},{t.GetDescripcion()},{t.GetTipoTarea()},{t.GetPriority()}";
                writer.WriteLine(linea);
            }
        }

        Console.WriteLine("Tareas exportadas correctamente en: " + Path.GetFullPath(ruta));
    }

    public static void RetornarTxt(List<Tarea> tareas)
    {
        string rutaArchivo = "ruta/al/archivo.txt"; // Reemplaza con la ruta real del archivo

        try
        {
            // Crea un objeto StreamReader para abrir y leer el archivo
            using (StreamReader sr = new StreamReader("lista.txt"))
            {
                // Lee el archivo línea por línea
                string linea;
                Console.WriteLine("Aqui tiene su lista: ");
                while ((linea = sr.ReadLine()) != null)
                {
                    Console.WriteLine(linea); // Imprime cada línea en la consola
                }
                Console.WriteLine("  ");
                Console.WriteLine("Presione cualquier tecla para salir");
                Console.ReadLine();

            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("El archivo no fue encontrado: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al leer el archivo: " + e.Message);
        }

    }
}