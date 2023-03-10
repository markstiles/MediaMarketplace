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
        public ActionResult Dashboard()
        {
            var user = UserSession.GetUser();
            var licensesPurchased = DbContext.license_sales
                .Where(a => a.license_sale_buyer_id == user.user_id)
                .ToList();
            var copyrightSales = DbContext.copyright_sales.Where(a 
                => a.copyright_sale_buyer_id == user.user_id 
                || a.copyright_sale_seller_id == user.user_id);
            var copyrights = DbContext.copyrights.Where(a => a.copyright_user_id == user.user_id).ToList();
            
            var model = new DashboardViewModel
            {
                LicensesPurchased = licensesPurchased,
                AllMyCopyrights = copyrights,
                CopyrightsPurchased = copyrightSales.Where(a => a.copyright_sale_buyer_id == user.user_id).ToList(),
                CopyrightsSold = copyrightSales.Where(a => a.copyright_sale_seller_id == user.user_id).ToList()
            };

            return View(model);
        }

        [CheckLogin]
        public ActionResult UpdateAccountInfo()
        {
            var user = UserSession.GetUser();
            var model = new AccountInfoViewModel
            {
                Profile = user   
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
            if (form.Password != form.PasswordConfirm)
                return Json(new { Succeeded = false, ErrorMessage = "The password must match the password confirm" });

            DbContext.p_create_user_and_payment_info(
                form.FirstName,
                form.LastName,
                form.Email,
                form.BusinessName,
                form.Password,
                form.PhoneNumber,
                form.BankAccount,
                form.RoutingNumber);

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
            var user = DbContext.users.FirstOrDefault(a => a.user_email == form.Email && a.user_password == form.Password);

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
                RedirectUrl = "/Account/Dashboard"
            };

            return Json(result);
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult UpdateAccountInfoSubmit(AccountInfoFormModel form)
        {
            var user_id = UserSession.GetUser().user_id;
            var user = DbContext.users.FirstOrDefault(a => a.user_id == user_id);
            if(user == null) return Json(new TransactionResult
            {
                Succeeded = false,
                ErrorMessage = "user not found"
            });

            if (form.Password != form.PasswordConfirm) return Json(new TransactionResult
            {
                Succeeded = false,
                ErrorMessage = "The password doesn't match the confirm password"
            });

            user.user_first_name = form.FirstName;
            user.user_last_name = form.LastName;
            user.user_email = form.Email;
            user.user_business_name = form.BusinessName;
            if(!string.IsNullOrWhiteSpace(form.Password))
                user.user_password = form.Password;
            user.user_phone_number = form.PhoneNumber;
            DbContext.SaveChanges();

            UserSession.StoreUser(user);

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
            var payInfo = DbContext.payment_informations.FirstOrDefault(a
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
            var payInfo = DbContext.payment_informations.FirstOrDefault(a => a.payment_information_id == form.Id);
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