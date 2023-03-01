using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels.ValidationMessages
{
    public static class CopyrightMessages
    {
        public const string NameRequired = "You must provide a name";
        public const string FileRequired = "You must provide a file";
        public const string FileTypeRequired = "You must provide a file type";
        public const string CopyrightIdRequired = "You must provide a copyright id";
        public const string AmountRequired = "You must provide an amount";
        public const string CopyrightSaleIdRequired = "You must provide a copyright sale id";
        public const string PayInfoIdRequired = "You must provide a payment information id";
    }
}