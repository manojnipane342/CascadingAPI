using CascadingApi.Models;
using CascadingApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CascadingApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        [Route("GetCountry")]
        public async Task<ActionResult> GetCountry()
        {
            try
            {
                return Ok(await _countryRepository.GetCountry());
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpDelete]
        [Route("DeleteCountry")]
        public ActionResult DeleteCountry(int id)
        {
            try
            {
                _countryRepository.DeleteCountry(id);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpPost]
        [Route("AddCountry")]
        public async Task<ActionResult> AddCountry(Country country)
        {
            try
            {
                if (country == null)
                {
                    return BadRequest();
                }
                if (country.Id == 0)
                {
                    await _countryRepository.AddCountry(country);

                }
                return Ok();

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("UpdateCountry")]

        public async Task<ActionResult> UpdateCountry(Country country)
        {
            try
            {
                var result = await _countryRepository.UpdateCountry(country);
                return Ok(result);

            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }
}
