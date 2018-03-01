using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Infra.Resources;

namespace Application.Models
{
    public class GameViewModel
    {
        #region PROPERTIES
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = Messages.GAME_NAME_REQUIRED)]
        [MinLength(2)]
        [MaxLength(120)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [DisplayName("Data de registro")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Preço")]
        [RegularExpression(@"\d+(\,\d{1,2})?", ErrorMessage = "Preço Inválido")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C}")]
        public decimal? Price { get; set; }

        public IList<BorrowingViewModel> Borrowings { get; set; }

        #endregion

        #region CONSTRUCTORS
        public GameViewModel()
        {
        }

        public GameViewModel(Guid id, string name, DateTime registrationDate, decimal? price, IList<BorrowingViewModel> borrowings)
        {
            Id = id;
            Name = name;
            RegistrationDate = registrationDate;
            Price = price;
            Borrowings = borrowings;
        }
        #endregion
    }
}
