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
        void StoreUser(user user);
        void ClearUser();
        bool IsLoggedIn();
        user GetUser();
    }

    public class UserSessionService : IUserSessionService
    {
        public string UserSessionKey = "user-profile";

        public void StoreUser(user user)
        {
            HttpContext.Current.Session.Add(UserSessionKey, user);
        }

        public void ClearUser()
        {
            HttpContext.Current.Session.Remove(UserSessionKey);
        }

        public user GetUser()
        {
            var user = (user)HttpContext.Current.Session[UserSessionKey];

            return user; 
        }

        public bool IsLoggedIn()
        {
            var user = (user)HttpContext.Current.Session[UserSessionKey];

            return user != null;
        }
    }
}