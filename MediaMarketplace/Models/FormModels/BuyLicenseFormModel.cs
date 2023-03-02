using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class BuyLicenseFormModel
    {
        [Required(ErrorMessage = LicenseMessages.LicenseIdRequired)]
        public int LicenseId { get; set; }
    }
}