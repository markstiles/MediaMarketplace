using MediaMarketplace.Models.FormModels.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.FormModels
{
    public class DeletePaymentInfoFormModel
    {
        [Required(ErrorMessage = AccountMessages.IdRequired)]
        public int Id { get; set; }
    }
}