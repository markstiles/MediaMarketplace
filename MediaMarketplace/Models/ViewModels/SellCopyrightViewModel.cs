using MediaMarketplace.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MediaMarketplace.Models.ViewModels
{
    public class SellCopyrightViewModel
    {
        public List<copyright> CopyrightFiles { get; set; }
        public List<copyright_sales> CopyrightSales { get; set; }
    }
}