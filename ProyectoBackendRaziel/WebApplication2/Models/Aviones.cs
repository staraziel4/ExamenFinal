using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Modelss
{
    public class Aviones
    {
        [Key]
        public int id_aviones { get; set; }
        public string modelo { get; set; }
        public int peso { get; set; }
        public int capacidad { get; set; }
        public int id_piloto { get; set; }
        public int id_hangares { get; set; }
       
    }
}