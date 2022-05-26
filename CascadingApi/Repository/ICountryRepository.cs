using CascadingApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CascadingApi.Repository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountry();
        Task AddCountry(Country country);
        Task<Country> UpdateCountry(Country country);
        void DeleteCountry(int id );
    }
}
