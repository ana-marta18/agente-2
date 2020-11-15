using System;
using Newtonsoft.Json;
using Experimental.System.Messaging; 
using System.IO;
namespace agente_2
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter almacenamiento;
            almacenamiento = new StreamWriter("almacenamiento.txt");
            String mensaje;
            mensaje = Console.ReadLine();
            almacenamiento.WriteLine(mensaje);
            almacenamiento.Close();

             String s1=null;
            //Creamos un do while para repetir.
            do{
                Console.WriteLine(""); 
                Console.WriteLine("                            Bienvenido a el Microservicio UMG                             ");
                Console.WriteLine("------------------------------------------------------------------------------------------");
                Console.WriteLine("Si deseas que el agente 2 extraiga un nombre aleatorio escribe 1 de lo contrario escribe 2");
                Console.Write("1. Si \n");
                Console.Write("2. No \n" );
                Console.WriteLine("");
                s1 = Console.ReadLine();
                switch(s1){
        
                case "1":
                Console.WriteLine("Leyendo la cola...");            
                Console.WriteLine("");
                
                //Conexión a la Cola
                MessageQueue queue = new MessageQueue (".\\private$\\nombres");

                //Creamos el pop
                Message messageJson = queue.Receive();
                messageJson.Formatter = new XmlMessageFormatter(new String[]{"System.String,mscorlib"});
                Console.WriteLine(messageJson.Body);
                Console.ReadKey();
                break;
  
                case "2":
                Console.WriteLine("No se a eliminado ningún nombre de la cola");
                break;
                }
                Console.WriteLine("Si desea ejecutar de nuevo responde con un si de lo contrario escribe no");
                s1 = Console.ReadLine();
                } while(s1== "Si"||s1=="si" );
                { 
                Console.ReadKey();
                }       
        }
    }
    public class MessageNombre
    {
        public String nombre {get; set;}
    }
}