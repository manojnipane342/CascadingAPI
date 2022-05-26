
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadingApi.Models
{
    [Table("Country")]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
