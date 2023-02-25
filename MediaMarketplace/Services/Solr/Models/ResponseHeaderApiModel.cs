using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Services.Solr.Models
{
    public class ResponseHeaderApiModel
    {
        public int status { get; set; }
        public int QTime { get; set; }
        public ParamsApiModel _params { get; set; }
    }
}