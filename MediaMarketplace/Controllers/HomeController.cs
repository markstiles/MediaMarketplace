using MediaMarketplace.Models.ViewModels;
using MediaMarketplace.Services.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaMarketplace.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IStringService StringService;

        public HomeController(IStringService stringService)
        {
            StringService = stringService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            var model = new DashboardViewModel
            {
                
            };

            return View(model);
        }
    }
}
