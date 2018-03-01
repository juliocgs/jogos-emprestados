using Domain.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class BorrowingViewModel
    {
        #region PROPERTIES
        [Key]
        public Guid Id { get; set; }

        public FriendViewModel Friend { get; set; }

        public GameViewModel Game { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [DisplayName("Data de empréstimo")]
        public DateTime BorrowedDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [DisplayName("Data de retorno")]
        public DateTime? ReturnDate { get; set; }

        [DisplayName("Data de registro")]
        public bool IsReturned
        {
            get { return ReturnDate.HasValue; }
            set { }
        }
        #endregion

        #region CONSTRUCTORS
        public BorrowingViewModel()
        {
        }

        public BorrowingViewModel(Guid id, FriendViewModel friend, GameViewModel game, DateTime borrowedDate, DateTime? returnDate)
        {
            Id = id;
            Friend = friend;
            Game = game;
            BorrowedDate = borrowedDate;
            ReturnDate = returnDate;
        }
        #endregion
    }
}
