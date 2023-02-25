using MediaMarketplace.Models.FormModels.Attributes;
using MediaMarketplace.Services;
using System.Web;
using System.Web.Mvc;

namespace MediaMarketplace
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TransactionError());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
