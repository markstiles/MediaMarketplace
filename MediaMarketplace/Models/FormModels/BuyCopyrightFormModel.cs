using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class BuyCopyrightFormModel
    {
        [Required(ErrorMessage = CopyrightMessages.CopyrightSaleIdRequired)]
        public int CopyrightSaleId { get; set; }
        [Required(ErrorMessage = CopyrightMessages.PayInfoIdRequired)]
        public int PayInfoId { get; set; }
    }
}