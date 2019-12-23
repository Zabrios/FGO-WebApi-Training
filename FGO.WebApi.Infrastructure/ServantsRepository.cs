using FGO.WebApi.Domain.Entities;
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
        protected DbSet<ServantBaseModel> Servants;
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
    }
}
