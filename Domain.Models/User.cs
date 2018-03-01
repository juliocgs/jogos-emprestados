using Domain.Core.Models;
using System;

namespace Domain.Models
{
    public class User : Entity
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime? LastLogin { get; set; }
        public virtual DateTime RegistrationDate { get; set; }
    }
}
