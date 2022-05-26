using System.ComponentModel.DataAnnotations.Schema;

namespace CascadingApi.Models
{
    [Table("State")]
    public class State
    {
        public int Id {     get; set; } 
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
