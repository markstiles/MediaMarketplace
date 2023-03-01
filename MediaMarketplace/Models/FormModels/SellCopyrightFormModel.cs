using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class SellCopyrightFormModel
    {
        [Required(ErrorMessage = CopyrightMessages.CopyrightIdRequired)]
        public int CopyrightId { get; set; }
        [Required(ErrorMessage = CopyrightMessages.AmountRequired)]
        public decimal Amount { get; set; }
    }
}