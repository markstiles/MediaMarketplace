using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class AddCopyrightFormModel
    {
        [Required(ErrorMessage = CopyrightMessages.FileRequired)]
        public HttpPostedFileBase File { get; set; }
        [Required(ErrorMessage = CopyrightMessages.FileTypeRequired)]
        public string FileType { get; set; }
    }
}