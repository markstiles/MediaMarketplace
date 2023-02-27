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
using MediaMarketplace.Services.System;
using MediaMarketplace.Models.EntityModels;

namespace MediaMarketplace.Controllers
{
    public class AccountController : Controller
    {
        #region Constructor 

        protected readonly IUserSessionService UserSession;

        public AccountController(IUserSessionService userSession)
        {
            UserSession = userSession;
            ViewData["LayoutViewModel"] = new LayoutViewModel(UserSession);
        }

        #endregion

        #region View Methods

        public ActionResult RegisterLogin()
        {            
            return View();
        }

        [CheckLogin]
        public ActionResult UpdateAccountInfo()
        {
            var model = new AccountInfoViewModel
            {
                
            };

            return View(model);
        }

        [CheckLogin]
        public ActionResult AddPaymentInfo()
        {
            var model = new PaymentInfoViewModel
            {
                
            };

            return View(model);
        }

        public ActionResult Logout()
        {
            UserSession.ClearUser();
            
            return Redirect("/Home");
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
            //TODO lookup user and get id
            //dbcontext.Users.GetUser(form.email)

            var user = new UserEntityModel
            {
                Id = 1,
                Email = form.Email,
                FirstName = "Mike",
                LastName = "Rafone",
                BusinessName = "Melodic Music",
                PhoneNumber = "",
                Address = "123 Sound System Way",
                Region = "NY",
                PostalCode = "12345"
            };

            UserSession.StoreUser(user);

            var result = new
            {
                Succeeded = true,
                ErrorMessage = string.Empty,
                RedirectUrl = "/Home/Dashboard"
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