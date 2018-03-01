using Domain.Core.Models;
using System;

namespace Domain.Models
{
    public class Borrowing : Entity
    {
        public virtual Friend Friend { get; set; }
        public virtual Game Game { get; set; }
        public virtual DateTime BorrowedDate { get; set; }
        public virtual DateTime? ReturnDate { get; set; }

        public virtual bool IsReturned
        {
            get { return ReturnDate.HasValue; }
            set { }
        }
    }
}
