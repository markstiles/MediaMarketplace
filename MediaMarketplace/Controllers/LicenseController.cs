using MediaMarketplace.Models;
using MediaMarketplace.Models.EntityModels;
using MediaMarketplace.Models.FormModels;
using MediaMarketplace.Models.FormModels.Attributes;
using MediaMarketplace.Models.ViewModels;
using MediaMarketplace.Services.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MediaMarketplace.Controllers
{
    public class LicenseController : Controller
    {
        #region Constructor 

        protected readonly IUserSessionService UserSession;
        protected readonly MediaMarketplaceEntities DbContext;

        public LicenseController(
            IUserSessionService userSession,
            MediaMarketplaceEntities dbContext)
        {
            UserSession = userSession;
            DbContext = dbContext;
            ViewData["LayoutViewModel"] = new LayoutViewModel(UserSession);
        }

        #endregion

        #region View Methods

        [CheckLogin]
        public ActionResult ManageLicense()
        {
            var user = UserSession.GetUser();
            var copyrightFiles = DbContext.copyrights
                .Where(a 
                    => a.copyright_user_id == user.user_id
                    && a.copyright_active == true)
                .ToList();
            var licenseFiles = DbContext.licenses
                .Where(a => a.copyright.copyright_user_id == user.user_id)
                .ToList();

            var model = new ManageLicenseViewModel
            {
                CopyrightFiles = copyrightFiles,
                LicenseFiles = licenseFiles
            };

            return View(model);
        }

        [CheckLogin]
        public ActionResult BuyLicense()
        {
            //TODO fill out with all copyright files to buy
            var model = new BuyLicenseViewModel
            {
                CopyrightFiles = new List<ListItem>
                {
                    new ListItem { Text="Fix Me", Value="Fix Me" },
                    new ListItem { Text="Database Lookup", Value="Database Lookup" }
                }
            };

            return View(model);
        }

        #endregion

        #region Post Methods

        [HttpPost]
        [ValidateForm]
        public ActionResult AddLicenseSubmit(AddLicenseFormModel form)
        {
            var user = UserSession.GetUser();
            var copyrightFile = DbContext.copyrights.FirstOrDefault(a
                => a.copyright_id == form.CopyrightId
                && a.copyright_user_id == user.user_id);

            if(copyrightFile == null)
                return Json(new { Succeeded = false, ErrorMessage = "Copyright file was not found" });

            var copyrightLicense = new license
            {
                license_copyright_id = form.CopyrightId,
                license_type = form.LicenseType,
                license_start_date = form.StartDate,
                license_end_date = form.EndDate,
                license_cost = form.LicenseCost,
            };

            DbContext.licenses.Add(copyrightLicense);
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
        public ActionResult BuyLicenseSubmit(BuyLicenseFormModel form)
        {
            /* TODO
            var user = UserSession.GetUser();
            var copyrightFile = DbContext.copyrights.FirstOrDefault(a
                => a.copyright_id == form.Id
                && a.copyright_user_id == user.user_id);

            if (copyrightFile == null)
                return Json(new { Succeeded = false, ErrorMessage = "The copyright file wasn't found" });

            var cSale = new copyright_sales
            {
                copyright_sale_copyright_id = form.Id,
                copyright_sale_sale_price = form.Amount,
                copyright_sale_create_date = DateTime.Now,
                copyright_sale_seller_id = user.user_id,
                copyright_sale_active = true,
            };
            DbContext.copyright_sales.Add(cSale);
            DbContext.SaveChanges();
            */
            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult DeleteLicenseSubmit(DeleteLicenseFormModel form)
        {
            var user = UserSession.GetUser();
            var licenseFile = DbContext.licenses.FirstOrDefault(a
                => a.license_id == form.LicenseId
                && a.copyright.copyright_user_id == user.user_id);

            DbContext.licenses.Remove(licenseFile);
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