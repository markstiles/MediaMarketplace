using MediaMarketplace.Models.FormModels.Attributes;
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
        protected readonly IUserSessionService UserSession;
        
        public HomeController(IUserSessionService userSession)
        {
            UserSession = userSession;
            ViewData["LayoutViewModel"] = new LayoutViewModel(UserSession);            
        }

        public ActionResult Index()
        {
            return View();
        }

        [CheckLogin]
        public ActionResult Dashboard()
        {
            var model = new DashboardViewModel
            {
                
            };

            return View(model);
        }
    }
}
