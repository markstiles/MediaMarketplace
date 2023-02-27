using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class AccountInfoFormModel
    {
        [Required(ErrorMessage = AccountMessages.EmailRequired)] 
        public string Email { get; set; }
        [Required(ErrorMessage = AccountMessages.FirstNameRequired)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = AccountMessages.LastNameRequired)]
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = AccountMessages.AddressRequired)]
        public string Address { get; set; }
        [Required(ErrorMessage = AccountMessages.RegionRequired)]
        public string Region { get; set; }
        [Required(ErrorMessage = AccountMessages.PostalCodeRequired)]
        public string PostalCode { get; set; }
    }
}