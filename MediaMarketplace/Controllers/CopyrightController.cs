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
    public class CopyrightController : Controller
    {
        #region Constructor 

        protected readonly IUserSessionService UserSession;
        protected readonly MediaMarketplaceEntities DbContext;

        public CopyrightController(
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
        public ActionResult ViewCopyrights()
        {
            var user = UserSession.GetUser();
            var copyrightFiles = DbContext.copyrights.Where(a => a.copyright_user_id == user.user_id).ToList();
            var model = new ViewCopyrightsViewModel
            {
                CopyrightFiles = copyrightFiles
            };

            return View(model);
        }

        [CheckLogin]
        public ActionResult AddCopyright()
        {
            return View();
        }

        [CheckLogin]
        public ActionResult BuyCopyright()
        {
            //TODO fill out with all copyright files to buy
            var model = new BuyCopyrightViewModel
            {
                CopyrightFiles = new List<ListItem>
                {
                    new ListItem { Text="Fix Me", Value="Fix Me" },
                    new ListItem { Text="Database Lookup", Value="Database Lookup" }
                }
            };

            return View(model);
        }

        [CheckLogin]
        public ActionResult SellCopyright()
        {
            var user = UserSession.GetUser();
            var copyrightFiles = DbContext.copyrights.Where(a 
                => a.copyright_user_id == user.user_id 
                && a.copyright_active
                && !a.copyright_sales.Any(b => b.copyright_sale_active))
                .ToList();
            var copyrightSales = DbContext.copyright_sales.Where(a
                => a.copyright_sale_seller_id == user.user_id
                && a.copyright_sale_active)
                .ToList();
            var model = new SellCopyrightViewModel
            {
                CopyrightFiles = copyrightFiles,
                CopyrightSales = copyrightSales
            };

            return View(model);
        }

        [CheckLogin]
        public ActionResult AddLicense()
        {
            //TODO fill out with all copyrights for this user
            var model = new AddLicenseViewModel
            {
                CopyrightFiles = new List<ListItem>
                {
                    new ListItem { Text="Fix Me", Value="Fix Me" },
                    new ListItem { Text="Database Lookup", Value="Database Lookup" }
                }
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
        public ActionResult AddCopyrightSubmit(AddCopyrightFormModel form)
        {
            if (form.File.ContentLength < 1)
                return Json(new { Succeeded = false, ErrorMessage = "file was empty" });

            var user = UserSession.GetUser();
            var userFolder = $"{Request.PhysicalApplicationPath}/uploads/{user.user_id}";
            if (!Directory.Exists(userFolder))
                Directory.CreateDirectory(userFolder);  

            var randomId = Guid.NewGuid();
            string fileExtension = Path.GetExtension(form.File.FileName);
            string virtualPath = Server.MapPath($"~/uploads/{user.user_id}/{randomId}{fileExtension}");
            form.File.SaveAs(virtualPath);
            string relativePath = $"/uploads/{user.user_id}/{randomId}{fileExtension}";

            var copyrightItem = new copyright
            {
                copyright_user_id = user.user_id,
                copyright_name = form.Name,
                copyright_file = relativePath,
                copyright_media_type = form.FileType,
                copyright_active = true,
            };
            DbContext.copyrights.Add(copyrightItem);
            DbContext.SaveChanges();

            return Json(new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            });
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult ReactivateCopyrightSubmit(ActivateCopyrightFormModel form)
        {
            var user = UserSession.GetUser();
            var copyrightFile = DbContext.copyrights.FirstOrDefault(a
                => a.copyright_id == form.Id
                && a.copyright_user_id == user.user_id);

            if (copyrightFile == null)
                return Json(new { Succeeded = false, ErrorMessage = "The copyright file wasn't found" });

            copyrightFile.copyright_active = true;
            DbContext.SaveChanges();

            return Json(new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            });
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult DeactivateCopyrightSubmit(ActivateCopyrightFormModel form)
        {
            var user = UserSession.GetUser();
            var copyrightFile = DbContext.copyrights.FirstOrDefault(a 
                => a.copyright_id == form.Id 
                && a.copyright_user_id == user.user_id);

            if (copyrightFile == null)
                return Json(new { Succeeded = false, ErrorMessage = "The copyright file wasn't found" });

            copyrightFile.copyright_active = false;
            DbContext.SaveChanges();

            return Json(new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            });
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

            var result = new TransactionResult
            {
                Succeeded = true,
                ErrorMessage = string.Empty
            };

            return Json(result);
        }

        [HttpPost]
        [ValidateForm]
        public ActionResult DeleteSellCopyrightSubmit(SellCopyrightFormModel form)
        {
            var user = UserSession.GetUser();
            var copyrightSale = DbContext.copyright_sales.FirstOrDefault(a
                => a.copyright_sale_id == form.Id
                && a.copyright_sale_seller_id == user.user_id);

            if (copyrightSale == null)
                return Json(new { Succeeded = false, ErrorMessage = "The copyright sale wasn't found" });

            DbContext.copyright_sales.Remove(copyrightSale);
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