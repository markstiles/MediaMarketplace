using MediaMarketplace.Models;
using MediaMarketplace.Models.FormModels;
using MediaMarketplace.Models.FormModels.Attributes;
using MediaMarketplace.Models.ViewModels;
using MediaMarketplace.Services.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediaMarketplace.Controllers
{
    public class CopyrightController : Controller
    {
        #region Constructor 

        protected readonly IStringService StringService;
        
        public CopyrightController(
            IStringService stringService)
        {
            StringService = stringService;
        }

        #endregion

        #region View Methods

        public ActionResult AddCopyright()
        {
            return View();
        }

        public ActionResult BuyCopyright()
        {
            var model = new BuyCopyrightViewModel();

            return View(model);
        }

        public ActionResult SellCopyright()
        {
            var model = new SellCopyrightViewModel();

            return View(model);
        }

        public ActionResult AddLicense()
        {
            var model = new AddLicenseViewModel();

            return View(model);
        }

        public ActionResult BuyLicense()
        {
            var model = new BuyLicenseViewModel();

            return View(model);
        }

        #endregion

        #region Post Methods

        [HttpPost]
        [ValidateForm]
        public ActionResult AddCopyrightSubmit(AddCopyrightFormModel form)
        {
            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult BuyCopyrightSubmit(BuyCopyrightFormModel form)
        {
            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult SellCopyrightSubmit(SellCopyrightFormModel form)
        {
            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult AddLicenseSubmit(SellLicenseFormModel form)
        {
            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult BuyLicenseSubmit(BuyLicenseFormModel form)
        {
            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }

        #endregion
    }
}