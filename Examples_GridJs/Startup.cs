using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.GridJs;
using Aspose.Cells.GridJsDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gridjs_demo_.netcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });
            
            services.AddResponseCompression(options =>
            {
                IEnumerable<string> MimeTypes = new[]
                {
         // General
         "text/plain",
         "text/html",
         "text/css",
         "text/json",
         "font/woff2",
         "application/javascript",
         "image/x-icon",
         "image/png"
     };

                options.EnableForHttps = true;
                options.MimeTypes = MimeTypes;
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<BrotliCompressionProvider>();
            });
            //start here，setlicense,use cells.license ,GridJs does not provide single license entry ,GridJs use  Aspose.Cells API, you need to set license for Aspose.Cells API
            string licenseFilePath = "/app/license";
            Aspose.Cells.License l = new Aspose.Cells.License();
            if(File.Exists(licenseFilePath))
            {
                l.SetLicense(licenseFilePath);
                Console.WriteLine("set license successfully");
            }
            //add GridJsService 
            services.AddScoped<IGridJsService, GridJsService>();
            //set load options for GridJsService
            services.Configure<GridJsOptions>(options =>
            {
                options.LazyLoading = true;
                options.FileCacheDirectory = TestConfig.TempDir;

                    
                //options.CacheImp = YourCustomCacheImpl;
                //options.BaseRouteName = "/YourControllerRouteNameForGridJsRestAPI";
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
           
            app.UseCookiePolicy();
            app.UseResponseCompression();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            

        }
    }
}
