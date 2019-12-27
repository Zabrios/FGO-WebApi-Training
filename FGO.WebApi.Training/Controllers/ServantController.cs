using FGO.WebApi.Domain.Contracts.Services.Servant;
using FGO.WebApi.Domain.Entities;
using FGO.WebApi.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FGO.WebApi.Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServantController : ControllerBase
    {
        public readonly IServantService ServantService;
        public ServantController(IServantService servantService)
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
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Servants
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/Servants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> InsertServantAscensionImages(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var images = Directory.GetFiles("C:/Users/Temporal/Downloads", "europa*.jpg");
            var worked = await ServantService.InsertAscensionArtsForServant(id, images);
            if (worked)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("ascension/{id}/{stage}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAscensionArtFromServant(int id, int stage)
        {
            stage--;
            var ascension = await ServantService.GetAscensionArtFromServant(id);
            byte[] imageBytes = ascension.ElementAt(stage).Image;
            return File(imageBytes, "image/jpg");
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
