using System.IO;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Editor.Controllers;
using Elastic.Apm.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Aspose.Cells.Editor
{
    public class Startup
    {
        private static readonly AppNames appName = AppNames.Editor;

        internal static string AppName => appName.ToString();

        public Startup(IConfiguration configuration)
        {
            AppConfiguration = configuration;
            Configuration.IsProduction = configuration["ASPNETCORE_ENVIRONMENT"] == "Production";
            Configuration.FontFolderPath = configuration["FontFolderPath"];

            Configuration.RegionEndpoint = configuration["RegionEndpoint"];
            Configuration.Bucket = configuration["Bucket"];
            Configuration.AccessKeyId = configuration["AccessKeyId"];
            Configuration.SecretAccessKey = configuration["SecretAccessKey"];

            Configuration.MailServerPort = int.Parse(configuration["MailServerPort"]);
            Configuration.MailServer = configuration["MailServer"];
            Configuration.MailServerUserId = configuration["MailServerUserId"];
            Configuration.MailServerUserPassword = configuration["MailServerPassword"];
            Configuration.MailServerTimeOut = int.Parse(configuration["SmtpTimeOut"]);

            Configuration.ForumKey = configuration["ForumKey"];
            Configuration.ForumUrl = configuration["ForumUrl"];
            Configuration.ForumCategoryId = configuration["ForumCategoryId"];
        }

        private IConfiguration AppConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICellsController, EditorController>();

            Common.Models.License.SetCellsLicense();
            FontConfigs.SetFontFolder(Configuration.FontFolderPath, true);

            // Set GridJs license & font folder
            Common.Models.License.SetGridJsLicense();
            GridJs.Config.SetFontFolder(Configuration.FontFolderPath, true);

            services.AddSharedConfigParams();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.Use((context, next) =>
            {
                context.Request.EnableBuffering();
                return next();
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseElasticApm(AppConfiguration);
            }

            if (!env.ContentRootPath.Contains("Aspose.Cells.Common.Tests") && env.IsProduction())
            {
                app.UseSerilogRequestLogging();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            string staticResources;
            logger.LogInformation("ContentRootPath: {ContentRootPath}", env.ContentRootPath);
            if (env.ContentRootPath.EndsWith("app"))
                //for windows docker
                staticResources = Path.GetFullPath("./resources");
            else if (env.ContentRootPath.EndsWith("Common"))
                //for Common test execute
                staticResources = Path.Combine(env.ContentRootPath, "../apps/Aspose.Cells.Common/resources");
            else if (env.ContentRootPath.Contains("Aspose.Cells.Common.Tests"))
                staticResources = Path.Combine(env.ContentRootPath, "../../../../../apps/Aspose.Cells.Common/resources");
            else
                //for this app runtime
                staticResources = Path.GetFullPath("../Aspose.Cells.Common/resources");

            var options = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticResources),
                RequestPath = "/cells/" + appName.ToRouteName() + "/content",
                // Unlimited content-type download
                ServeUnknownFileTypes = true
            };
            //This is required for asp-append-version
            env.WebRootFileProvider = new CompositeFileWithOptionsProvider(env.WebRootFileProvider, options);
            app.UseStaticFiles(options);

            app.UseEndpoints(endpoints => { endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Healthy"); }); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(AppName, "cells/" + AppName + "/{fileformat}",
                    new {controller = AppName, action = AppName, fileformat = ""});
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(AppName, "cells/" + AppName + "/edit",
                    new {controller = AppName, action = "Edit"});
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("EditorApi", "cells/" + AppName + "/api/EditorApi/{action}",
                    new {controller = "EditorApi", action = AppName});
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("UploadFile", "cells/" + AppName + "/api/Common/{action}/{id}",
                    new {controller = "Common", action = "UploadFile", id = ""});
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Feedback", "cells/" + AppName + "/sendfeedback",
                    new {controller = AppName, action = "SendFeedback"});
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Feedback", "cells/" + AppName + "/sendemail",
                    new {controller = AppName, action = "SendEmail"});
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Report", "cells/" + AppName + "/api/Report/Error",
                    new {controller = "Report", action = "Error"});
            });
        }
    }
}