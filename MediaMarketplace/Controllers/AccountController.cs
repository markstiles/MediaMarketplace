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
        protected readonly MediaMarketplaceEntities DbContext;

        public AccountController(
            IUserSessionService userSession,
            MediaMarketplaceEntities dbContext)
        {
            UserSession = userSession;
            DbContext = dbContext;
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
            return View();
        }

        [CheckLogin]
        public ActionResult ViewPaymentInfo()
        {
            var user = UserSession.GetUser();
            var paymentInfos = DbContext.payment_informations.Where(a => a.payment_information_user_id == user.user_id).ToList();
            var model = new PaymentInfoViewModel
            {
                PaymentInfos = paymentInfos
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
            var user = new user
            {
                user_first_name = form.FirstName,
                user_last_name = form.LastName,
                user_email = form.Email,
                user_business_name = form.BusinessName,
                user_password = form.Password,
                user_phone_number = form.PhoneNumber
            };
            user = DbContext.users.Add(user);
            DbContext.SaveChanges();

            var payInfo = new payment_informations
            {
                payment_information_user_id = user.user_id,
                payment_information_bank_account = form.BankAccount,
                payment_information_routing_number = form.RoutingNumber
            };
            DbContext.payment_informations.Add(payInfo);
            DbContext.SaveChanges();

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
            var user = DbContext.users.First(a => a.user_email == form.Email);

            if (user == null) return Json(new TransactionResult
            {
                Succeeded = false,
                ErrorMessage = string.Empty
            });

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
            var user = UserSession.GetUser();
            var payInfo = new payment_informations
            {
                payment_information_user_id = user.user_id,
                payment_information_bank_account = form.BankAccount,
                payment_information_routing_number = form.RoutingNumber
            };
            DbContext.payment_informations.Add(payInfo);
            DbContext.SaveChanges();

            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }
        
        [HttpPost]
        [ValidateForm]
        public ActionResult UpdatePaymentInfoSubmit(UpdatePaymentInfoFormModel form)
        {
            var user = UserSession.GetUser();
            var payInfo = DbContext.payment_informations.First(a
                => a.payment_information_user_id == user.user_id
                && a.payment_information_id == form.Id);
            payInfo.payment_information_bank_account = form.BankAccount;
            payInfo.payment_information_routing_number = form.RoutingNumber;
            DbContext.SaveChanges();

            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult DeletePaymentInfoSubmit(DeletePaymentInfoFormModel form)
        {
            var payInfo = DbContext.payment_informations.First(a => a.payment_information_id == form.Id);
            DbContext.payment_informations.Remove(payInfo);
            DbContext.SaveChanges();

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