public class Tarea{

    private string? nombre, descripcion;
    private TipoTarea tipo;
    private string? priorityString;
    private Boolean priority;

    private int idTarea;

    public Tarea (){
       this.nombre = nombre;
       this.descripcion = descripcion;
       this.tipo= tipo;
       this.priority = priority;
       this.idTarea = idTarea; 
    }

    public Tarea (string nombre, string descripcion, TipoTarea tipo, string priority0, int id){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.tipo= tipo;
         if   (priority0.Equals("+", StringComparison.Ordinal)){
            this.priority = true;
            
         }else if(priority0.Equals("-",StringComparison.Ordinal)){
            this.priority = false;
         }else{
            Console.WriteLine("Valor de prioridad inválido. Se asignará '-' por defecto.");
            this.priority = false;
            Console.WriteLine("Si desea cambiarlo escriba si, de lo contrario saldra automaticamente");
            priority0 = Console.ReadLine();
            if (priority0.Equals("Si", StringComparison.OrdinalIgnoreCase)){
               Console.WriteLine("Asignado valor '+'.");
               this.priority = true;
            }else{
               Console.WriteLine("Asignado valor por defecto '-'.");
            }

         }

         this.idTarea = id; 

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