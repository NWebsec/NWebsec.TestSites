using Microsoft.Owin;
using NWebsec.Owin;
using Owin;

[assembly: OwinStartup(typeof(Mvc5owin.Startup))]

namespace Mvc5owin
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            //app.UseHsts(WithHsts.MaxAge(days: 30).IncludeSubdomains());
            app.Map("/RedirectHttps/DefaultHttpsAllowed", b => b.UseRedirectValidation(options => options.AllowSameHostRedirectsToHttps()));
            app.Map("/RedirectHttps/CustomHttpsDisallowed", b => b.UseRedirectValidation(options => options.AllowSameHostRedirectsToHttps()));
            app.Map("/RedirectHttps/CustomHttpsAllowed", b => b.UseRedirectValidation(options => options.AllowSameHostRedirectsToHttps(4443)));

            app.Map("/Hsts/Index", b => b.UseHsts(options => options.MaxAge(days: 30).IncludeSubdomains()));
            app.Map("/Hsts/NoHttpsOnly", b => b.UseHsts(options => options.MaxAge(days: 30).IncludeSubdomains().AllResponses()));

            app.Map("/Hpkp/Index", b => b.UseHpkp(options =>
            {
                options.MaxAge(days: 30)
                    .IncludeSubdomains()
                    .Sha256Pins("d6qzRu9zOECb90Uez27xWltNsj0e1Md7GkYYkVoZWmM=",
                        "E9CZ9INDbd+2eRQozYqqbQ2yXLVKB9+xcprMF+44U1g=");
            }));
            app.Map("/Hpkp/NoHttpsOnly", b => b.UseHpkp(options =>
            {
                options.MaxAge(days: 30)
                    .IncludeSubdomains()
                    .AllResponses()
                    .Sha256Pins("d6qzRu9zOECb90Uez27xWltNsj0e1Md7GkYYkVoZWmM=",
                        "E9CZ9INDbd+2eRQozYqqbQ2yXLVKB9+xcprMF+44U1g=");
            }));

            app.UseRedirectValidation(options => options.AllowedDestinations("https://www.nwebsec.com", "https://nwebsec.codeplex.com/path"));
            app.UseXContentTypeOptions();
            app.UseXDownloadOptions();
            app.UseXfo(options => options.SameOrigin());

            app.UseXRobotsTag(options => options.NoIndex().NoFollow());
            app.UseXXssProtection(options => options.EnabledWithBlockMode());

            app.UseCsp(options => options
                .DefaultSources(s => s.Self())
                .ScriptSources(s => s.CustomSources("configscripthost"))
                .MediaSources(s => s.CustomSources("fromconfig"))
                );

            app.Map("/CspFullConfig",
                b => b.UseCsp(options => options
                    .BaseUris(s => s.CustomSources("https://w-w.üüüüüü.de/baseuri?p=a;b,"))
                    .ChildSources(s => s.CustomSources("childsrcconfig"))
                    .ConnectSources(s => s.CustomSources("connectsrcconfig"))
                    .DefaultSources(s => s.CustomSources("defaultsrcconfig"))
                    .FontSources(s => s.CustomSources("fontsrcconfig"))
                    .FormActions(s => s.CustomSources("formactionconfig"))
                    .FrameAncestors(s => s.CustomSources("frameancestorsconfig"))
                    .FrameSources(s => s.CustomSources("framesrcconfig"))
                    .ImageSources(s => s.CustomSources("imgsrcconfig"))
                    .MediaSources(s => s.CustomSources("mediasrcconfig"))
                    .ObjectSources(s => s.CustomSources("objectsrcconfig"))
                    .PluginTypes(s => s.MediaTypes("application/pdf"))
                    .Sandbox(s => s.AllowForms().AllowPointerLock().AllowPopups().AllowSameOrigin().AllowScripts().AllowTopNavigation())
                    .ScriptSources(s => s.CustomSources("scriptsrcconfig"))
                    .StyleSources(s => s.CustomSources("stylesrcconfig"))
                    .ReportUris(s => s.Uris("/reporturi", "https://w-w.üüüüüü.de/réport?p=a;b,"))
                    )
                );
        }
    }
}
