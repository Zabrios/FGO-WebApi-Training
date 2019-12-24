using System;
using System.Collections.Generic;
using System.Text;

namespace FGO.WebApi.Domain.Entities.Models
{
    public class AliasModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public int ServantId { get; set; }
        public ServantBaseModel Servant { get; set; }
    }
}
