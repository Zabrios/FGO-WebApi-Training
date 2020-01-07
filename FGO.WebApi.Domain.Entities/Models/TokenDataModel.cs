using System;
using System.Collections.Generic;
using System.Text;

namespace FGO.WebApi.Domain.Entities.Models
{
    public class TokenDataModel
    {
        public string JWT_SECRET_KEY { get; set; }
        public string JWT_AUDIENCE_TOKEN { get; set; }
        public string JWT_ISSUER_TOKEN { get; set; }
        public int JWT_EXPIRE_MINUTES { get; set; }
    }
}
