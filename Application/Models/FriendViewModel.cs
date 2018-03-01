using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Models;
using Infra.Resources;

namespace Application.Models
{
    public class FriendViewModel
    {
        #region PROPERTIES
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = Messages.FRIEND_NAME_REQUIRED)]
        [MinLength(2)]
        [MaxLength(120)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [MinLength(1)]
        [MaxLength(120)]
        [DisplayName("Apelido")]
        public string NickName { get; set; }

        [MaxLength(150)]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        public double? PhoneNumber { get; set; }

        public IList<BorrowingViewModel> Borrowings { get; set; }
        #endregion

        #region CONSTRUCTORS
        public FriendViewModel()
        {
        }

        public FriendViewModel(Guid id, string name, string nickName, string email, double? phoneNumber, IList<BorrowingViewModel> borrowings)
        {
            Id = id;
            Name = name;
            NickName = nickName;
            Email = email;
            PhoneNumber = phoneNumber;
            Borrowings = borrowings;
        }
        #endregion
    }
}
