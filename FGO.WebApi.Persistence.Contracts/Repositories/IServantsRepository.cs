using FGO.WebApi.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FGO.WebApi.Persistence.Contracts.Repositories
{
    public interface IServantsRepository
    {
        Task<IEnumerable<ServantBaseModel>> GetAllServants();
        Task<IEnumerable<ServantBaseModel>> GetAllServantsByClass(string servantClass);
        Task<bool> InsertAscensionArts(int servantId, List<byte[]> artToUpload);
        Task<IEnumerable<AscensionModel>> GetAscensionArtFromServant(int servantId);
    }
}
