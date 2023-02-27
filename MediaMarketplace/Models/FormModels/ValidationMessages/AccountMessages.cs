using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels.ValidationMessages
{
    public static class AccountMessages
    {
        public const string EmailRequired = "You must provide an email";
        public const string FirstNameRequired = "You must provide a first name";
        public const string LastNameRequired = "You must provide a last name";
        public const string AddressRequired = "You must provide an address";
        public const string RegionRequired = "You must provide a region";
        public const string PostalCodeRequired = "You must provide a postal code";
        public const string PasswordRequired = "You must provide a password";
    }
}