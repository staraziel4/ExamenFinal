using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Hangares
    {
        [Key]
        public int id_hangares { get; set; }
        public int capacidad { get; set; }
        public string localizacion { get; set; }
       
    }
}