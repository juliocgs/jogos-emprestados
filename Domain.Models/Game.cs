using Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Game : Entity
    {
        public virtual string Name { get; set; }
        public virtual DateTime RegistrationDate { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual IList<Borrowing> Borrowings { get; set; }
    }
}
