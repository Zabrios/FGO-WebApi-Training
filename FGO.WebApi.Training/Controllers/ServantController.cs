using FGO.WebApi.Domain.Contracts.Services.Servant;
using FGO.WebApi.Domain.Entities;
using FGO.WebApi.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        // GET: api/Servant
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

        // GET: api/Servant/5
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

        /// <summary>
        /// Do not use this function. Only use in dev-mode for inserting images and knowing full well what to do with it.
        /// Reads from a folder call "assets" (located wherever you want) and inside of it there are several folders named after the servant id, with the images of the ascension inside those folders
        /// WARNING: STILL DOES NOT CHECK IF IMAGE/SERVANT IS ALREADY IN THE DATABASE. CAUTION
        /// </summary>
        /// <returns></returns>
        // PUT: api/Servant/5
        [HttpPut]
        public async Task<IActionResult> InsertServantAscensionImages()
        {
            bool worked = false;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            DirectoryInfo directoryInfo = new DirectoryInfo("C:/Users/Temporal/Downloads/assets");
            foreach (DirectoryInfo d in directoryInfo.GetDirectories())
            {
                var files = d.GetFiles("*.jpg");
                string[] fileList = files.Select(f => f.FullName).ToArray();
                worked = await ServantService.InsertAscensionArtsForServant(Convert.ToInt32(d.Name), fileList);

            }
            if (worked)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("ascension/{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAscensionArtFromServant(int id)
        {
            var ascension = await ServantService.GetAscensionArtFromServant(id);
            List<string> images = new List<string>();
            if(ascension.Count() > 0)
            {
                try
                {
                    foreach (var art in ascension)
                    {
                        images.Add(Convert.ToBase64String(art.Image));
                    }
                    return Ok(images);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                return Ok(null);
            }
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
