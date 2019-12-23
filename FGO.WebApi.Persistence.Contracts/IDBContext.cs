using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FGO.WebApi.Persistence.Contracts
{
    public interface IDBContext
    {
        DbContext Instance { get; }
    }
}
