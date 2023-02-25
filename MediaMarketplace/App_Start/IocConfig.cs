using MediaMarketplace.Services;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MediaMarketplace.Controllers;
using MediaMarketplace.Factories;
using MediaMarketplace.Services.Solr;
using MediaMarketplace.Services.System;
using MediaMarketplace.Services.Configuration;
using MediaMarketplace.Services.Crawling;
using MediaMarketplace.Services.Indexing;
using MediaMarketplace.Services.Jobs;

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
            services.AddTransient<ISolrApiService, SolrApiService>();
            services.AddTransient<IAzureApiService, AzureApiService>();
            services.AddSingleton<ISolrClient, SolrClient>();
            services.AddTransient<IConfigurationService, ConfigurationService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ICrawlingService, CrawlingService>();
            services.AddTransient<IStringService, StringService>();
            services.AddSingleton<IJobService, JobService>();

            //factories
            services.AddTransient<ISiteParserFactory, SiteParserFactory>();
        }
    }
}
