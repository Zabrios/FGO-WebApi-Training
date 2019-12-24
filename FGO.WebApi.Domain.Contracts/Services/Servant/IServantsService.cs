using FGO.WebApi.Domain.Entities;
using FGO.WebApi.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FGO.WebApi.Domain.Contracts.Services.Servant
{
    public interface IServantsService
    {
        Task<List<ServantBaseModel>> GetAllServants();
    }
}
