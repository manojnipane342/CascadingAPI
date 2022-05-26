using System.ComponentModel.DataAnnotations.Schema;

namespace CascadingApi.Models
{
    [Table("City")]
    public class City
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public int StateId { get; set; }


    }
}
