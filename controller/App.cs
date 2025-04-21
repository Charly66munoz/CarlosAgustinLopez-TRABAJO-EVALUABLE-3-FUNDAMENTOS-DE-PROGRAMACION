using System.Collections;
using System.Formats.Tar;
using System.Linq.Expressions;

public class App
{
    private List<Tarea> listaDeTareas = new List<Tarea>();

    public App()
    {

    }

    public bool TareasVacias()
    {
        return this.listaDeTareas.Count == 0;
    }

    public List<Tarea> GetListaDeTareas()
    {
        return this.listaDeTareas;
    }
    public void CrearTarea()
    {
        string continuar;

        do
        {
            Tarea tarea = new Tarea();
            Console.WriteLine("Ingrese porfavor los siguientes datos: ");
            Console.WriteLine("Nombre de la tarea: ");
            string nombreN = Console.ReadLine();
            Console.WriteLine("Descripción: ");
            string descripcionD = Console.ReadLine();

            TipoTarea tipo = AsiganarTipoTarea();

            Console.WriteLine("Prioridad (marque '+' si tiene prioridad o '-' si no la tiene): ");
            bool prioridad = ConvertidorDePrioridad(Console.ReadLine());

            int idTarea = GenerarID();
            Console.WriteLine($"\n{idTarea}\n");

            tarea = new Tarea(nombreN, descripcionD, tipo, prioridad, idTarea);
            this.listaDeTareas.Add(tarea);

            Console.WriteLine("Tarea añadida con id: " + tarea.GetIdTarea() + ".");
            Console.WriteLine("¿Desea continuar creando tareas?: si/no: ");
            continuar = Console.ReadLine();

            Console.Clear();

        } while (continuar.Equals("si", StringComparison.OrdinalIgnoreCase));

    }

    private int GenerarID()
    {
        Random random = new Random();
        int numeroRandom = random.Next(1000, 10000);
        while (ComprabadorDeId(numeroRandom))
        {
            numeroRandom = random.Next(1000, 10000);
        }
        return numeroRandom;
    }
    //completar "estaTarea"
    private bool ConvertidorDePrioridad(String priority0)
    {
        bool prioridad = false;
        if (priority0.Equals("+", StringComparison.Ordinal))
        {
            prioridad = true;

        }
        else if (priority0.Equals("-", StringComparison.Ordinal))
        {
            prioridad = false;
        }
        else
        {
            Console.WriteLine("Valor de prioridad inválido. Se asignará '-' por defecto.");
            prioridad = false;
            Console.WriteLine("Si desea cambiarlo escriba 'si', de lo contrario saldra automaticamente");
            priority0 = Console.ReadLine();

            if (priority0.Equals("Si", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Cambiado valor a '+'.");
                prioridad = true;
                Console.WriteLine("Presione cualquier tecla para salir: ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Asignado valor por defecto '-'.");
            }



        }

        return prioridad;
    }
    private bool ComprabadorDeId(int random)
    {


        foreach (Tarea t in listaDeTareas)
        {
            if (t.GetIdTarea() == random)
            {
                return true;
            }

        }

        return false;
    }

    private TipoTarea AsiganarTipoTarea()
    {
        Console.WriteLine("Tipo, puede ser personal (1), trabajo (2) y/o ocio (3).\n Elija porfavor cual desea escribiendo el numero: ");
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion > 3 || opcion < 1)
        {
            Console.WriteLine("Dato ingresado no valido, eliga dentro de estas tres opciones: \n1-Personal \n2-Trabajo \n3-Ocio ");
            Console.WriteLine("Ingrese el numero nuevamente: ");

        }
        TipoTarea tipo = TipoTarea.Trabajo;
        switch (opcion)
        {
            case 1:
                tipo = TipoTarea.Persona;
                return tipo;
            case 2:
                tipo = TipoTarea.Trabajo;
                return tipo;
            case 3:
                tipo = TipoTarea.Ocio;
                return tipo;
        }

        return tipo;
    }
    public void MostrarTareas()
    {
        if (ListaVacia()) return;

        Console.WriteLine("Estas son sus tareas: ");
        var tareaOrdenada = this.listaDeTareas
            .OrderByDescending(t => t.GetPriority())
            .ThenBy(t => t.GetTipoTarea());

        MostrarListado(tareaOrdenada);

        Console.WriteLine("Presione cualquier tecla para salir");
        Console.ReadLine();
        return;
    }

    public void MostrarTareasEspecificas()
    {
        if (ListaVacia()) return;

        TipoTarea tipo = AsiganarTipoTarea();
        Console.WriteLine("Estas son sus tareas de tipo: " + tipo);
        var tareasFiltradas = this.listaDeTareas.Where(t => t.GetTipoTarea() == tipo).ToList();

        if (tareasFiltradas.Count == 0)
        {
            Console.WriteLine("Aun no has creado ninguna tarea con este tipo");
        }
        else
        {
            MostrarListado(tareasFiltradas);
        }

        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadLine();
        return;
    }

    private void MostrarListado(IEnumerable<Tarea> tareas)
    {
        foreach (Tarea tarea in tareas)
        {
            tarea.MostrarTarea();
            Console.WriteLine("-----");
        }
    }

    private bool ListaVacia()
    {
        if (this.listaDeTareas == null || this.listaDeTareas.Count == 0)
        {
            Console.WriteLine("Aun no has creado ninguna lista");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadLine();
            return true;
        }

        return false;
    }

    public void EliminarTarea()
    {
        Console.WriteLine("¿Que tarea desea eliminar? Ingrese el id");

        Tarea t = VerificadorDeTareas();

        if (t == null)
        {
            Console.WriteLine("Cancelando operación. Volviendo al menú...");
            return;
        }

        this.listaDeTareas.Remove(t);

        Console.WriteLine("Tarea eliminada");
        Console.WriteLine("¿Quiere eliminar otra tarea? Presione si o no");

        string continuar = Console.ReadLine();
        bool continuaBool = false;

        do
        {
            if (continuar.Equals("si", StringComparison.CurrentCultureIgnoreCase))
            {
                EliminarTarea();
            }
            else if (continuar.Equals("no", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Volviendo al menu");


                return;
            }
            else
            {
                Console.WriteLine("Valor ingresado inválido. Saliendo");
                Console.WriteLine("Presione cualquier tecla para salir");
                Console.ReadLine();

                return;
            }
        } while (!continuaBool);
    }
    public Tarea VerificadorDeTareas()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (input.Equals("salir", StringComparison.CurrentCultureIgnoreCase))
            {
                return null;
            }
            try
            {
                int idTarea = int.Parse(input);
                Tarea tarea = listaDeTareas.Find(t => t.GetIdTarea() == idTarea);

                if (tarea != null)
                {
                    return tarea;
                }

                Console.WriteLine("Tarea no existe, vuelva a intentarlo o escriba 'salir' para cancelar");
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido. Asegúrese de ingresar solo números o escriba 'salir' para cancelar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado: " + ex.Message);
            }
        }
    }
}