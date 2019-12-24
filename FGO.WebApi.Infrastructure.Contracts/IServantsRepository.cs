﻿using FGO.WebApi.Domain.Entities;
using FGO.WebApi.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FGO.WebApi.Infrastructure.Contracts
{
    public interface IServantsRepository
    {
        Task<IEnumerable<ServantBaseModel>> GetAllServants();
    }
}
