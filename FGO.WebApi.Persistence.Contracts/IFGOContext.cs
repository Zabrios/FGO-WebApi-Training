using FGO.WebApi.Domain.Entities;
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
