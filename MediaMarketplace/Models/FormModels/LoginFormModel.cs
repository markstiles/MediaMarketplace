using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = AccountMessages.EmailRequired)]
        public string Email { get; set; }
        [Required(ErrorMessage = AccountMessages.PasswordRequired)]
        public string Password { get; set; }
    }
}