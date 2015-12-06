using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NWebsec.Middleware;

namespace Mvc6
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDeveloperExceptionPage();

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());
            app.UseStaticFiles();

            //app.Use(async (context, func) =>
            //{
            //    //var startswith = context.Request.Path.StartsWithSegments("/Hsts/Index", StringComparison.OrdinalIgnoreCase);
            //    //var equals = context.Request.Path.Equals("/Hsts/Index", StringComparison.OrdinalIgnoreCase);
            //    if (context.Request.Path.Value.Contains("NoHttpsOnly")) throw new Exception(context.Request.Path.Value);
            //    await func.Invoke();
            //});

            app.MapWithMvc("/RedirectHttps/DefaultHttpsAllowed", b => b.UseRedirectValidation(options => options.AllowSameHostRedirectsToHttps()));
            app.MapWithMvc("/RedirectHttps/CustomHttpsDisallowed", b => b.UseRedirectValidation(options => options.AllowSameHostRedirectsToHttps()));
            app.MapWithMvc("/RedirectHttps/CustomHttpsAllowed", b => b.UseRedirectValidation(options => options.AllowSameHostRedirectsToHttps(4444)));

            app.MapWithMvc("/Hsts/Index", b => b.UseHsts(options => options.MaxAge(days: 30).IncludeSubdomains()));
            app.MapWithMvc("/Hsts/NoHttpsOnly", b => b.UseHsts(options => options.MaxAge(days: 30).IncludeSubdomains().AllResponses()));
            app.MapWithMvc("/Hsts/UpgradeInsecureRequests", b => b.UseHsts(options => options.MaxAge(days: 30).UpgradeInsecureRequests()));

            app.MapWithMvc("/Hpkp/Index", b => b.UseHpkp(options =>
            {
                options.MaxAge(days: 30)
                    .IncludeSubdomains()
                    .PinCertificate("8f 43 28 8a d2 72 f3 10 3b 6f b1 42 84 85 ea 30 14 c0 bc fe", storeName: StoreName.Root)
                    .Sha256Pins("d6qzRu9zOECb90Uez27xWltNsj0e1Md7GkYYkVoZWmM=",
                        "E9CZ9INDbd+2eRQozYqqbQ2yXLVKB9+xcprMF+44U1g=");
            }));
            app.MapWithMvc("/Hpkp/NoHttpsOnly", b => b.UseHpkp(options =>
            {
                options.MaxAge(days: 30)
                    .IncludeSubdomains()
                    .AllResponses()
                    .Sha256Pins("d6qzRu9zOECb90Uez27xWltNsj0e1Md7GkYYkVoZWmM=",
                        "E9CZ9INDbd+2eRQozYqqbQ2yXLVKB9+xcprMF+44U1g=");
            }));

            app.MapWithMvc("/CspUpgradeInsecureRequests", b => b.UseCsp(options => options.UpgradeInsecureRequests()));

            app.MapWithMvc("/CspFullConfig", builder =>
             {
                 builder.UseCsp(opts =>
                 {
                     opts.BaseUris(o => o.CustomSources("https://w-w.üüüüüü.de/baseuri?p=a;b,"));
                     opts.ChildSources(o => o.CustomSources("childsrcconfig"));
                     opts.ConnectSources(o => o.CustomSources("connectsrcconfig"));
                     opts.DefaultSources(o => o.CustomSources("defaultsrcconfig"));
                     opts.FontSources(o => o.CustomSources("fontsrcconfig"));
                     opts.FormActions(o => o.CustomSources("formactionconfig"));
                     opts.FrameAncestors(o => o.CustomSources("frameancestorsconfig"));
                     opts.FrameSources(o => o.CustomSources("framesrcconfig"));
                     opts.ImageSources(o => o.CustomSources("imgsrcconfig"));
                     opts.MediaSources(o => o.CustomSources("mediasrcconfig"));
                     opts.ObjectSources(o => o.CustomSources("objectsrcconfig"));
                     opts.Sandbox(o => o.AllowForms().AllowPointerLock().AllowPopups().AllowSameOrigin().AllowScripts().AllowTopNavigation());
                     opts.ScriptSources(o => o.CustomSources("scriptsrcconfig"));
                     opts.StyleSources(o => o.CustomSources("stylesrcconfig"));
                     opts.ReportUris(o => o.Uris("/reporturi", "https://w-w.üüüüüü.de/réport?p=a;b,"));
                 });
             });

            app.MapWithMvc("/CspConfig", builder =>
            {
                builder.UseCsp(opts =>
                {
                    opts.DefaultSources(o => o.Self());
                    opts.ScriptSources(o => o.CustomSources("configscripthost"));
                    opts.MediaSources(o => o.CustomSources("fromconfig"));
                });
            });

            app.UseXContentTypeOptions();
            app.UseXDownloadOptions();
            app.UseXfo(options => options.SameOrigin());

            app.UseXRobotsTag(options => options.NoIndex().NoFollow());
            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseRedirectValidation(options => options.AllowedDestinations("https://www.nwebsec.com", "https://nwebsec.codeplex.com/path"));


            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void UseMvc(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
