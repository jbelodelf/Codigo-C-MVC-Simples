using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("TbAmigo")]
    public class AmigoEntity
    {
        [Key]
        public int IdAmigo { get; set; }
        public string Nome { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}