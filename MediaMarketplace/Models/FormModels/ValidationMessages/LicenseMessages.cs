using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels.ValidationMessages
{
    public static class LicenseMessages
    {
        public const string LicenseTypeRequired = "You must provide a license type";
        public const string ValidStartDate = "You must provide a valid start date";
        public const string ValidEndDate = "You must provide a valid end date";
        public const string LicenseCostRequired = "You must provide a valid license cost";
        public const string LicenseIdRequired = "You must provide a license id";
    }
}