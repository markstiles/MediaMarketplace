using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MediaMarketplace.Models.ViewModels
{
    public class FormRadioListViewModel
    {
        public string CssClass { get; set; }
        public string LabelText { get; set; }
        public List<ListItem> ListItems { get; set; }
    }
}