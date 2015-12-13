using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DbLayer.Models
{
    public class AbitInfoIdentityUser:IdentityUser
    {
        public DateTime? CreationTime { get; set; }
        public bool Banned { get; set; }
    }
}
