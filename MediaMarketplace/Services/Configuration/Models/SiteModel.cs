﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Services.Configuration.Models
{
    public class SiteModel
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Parser { get; set; }
    }
}