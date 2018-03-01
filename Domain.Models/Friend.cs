using Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Friend : Entity
    {
        public virtual string Name { get; set; }
        public virtual string NickName { get; set; }
        public virtual string Email { get; set; }
        public virtual double? PhoneNumber { get; set; }
        public virtual IList<Borrowing> Borrowings { get; set; }
    }
}
