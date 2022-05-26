using Microsoft.EntityFrameworkCore;

namespace CascadingApi.Models
{
    public class CascadingContext: DbContext
    {
        public CascadingContext(DbContextOptions<CascadingContext>options)
                :base(options)
        { 
          
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> cities { get; set; }



    }
}
