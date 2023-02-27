using MediaMarketplace.Models.FormModels;
using MediaMarketplace.Models.ViewModels;
using MediaMarketplace.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaMarketplace.Models;
using MediaMarketplace.Models.FormModels.Attributes;

namespace MediaMarketplace.Controllers
{
    public class AccountController : Controller
    {
        #region Constructor 

        public AccountController()
        {
            
        }

        #endregion

        #region View Methods

        public ActionResult RegisterLogin()
        {            
            return View();
        }

        public ActionResult UpdateAccountInfo()
        {
            var model = new AccountInfoViewModel
            {
                
            };

            return View(model);
        }
        
        public ActionResult AddPaymentInfo()
        {
            var model = new PaymentInfoViewModel
            {
                
            };

            return View(model);
        }

        public ActionResult ActivitySummary()
        {
            var model = new ActivitySummaryViewModel
            {
                
            };

            return View(model);
        }

        #endregion

        #region Post Methods

        [HttpPost]
        [ValidateForm]
        public ActionResult RegisterSubmit(RegisterFormModel form)
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
        public ActionResult LoginSubmit(LoginFormModel form)
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
        public ActionResult UpdateAccountInfoSubmit(AccountInfoFormModel form)
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
        public ActionResult AddPaymentInfoSubmit(PaymentInfoFormModel form)
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