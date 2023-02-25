﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Services.Solr.Models
{
    public class SolrDocumentApiModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public string updated { get; set; }
    }
}