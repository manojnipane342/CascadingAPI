using CascadingApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CascadingApi.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly CascadingContext _Context;

        public StateRepository(CascadingContext context)
        {
            _Context = context;
        }

        public async Task AddState(State state)
        {
            await _Context.Database.ExecuteSqlRawAsync("SP_AddState @CountryId,@Name",
                 new SqlParameter("@CountryId", state.CountryId));
            new SqlParameter("@Name", state.Name);

        }

        public void DeleteState(int id)
        {
            _Context.Database.ExecuteSqlRaw("SP_DeleteState @Id",
                                     new SqlParameter("@Id", id));
        }

        public async Task<List<State>> GetState()
        {
            try
            {
                string StoredProc = $"exec SP_GetState";
                var stateData = await _Context.States.FromSqlRaw(StoredProc).ToListAsync();

                return stateData;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<State>> StateSelectByCountryId(int CountryId)
        {
            try
            {
                //string StoredProc = $"SP_StateSelectByCountryId @CountryId";
                string StoredProc = $"exec SP_StateSelectByCountryId '{@CountryId}'";


                var result = await _Context.States.FromSqlRaw(StoredProc).ToListAsync();


                return result;
            }
            catch (Exception ex)
            { 
                throw;
            }

        }

        public async Task<State> UpdateState(State state)
        {
            var result = await _Context.States.FirstOrDefaultAsync(x => x.Id == state.Id);

            if (result != null)
            {
                _Context.Database.ExecuteSqlRaw("SP_UpdateState @Id,@Name,@CountryId",
                                                  new SqlParameter("@Id", state.Id),
                                                  new SqlParameter("@Name", state.Name), new SqlParameter("@CountryId", state.CountryId));
                return result;
            }
            return null;
        }
    }
}
