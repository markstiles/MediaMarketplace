using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class SolrConfigFormModel
    {
        [Required(ErrorMessage = ConfigMessages.SolrUrlRequired)]
        public string SolrUrl { get; set; }
        [Required(ErrorMessage = ConfigMessages.SolrCoreRequired)]
        public string SolrCore { get; set; }
    }
}