using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels.ValidationMessages
{
    public static class AccountMessages
    {
        public const string EmailRequired = "You must provide an email";
        public const string EmailAddress = "You must provide a properly formatted email address";
        public const string FirstNameRequired = "You must provide a first name";
        public const string LastNameRequired = "You must provide a last name";
        public const string PasswordRequired = "You must provide a password";
        public const string PasswordConfirmRequired = "You must provide a password confirmation";
        public const string BankAccountRequired = "You must provide a bank account number";
        public const string RoutingNumberRequired = "You must provide a routing number";
        public const string IdRequired = "You must provide a payment information id";
    }
}