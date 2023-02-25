using MediaMarketplace.Services.Configuration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<CrawlerModel> Crawlers { get; set; }
    }
}