﻿using FGO.WebApi.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FGO.WebApi.Persistence.Contracts.Repositories
{
    public interface IServantsRepository
    {
        Task<IEnumerable<ServantBaseModel>> GetAllServants();
        Task<bool> InsertAscensionArts(int servantId, List<byte[]> artToUpload);
        Task<IEnumerable<AscensionModel>> GetAscensionArtFromServant(int servantId);
    }
}