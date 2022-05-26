using CascadingApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadingApi.Repository
{
    public class CountryRepository : ICountryRepository

    {
            private readonly CascadingContext _Context;

            public CountryRepository(CascadingContext context)
            {
                _Context = context;
            }

        public async Task AddCountry(Country country)
        {
            await _Context.Database.ExecuteSqlRawAsync("SP_AddCountry @Name,@Code",
                new SqlParameter("@Name", country.Name),
                new SqlParameter("@Code", country.Code));

        }

        public void DeleteCountry(int id)
        {
            _Context.Database.ExecuteSqlRaw("SP_DeleteCountry @Id",
                                   new SqlParameter("@Id", id));

            //var result = _Context.Countries.Where(x => x.Id == id).FirstOrDefault();
            //if (result != null)
            //{
            //    _Context.Countries.Remove(result);
            //    _Context.SaveChangesAsync();
            //}
        }

        public async Task<IEnumerable<Country>> GetCountry()
        {
            try
            {
                string StoredProc = $"exec SP_GetCountry";
                var countriesData = _Context.Countries.FromSqlRaw(StoredProc).ToList();

                return countriesData;

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            var result = await _Context.Countries.FirstOrDefaultAsync(x => x.Id == country.Id);

            if (result != null)
            {
                _Context.Database.ExecuteSqlRaw("SP_UpdateCountry @Id,@Name,@Code",
                                                  new SqlParameter("@Id", country.Id),
                                                  new SqlParameter("@Name", country.Name), new SqlParameter("@Code", country.Code));
                return result;
            }
            return null;
        }
    }
}
