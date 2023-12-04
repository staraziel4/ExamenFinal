using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Modelsss
{
    public class Piloto
    {
        [Key]
        public int id_piloto { get; set; }
        public string restricciones { get; set; }
        public int salario { get; set; }
        public string turno { get; set; }


    }
}
