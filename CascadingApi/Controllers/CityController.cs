using CascadingApi.Repository;
using CascadingApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CascadingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        [HttpGet]
        [Route("GetGetCity")]
        public async Task<ActionResult> GetCity()
        {
            try
            {
                return Ok(await _cityRepository.GetCity());
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpGet]
        [Route("GetGetCitybyStateId")]
        public async Task<ActionResult> GetGetCitybyStateId(int id)
        {
            try
            {
                return Ok(await _cityRepository.CitySelectByStateId(id));
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpDelete]
        [Route("DeleteCity")]
        public ActionResult DeleteCity(int id)
        {
            try
            {
                _cityRepository.DeleteCity(id);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpPost]
        [Route("AddCity")]
        public async Task<ActionResult> AddCity(City city)
        {
            try
            {
                if (city == null)
                {
                    return BadRequest();
                }
                if (city.Id == 0)
                {
                    await _cityRepository.AddCity(city);

                }
                return Ok();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("UpdateCity")]
        public async Task<ActionResult> UpdateCity(City city)
        {
            try
            {
                var result = await _cityRepository.UpdateCity(city);
                return Ok(result);

            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}
