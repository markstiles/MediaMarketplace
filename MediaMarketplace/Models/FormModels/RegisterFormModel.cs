using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = AccountMessages.EmailRequired)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = AccountMessages.PasswordRequired)]
        public string Password { get; set; }
        [Required(ErrorMessage = AccountMessages.PasswordConfirmRequired)]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = AccountMessages.FirstNameRequired)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = AccountMessages.LastNameRequired)]
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        [Required(ErrorMessage = AccountMessages.BankAccountRequired)]
        public string BankAccount { get; set; }
        [Required(ErrorMessage = AccountMessages.RoutingNumberRequired)]
        public string RoutingNumber{ get; set; }
    }
}