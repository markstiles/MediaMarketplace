using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using MediaMarketplace.Models.EntityModels;

namespace MediaMarketplace.Services.System
{
    public interface IUserSessionService
    {
        void StoreUser(UserEntityModel user);
        void ClearUser();
        bool IsLoggedIn();
        UserEntityModel GetUser();
    }

    public class UserSessionService : IUserSessionService
    {
        public string UserSessionKey = "user-profile";

        public void StoreUser(UserEntityModel user)
        {
            HttpContext.Current.Session.Add(UserSessionKey, user);
        }

        public void ClearUser()
        {
            HttpContext.Current.Session.Remove(UserSessionKey);
        }

        public UserEntityModel GetUser()
        {
            var user = (UserEntityModel)HttpContext.Current.Session[UserSessionKey];

            return user; 
        }

        public bool IsLoggedIn()
        {
            var user = (UserEntityModel)HttpContext.Current.Session[UserSessionKey];

            return user != null;
        }
    }
}