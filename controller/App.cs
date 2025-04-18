public class App{
    private List<Tarea> listaDeTareas = new List<Tarea>();

    public App(){ 
        this.listaDeTareas = listaDeTareas;
       }

    public void CrearTarea(){
        Tarea tarea = new Tarea();
        Console.WriteLine("Ingrese porfavor los siguientes datos: ");
        Console.WriteLine("Nombre de la tarea: ");
        String nombreN = Console.ReadLine();
        Console.WriteLine("Descripción: ");
        String descripcionD = Console.ReadLine();
        Console.WriteLine("Tipo, puede ser personal (1), trabajo (2) y/o ocio (3).\n Elija porfavor cual desea escribiendo el numero: ");
        int opcion;
        
        while (!int.TryParse(Console.ReadLine(), out opcion ) ||opcion > 3 || opcion < 1){
        Console.WriteLine("Dato ingresado no valido, eliga dentro de estas tres opciones: \n1-Personal \n2-Trabajo \n3-Ocio ");            
        Console.WriteLine("Ingrese el numero nuevamente: ");            
       
        } 
        TipoTarea tipo = TipoTarea.Trabajo;
        switch(opcion){
            case 1: tipo = TipoTarea.Persona;
            break;
            case 2: tipo = TipoTarea.Trabajo;
            break;
            case 3: tipo = TipoTarea.Ocio;
            break;
        }
        Console.WriteLine("Prioridad (marque '+' si tiene prioridad o '-' si no la tiene): ");
        String prioridad = Console.ReadLine();
        int idTarea = GenerarID();
        Console.WriteLine("");

        Console.WriteLine(idTarea);
        Console.WriteLine("");

        tarea = new Tarea(nombreN, descripcionD, tipo, prioridad, idTarea );
        this.listaDeTareas.Add(tarea);
        Console.WriteLine("");

        Console.WriteLine("Tarea añadidad con id: "+ tarea.GetIdTarea());


        




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
    private bool ComprabadorDeId(int random){

        
        foreach (Tarea t in listaDeTareas){
            if (t.GetIdTarea() == random){
                return true;
            }
            
        }

        
      return false;
    }



}