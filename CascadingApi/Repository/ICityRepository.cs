using CascadingApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CascadingApi.Repository
{
    public interface ICityRepository
    {
        Task<List<City>> GetCity();
        Task<List<City>> CitySelectByStateId(int id);
        Task AddCity(City city);
        Task<City> UpdateCity(City city);
        void DeleteCity(int id);
    }
}
