

public class MenuController
{
    private App app;

    public MenuController()
    {
        this.app = app;
    }

    public MenuController(App app)
    {
        this.app = app;
    }

    public void MostrarMenu()
    {
        Console.WriteLine("Bienvenido a su organizador diario");

        if (app.TareasVacias())
        {
            Console.WriteLine("Empiece a crear su lista de tareas: ");
            app.CrearTarea();
        }

        MostrarSubMenu();
    }

    private void MostrarSubMenu()
    {
        int opcion = 0;
        do
        {
            Console.WriteLine("¿Qué desea realizar?");
            Console.WriteLine("1 - Crear tarea");
            Console.WriteLine("2 - Mostrar tareas");
            Console.WriteLine("3 - Mostrar tareas de un tipo específico");
            Console.WriteLine("4 - Eliminar tarea");
            Console.WriteLine("5 - Exportar lista de tareas");
            Console.WriteLine("6 - Importar lista de tareas");
            Console.WriteLine("7 - Salir");

            Console.WriteLine("Presione el número correspondiente a la opción deseada:");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 7)
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
            }

            switch (opcion)
            {
                case 1:
                    app.CrearTarea();
                    break;
                case 2:
                    app.MostrarTareas();
                    break;
                case 3:
                    app.MostrarTareasEspecificas();
                    break;
                case 4:
                    app.EliminarTarea();
                    break;
                case 5:
                    GestorDeArchivos.ExportarTarea(app.GetListaDeTareas());
                    break;
                case 6:
                    GestorDeArchivos.RetornarTxt(app.GetListaDeTareas());
                    break;
                case 7:
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }

        } while (opcion != 7);
    }
}