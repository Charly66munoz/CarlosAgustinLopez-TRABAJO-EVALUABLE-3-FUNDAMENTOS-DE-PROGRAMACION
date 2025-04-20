using System.Collections;
using System.Formats.Tar;
using System.Linq.Expressions;

public class App{
    private List<Tarea> listaDeTareas = new List<Tarea>();

    public App(){ 
        
       }



    public void Menu(){
        Console.WriteLine("Bienvenidos a tu organizador diario");
        
        if (this.listaDeTareas.Count == 0){
            Console.WriteLine("Empieza a crear tu lista de tareas: ");
            CrearTarea();
        }

        SubMenu();
        
   
    }

    public void SubMenu(){
        Console.WriteLine("Que desea realizar ahora? ");
        Console.WriteLine("1 - Crear tarea");
        Console.WriteLine("2 - Mostrar tareas");
        Console.WriteLine("3 - Mostrar tareas de un tipo especifico");
        Console.WriteLine("4 - Eliminar tarea");
        Console.WriteLine("5 - Exportar lista de tareas");
        Console.WriteLine("6 - Importar lista de tareas");
        Console.WriteLine("7 - Salir");

        Console.WriteLine("Precione el numero correspondiente a la opcion deseada.");
         
            int opcion = 0;
        do{
        try{
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 7 ){
            
        }}
        catch (ArgumentNullException ex) {
            Console.WriteLine("No ha ingresado nada. Intentelo de nuevo");
            Console.Clear();
            SubMenu();
        }
        catch (FormatException ex) {
            Console.Clear();
            Console.WriteLine("Formato no válido. Intentelo de nuevo");
            SubMenu();
        }catch (Exception e){
            Console.Clear();
            Console.WriteLine("Formato no válido. error" +e.Message);
            SubMenu();

        }
        
        
        switch(opcion){
            case 1: CrearTarea();
                    SubMenu();
            break;
            case 2: MostrarTareas();
                    SubMenu();

            break;
            case 3:
                Console.WriteLine("Que tipo de tarea desea buscar");   
                MostrarTareasEspecificas();
                SubMenu();

            break;
            case 4:
                    EliminarTarea();
                    SubMenu();
                    break;
            case 5:

            case 6:

            case 7:  
            break; 
        }
        }while (opcion != 7);
    }

    public void CrearTarea(){
        Tarea tarea = new Tarea();
        Console.WriteLine("Ingrese porfavor los siguientes datos: ");
        Console.WriteLine("Nombre de la tarea: ");
        String nombreN = "a";//Console.ReadLine();
        Console.WriteLine("Descripción: ");
        String descripcionD = "a";//Console.ReadLine();
       
        TipoTarea tipo = AsiganarTipoTarea(); 
       
        Console.WriteLine("Prioridad (marque '+' si tiene prioridad o '-' si no la tiene): ");
        
        bool prioridad = ConvertidorDePrioridad(Console.ReadLine());
        int idTarea = GenerarID();
        Console.WriteLine("");

        Console.WriteLine(idTarea);
        Console.WriteLine("");

        tarea = new Tarea(nombreN, descripcionD, tipo, prioridad, idTarea );
        this.listaDeTareas.Add(tarea);
        Console.Clear();
        Console.WriteLine("Tarea añadidad con id: "+ tarea.GetIdTarea() + ". \n¿Desea continuar creando tareas?: si/no: ");
        
        
        string continuar = Console.ReadLine();
        bool continuaBool = false;
        do{
        
        if   (continuar.Equals("si", StringComparison.OrdinalIgnoreCase)){
            
            
         }else if(continuar.Equals("no",StringComparison.OrdinalIgnoreCase)){
            continuaBool = false;
            return;
         }else{
            Console.WriteLine("Valor de prioridad inválido. Saliendo");
            Console.WriteLine("-------");
            return;
         }
        }while (!continuaBool);
        if(continuaBool){
            Console.Clear();
            CrearTarea();
        }
        Console.Clear();
        return;
        
    }

    private int GenerarID(){
        Random random = new Random();
        int numeroRandom = random.Next(1000, 10000);
        while(ComprabadorDeId(numeroRandom)){
            numeroRandom = random.Next(1000, 10000);
        }
        return numeroRandom;
    }
