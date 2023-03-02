using MediaMarketplace.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<license_sales> LicensesPurchased { get; set; }
        public List<copyright> AllMyCopyrights { get; set; }
        public List<copyright_sales> CopyrightsPurchased { get; set; }
        public List<copyright_sales> CopyrightsSold { get; set; }
    }
}