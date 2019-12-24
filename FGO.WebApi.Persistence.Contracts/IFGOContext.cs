using FGO.WebApi.Domain.Entities;
using FGO.WebApi.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FGO.WebApi.Persistence.Contracts
{
    public interface IFGOContext : IDBContext
    {
        DbSet<ServantBaseModel> Servants { get; set; }
    }
}
