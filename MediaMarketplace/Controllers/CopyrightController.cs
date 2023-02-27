﻿using MediaMarketplace.Models;
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
            //fill out with all copyright files to buy
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

        public ActionResult SellCopyright()
        {
            //fill out with all copyrights for this user
            var model = new SellCopyrightViewModel
            {
                CopyrightFiles = new List<ListItem>
                {
                    new ListItem { Text="Fix Me", Value="Fix Me" },
                    new ListItem { Text="Database Lookup", Value="Database Lookup" }
                }
            };

            return View(model);
        }

        public ActionResult AddLicense()
        {
            //fill out with all copyrights for this user
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

        public ActionResult BuyLicense()
        {
            //fill out with all copyright files to buy
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
            try
            {
                if (form.File.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(form.File.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    form.File.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }

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