//completar "estaTarea"
    private bool ConvertidorDePrioridad(String priority0){
        bool prioridad = false;
        if   (priority0.Equals("+", StringComparison.Ordinal)){
            prioridad = true;
            
         }else if(priority0.Equals("-",StringComparison.Ordinal)){
            prioridad = false;
         }else{
            Console.WriteLine("Valor de prioridad inválido. Se asignará '-' por defecto.");
             prioridad  = false;
            Console.WriteLine("Si desea cambiarlo escriba 'si', de lo contrario saldra automaticamente");
            priority0 = Console.ReadLine();
            
            if (priority0.Equals("Si", StringComparison.OrdinalIgnoreCase)){
               Console.WriteLine("Cambiado valor a '+'.");
                prioridad  = true;
                Console.WriteLine("Presione cualquier tecla para salir: ");
                Console.ReadLine();
            }else{
               Console.WriteLine("Asignado valor por defecto '-'.");
            }



         }

        return prioridad;
    }
    private bool ComprabadorDeId(int random){

        
        foreach (Tarea t in listaDeTareas){
            if (t.GetIdTarea() == random){
                return true;
            }
            
        }
   
      return false;
    }

    private  TipoTarea AsiganarTipoTarea(){
        Console.WriteLine("Tipo, puede ser personal (1), trabajo (2) y/o ocio (3).\n Elija porfavor cual desea escribiendo el numero: ");
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion ) ||opcion > 3 || opcion < 1){
        Console.WriteLine("Dato ingresado no valido, eliga dentro de estas tres opciones: \n1-Personal \n2-Trabajo \n3-Ocio ");            
        Console.WriteLine("Ingrese el numero nuevamente: ");            
       
        } 
        TipoTarea tipo = TipoTarea.Trabajo;
        switch(opcion){
            case 1: 
            tipo = TipoTarea.Persona;
            return tipo;
            case 2: 
            tipo = TipoTarea.Trabajo;
            return tipo;
            case 3: tipo = TipoTarea.Ocio;
            return tipo;
        }

        return tipo; 
    } 
    public void MostrarTareas(){
        
        
        if(this.listaDeTareas == null || this.listaDeTareas.Count == 0){
            Console.WriteLine("Aun no has creado ninguna lista");
            Console.WriteLine("Precione cualquier tecla para continuar");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Estas son sus tareas: ");


        var tareaOrdenada = this.listaDeTareas.OrderByDescending(t => t.GetPriority()).ThenBy(t => t.GetTipoTarea());

        foreach (Tarea tarea in tareaOrdenada){
            Console.WriteLine("-----");
            tarea.MostrarTarea();
        }

        Console.WriteLine("Precione cualquier tecla para salir");
        Console.ReadLine();
        return;
        
    }

    public void MostrarTareasEspecificas(){
        TipoTarea tipo = AsiganarTipoTarea();
        if(this.listaDeTareas == null || this.listaDeTareas.Count == 0){
            Console.WriteLine("Aun no has creado ninguna lista");
            Console.WriteLine("Precione cualquier tecla para continuar");
            Console.ReadLine();
             
            return;
        }
        Console.WriteLine("Estas son sus tareas de tipo: "+ tipo);
         bool hayUna= false;


        foreach (Tarea tarea in this.listaDeTareas){
            if(tarea.GetTipoTarea() == tipo){
                tarea.MostrarTarea();
            Console.WriteLine("-----");
            

                hayUna = true;
            }
        }

        if(!hayUna){
            Console.WriteLine("Aun no has creado ninguna tarea con este tipo");

        }

        Console.WriteLine("Precione cualquier tecla para continuar");
        Console.ReadLine();
        return;


    }

    public void EliminarTarea (){
        Console.WriteLine("¿Que tarea desea eliminar? Ingrese el id");
        Tarea t = VerificadorDeTareas();
        this.listaDeTareas.Remove(t);
        Console.WriteLine("Tarea eliminiada");
        Console.WriteLine("¿Quiere elimar otra tarea? presione si o no");
        string continuar = Console.ReadLine();
        bool continuaBool = false;

        do { if(continuar.Equals("si", StringComparison.CurrentCultureIgnoreCase)){
                EliminarTarea();
            }else if(continuar.Equals("no", StringComparison.CurrentCultureIgnoreCase)){
                Console.WriteLine("Volviendo al menu");
                Console.Clear();

                return;
            }else{
                Console.WriteLine("Valor ingresado inválido. Saliendo");
                Console.WriteLine("Presione cualquier tecla para salir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }while(!continuaBool);

        return;


    }

    



    public Tarea VerificadorDeTareas() {
        
        try{
            int idTarea = int.Parse(Console.ReadLine());
            
            Tarea tarea = listaDeTareas.Find(t  => t.GetIdTarea() == idTarea);
            if(tarea != null){
                
                return tarea;
                
            }
            

            Console.WriteLine("Tarea no existe, vuelva a intentarlo");
                return VerificadorDeTareas(); 
            }catch( FormatException){
                Console.WriteLine("Formato inválido. Asegúrese de ingresar solo números.");
                return VerificadorDeTareas();
            }catch (Exception ex) {
                Console.WriteLine("Error inesperado: " + ex.Message);
                return VerificadorDeTareas();
            }

    }

    public void ExportarTarea(){
        var tareaOrdenada = this.listaDeTareas.OrderByDescending(t => t.GetPriority()).ThenBy(t => t.GetTipoTarea());

        string ruta = "lista.txt";

        using(StreamWriter writer = new StreamWriter(ruta)){
            foreach (Tarea t in tareaOrdenada){
                string linea = $"{t.GetIdTarea()},{t.GetNombre()},{t.GetDescripcion()},{t.GetTipoTarea()},{t.GetPriority()}";
                writer.WriteLine(linea);
            }
        }

        Console.WriteLine("Tareas exportadas correctamente en: " + Path.GetFullPath(ruta));
    }

    public void RetornarTxt(){
                string rutaArchivo = "ruta/al/archivo.txt"; // Reemplaza con la ruta real del archivo
        
        try
        {
            // Crea un objeto StreamReader para abrir y leer el archivo
            using (StreamReader sr = new StreamReader("lista.txt"))
            {
                // Lee el archivo línea por línea
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    Console.WriteLine(linea); // Imprime cada línea en la consola
                }
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