using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO.Compression;
using Newtonsoft.Json.Serialization;

namespace Aspose.Cells.Common.Config
{
    public static class ServiceCollectionExtension
    {
        public static void AddSharedConfigParams(this IServiceCollection services)
        {
            services.AddScoped<IStorageService>(f => new AwsStorageService(
                new AwsConfig
                {
                    RegionEndpoint = Configuration.RegionEndpoint,
                    ServiceUrl = Configuration.RegionEndpoint,
                    ForcePathStyle = true,
                    AccessKeyId = Configuration.AccessKeyId,
                    SecretAccessKey = Configuration.SecretAccessKey
                },
                Configuration.Bucket,
                f.GetService<ILogger<AwsStorageService>>()
            ));
            services.Configure<IISServerOptions>(options => { options.MaxRequestBodySize = ViewModel.MaximumUploadFileSize; });
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = ViewModel.MaximumUploadFileSize;
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });
            services.Configure<KestrelServerOptions>(options => { options.Limits.MaxRequestBodySize = ViewModel.MaximumUploadFileSize; });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.Configure<GzipCompressionProviderOptions>(options => { options.Level = CompressionLevel.Fastest; });
        }
    }
}