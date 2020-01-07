using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGO.WebApi.Domain.Contracts.Services.Servant;
using FGO.WebApi.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FGO.WebApi.Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IServantService ServantService;
        public readonly IOptions<TokenDataModel> tokenOptions;
        public LoginController(IServantService servantService, IOptions<TokenDataModel> options)
        {
            ServantService = servantService;
            tokenOptions = options;
        }

        [HttpGet]
        [Route("echoping")]
        public IActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(LoginRequest login)
        {
            if(login == null)
            {
                return BadRequest();
            }

            //var servantController = new ServantController(ServantService);
            login.Role = "User";
            var tokenGen = new TokenGenerator(tokenOptions);
            var token = tokenGen.GenerateTokenJwt(login.Role);
            return Ok(token);
        }
    }
}