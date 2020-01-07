using System;

namespace FGO.WebApi.Domain.Entities.Models
{
    public class LoginRequest
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
    }
}
