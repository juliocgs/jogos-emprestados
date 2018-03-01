using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Application.Models
{
    public class UserViewModel
    {
        #region PROPERTIES
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo nome de usuário é obrigatório")]
        [MinLength(2)]
        [MaxLength(10)]
        [DisplayName("Nome de usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [MinLength(3)]
        [MaxLength(20)]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [DisplayName("Último acesso")]
        public DateTime? LastLogin { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [DisplayName("Data de registro")]
        public DateTime RegistrationDate { get; set; }
        #endregion

        #region CONSTRUCTORS
        public UserViewModel()
        {
        }

        public UserViewModel(Guid id, string userName, string password, DateTime? lastLogin, DateTime registrationDate)
        {
            Id = id;
            UserName = userName;
            Password = password;
            LastLogin = lastLogin;
            RegistrationDate = registrationDate;
        }
        #endregion
    }
}
