using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class AzureConfigFormModel
    {
        [Required(ErrorMessage = ConfigMessages.AzureUrlRequired)]
        public string AzureUrl { get; set; }
        [Required(ErrorMessage = ConfigMessages.AzureCoreRequired)]
        public string AzureCore { get; set; }
        [Required(ErrorMessage = ConfigMessages.AzureApiKeyRequired)]
        public string AzureApiKey { get; set; }
    }
}