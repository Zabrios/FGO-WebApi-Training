using FGO.WebApi.Domain.Contracts.Services.Servant;
using FGO.WebApi.Domain.Entities.Models;
using FGO.WebApi.Persistence.Contracts.Repositories;
using FGO.WebApi.Persistence.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FGO.WebApi.Domain.Services.Servant
{
    public class ServantsService : IServantService
    {
        protected readonly IUnitOfWork UnitOfWork;
        public IServantsRepository ServantsRepository;
        public ServantsService(IUnitOfWork unitOfWork, IServantsRepository servantsRepository)
        {
            UnitOfWork = unitOfWork;
            ServantsRepository = servantsRepository;
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<ServantBaseModel>> GetAllServants()
        {
            var servants = await ServantsRepository.GetAllServants();
            return servants.ToList();

        }

        public async Task<bool> InsertAscensionArtsForServant(int servantId, string[] images)
        {            
            if(images != null)
            {
                List<byte[]> imagesBytes = new List<byte[]>();
                using (var memoryStream = new MemoryStream())
                {
                    foreach(var img in images)
                    {
                        var _img = File.ReadAllBytes(img);
                        imagesBytes.Add(_img);
                    }
                }
                return await ServantsRepository.InsertAscensionArts(servantId, imagesBytes);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<AscensionModel>> GetAscensionArtFromServant(int id)
        {
            return await ServantsRepository.GetAscensionArtFromServant(id);
        }

        public async Task<List<ServantBaseModel>> GetAllServantsByClass(string servantClass)
        {
            if(string.IsNullOrWhiteSpace(servantClass) || servantClass == "all")
            {
                var servants = await ServantsRepository.GetAllServants();
                return servants.ToList();
            }
            else
            {
                var servants = await ServantsRepository.GetAllServantsByClass(servantClass);
                return servants.ToList();
            }
        }
    }
}
