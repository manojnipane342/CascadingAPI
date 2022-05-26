using CascadingApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CascadingApi.Repository
{
    public interface IStateRepository
    {
        Task<List<State>> GetState();
        Task<List<State>> StateSelectByCountryId(int CountryId);
        Task AddState(State state);
        Task<State> UpdateState(State state);
        void DeleteState(int id);
    }
}
