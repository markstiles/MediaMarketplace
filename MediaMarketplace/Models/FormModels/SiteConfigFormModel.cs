using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class SiteConfigFormModel
    {
        [Required(ErrorMessage = SiteConfigMessages.SiteUrlRequired)]
        public string SiteUrl { get; set; }
        [Required(ErrorMessage = SiteConfigMessages.ParserRequired)]
        public string Parser { get; set; }
    }
}