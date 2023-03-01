using MediaMarketplace.Models.FormModels.ValidationMessages;
using MediaMarketplace.Models.FormModels.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class AddLicenseFormModel
    {
        [Required(ErrorMessage = CopyrightMessages.CopyrightIdRequired)]
        public int CopyrightId { get; set; }
        [Required(ErrorMessage = LicenseMessages.LicenseTypeRequired)]
        public string LicenseType { get; set; }
        [ValidDate(ErrorMessage = LicenseMessages.ValidStartDate)]
        public DateTime StartDate { get; set; }
        [ValidDate(ErrorMessage = LicenseMessages.ValidEndDate)]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = LicenseMessages.LicenseCostRequired)]
        public decimal LicenseCost { get; set; }
    }
}