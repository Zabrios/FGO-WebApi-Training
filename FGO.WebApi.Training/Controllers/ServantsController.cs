using FGO.WebApi.Domain.Contracts.Services.Servant;
using FGO.WebApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FGO.WebApi.Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServantsController : ControllerBase
    {
        public readonly IServantsService ServantService;
        public ServantsController(IServantsService servantService)
        {
            ServantService = servantService;
        }

        // GET: api/Servants
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json", Type = typeof(List<ServantBaseModel>))]
        public async Task<IActionResult> GetAllServantsAsync()
        {
            try
            {
                var servants = await ServantService.GetAllServants();
                return Ok(servants);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        // GET: api/Servants/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Servants
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Servants/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
