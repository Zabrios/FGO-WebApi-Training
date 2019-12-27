using FGO.WebApi.Domain.Contracts.Services.Servant;
using FGO.WebApi.Domain.Entities;
using FGO.WebApi.Domain.Entities.Models;
using FGO.WebApi.Infrastructure.Contracts;
using FGO.WebApi.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
