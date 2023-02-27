using MediaMarketplace.Services;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MediaMarketplace.Controllers;
using MediaMarketplace.Services.System;

namespace MediaMarketplace
{
    public class IocConfig
    {
        public static void Configure(ServiceCollection services)
        {
            services.AddHttpClient();

            //controllers
            services.AddTransient<HomeController>();
            services.AddTransient<AccountController>();
            services.AddTransient<CopyrightController>();

            //services
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<ICacheService, CacheService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IStringService, StringService>();
            services.AddTransient<IUserSessionService, UserSessionService>();
        }
    }
}
