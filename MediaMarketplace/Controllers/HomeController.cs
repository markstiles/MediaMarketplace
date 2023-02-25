using MediaMarketplace.Models.ViewModels;
using MediaMarketplace.Services.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaMarketplace.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IConfigurationService ConfigurationService;

        public HomeController(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var model = new HomeViewModel
            {
                Crawlers = ConfigurationService.GetCrawlers()
            };

            return View(model);
        }

        public ActionResult Dashboard()
        {
            ViewBag.Title = "Home Page";

            var model = new HomeViewModel
            {
                Crawlers = ConfigurationService.GetCrawlers()
            };

            return View(model);
        }
    }
}
