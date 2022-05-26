using CascadingApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CascadingApi.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly CascadingContext _Context;

        public CityRepository(CascadingContext context)
        {
            _Context = context;
        }

        public async Task AddCity(City city)
        {
            await _Context.Database.ExecuteSqlRawAsync("SP_AddCity @StateId,@Name",
                 new SqlParameter("@StateId", city.StateId),
            new SqlParameter("@Name", city.Name));

        }

        public void DeleteCity(int id)
        {
            _Context.Database.ExecuteSqlRaw("SP_DeleteCity @Id",
                                     new SqlParameter("@Id", id));
        }

        public async Task<List<City>> GetCity()
        {
            try
            {
                string StoredProc = $"exec SP_GetCity";
                var cityData = await _Context.cities.FromSqlRaw(StoredProc).ToListAsync();

                return cityData;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<City>> CitySelectByStateId(int id)
        {
            try
            {
                string StoredProc = $"SP_CitySelectByCityId '{@id}'";

                var result = await _Context.cities.FromSqlRaw(StoredProc).ToListAsync();


                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<City> UpdateCity(City city)
        {
            var result = await _Context.cities.FirstOrDefaultAsync(x => x.Id == city.Id);

            if (result != null)
            {
                _Context.Database.ExecuteSqlRaw("SP_UpdateCity @Id,@Name,@StateId",
                                                  new SqlParameter("@Id", city.Id),
                                                  new SqlParameter("@Name", city.Name), new SqlParameter("@CountryId", city.StateId));
                return result;
            }
            return null;
        }
    }
}
