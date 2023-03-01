using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.ViewModels
{
    public class FormDateViewModel
    {
        public string CssClass { get; set; }
        public string LabelText { get; set; }
        public string DefaultValue { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
    }
}