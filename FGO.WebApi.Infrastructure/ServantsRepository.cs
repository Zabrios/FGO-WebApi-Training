using FGO.WebApi.Domain.Entities;
using FGO.WebApi.Domain.Entities.Models;
using FGO.WebApi.Infrastructure.Contracts;
using FGO.WebApi.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGO.WebApi.Infrastructure
{
    public class ServantsRepository : IServantsRepository
    {
        protected readonly IFGOContext Context;
        public ServantsRepository(IFGOContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ServantsRepository()
        {
        }

        public async Task<IEnumerable<ServantBaseModel>> GetAllServants()
        {
            return await Context.Servants.ToListAsync();
        }

        public async Task<ServantBaseModel> GetServantById(int id)
        {
            return await Context.Servants.FindAsync(id);
        }
        
        // Cambiar esto para el AscensionRepository cuando se cree
        public async Task<bool> InsertAscensionArts(int servantId, List<byte[]> artToUpload)
        {

            foreach (var art in artToUpload)
            {
                Context.Ascensions.Add(new AscensionModel { Image = art, ServantId = servantId });
                await Context.Instance.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<AscensionModel>> GetAscensionArtFromServant(int servantId)
        {
            return await Context.Ascensions.Where(x => x.ServantId == servantId).ToListAsync();
            //return await Context.Ascensions.FirstOrDefaultAsync(x => x.ServantId == servantId);
        }
    }
}
