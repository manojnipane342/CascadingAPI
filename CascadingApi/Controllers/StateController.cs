using CascadingApi.Models;
using CascadingApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;




namespace CascadingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;
        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }


        [HttpGet]
        [Route("GetState")]
        public async Task<ActionResult> GetState()
        {
            try
            {
                return Ok(await _stateRepository.GetState());
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpGet]
        [Route("GetStatebycountryId")]
        public async Task<ActionResult> GetStatebycountryId(int CountryId)
        {
            try
            {
                return Ok(await _stateRepository.StateSelectByCountryId(CountryId));
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpDelete]
        [Route("DeleteState")]
        public ActionResult DeleteState(int id)
        {
            try
            {
                _stateRepository.DeleteState(id);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpPost]
        [Route("AddState")]
        public async Task<ActionResult> AddState(State state)
        {
            try
            {
                if (state == null)
                {
                    return BadRequest();
                }
                if (state.Id == 0)
                {
                    await _stateRepository.AddState(state);

                }
                return Ok();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("UpdateState")]
        public async Task<ActionResult> UpdateState(State state)
        {
            try
            {
                var result = await _stateRepository.UpdateState(state);
                return Ok(result);

            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }
}
