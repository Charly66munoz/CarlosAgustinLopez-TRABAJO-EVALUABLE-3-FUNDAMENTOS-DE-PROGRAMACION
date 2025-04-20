public class Tarea{

    private string? nombre, descripcion;
    private TipoTarea tipo;

    private Boolean priority;

    private int idTarea;

    public Tarea (){
       this.nombre = nombre;
       this.descripcion = descripcion;
       this.tipo= tipo;
       this.priority = priority;
       this.idTarea = idTarea; 
    }

    public Tarea (string nombre, string descripcion, TipoTarea tipo, bool priority0, int id){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.tipo= tipo;
        this.priority = priority;
        this.idTarea = id; 

    }

    public void MostrarTarea(){
      Console.WriteLine("Nombre de la tarea: "+ nombre);
      Console.WriteLine("Descripcion: "+ descripcion);
      Console.WriteLine("Tipo de tarea "+ tipo);
      Console.WriteLine("Identidficador de tarea: "+ idTarea);
      Console.WriteLine("Prioridad: "+ priority);
      
    }


   
   

    public string? GetNombre(){
      return this.nombre;
    }

    public string? GetDescripcion(){
      return this.descripcion;
    }

    public TipoTarea GetTipoTarea(){
      return this.tipo;
    }

    public Boolean GetPriority(){

        return this.priority;
    }

    public int GetIdTarea(){
      return this.idTarea;
    }

    public void SetNombre(string nombre){
         this.nombre = nombre;
    }

    public void SetDescripcion(string descripcion){
      this.descripcion = descripcion;
    }

    public void SetTipoDeTarea(TipoTarea tipo){
      this.tipo = tipo;
    }
    
    public void SetPriority(String priority0){
      if   (priority0.Equals("+", StringComparison.Ordinal)){
            this.priority = true;
            
         }else if(priority0.Equals("-",StringComparison.Ordinal)){
            this.priority = false;
         }else{
            Console.WriteLine("Valor de prioridad inválido. Se asignará '-' por defecto.");
            this.priority = false;

         }
    }
}