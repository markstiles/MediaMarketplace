using MediaMarketplace.Models.FormModels.ValidationMessages;
using MediaMarketplace.Models.FormModels.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class CrawlConfigFormModel
    {
        [Required(ErrorMessage = CrawlConfigMessages.CrawlNameRequired)]
        public string CrawlerName { get; set; }
        [Required(ErrorMessage = CrawlConfigMessages.SolrConnectionRequired)]
        public string Connection { get; set; }
        public List<Guid> Sites { get; set; }
    }
}