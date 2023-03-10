using MediaMarketplace.Services.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaMarketplace.Models.ViewModels
{
    public class LayoutViewModel
    {
        protected IUserSessionService UserSession;
        public LayoutViewModel(IUserSessionService userSession)
        {
            UserSession = userSession;
            var user = UserSession.GetUser();
            UserName = user == null ? "" : $"{user.user_first_name} {user.user_last_name}";
        }

        public bool IsUserLoggedIn => UserSession.IsLoggedIn();
        public string UserName { get; set; }
    }
}