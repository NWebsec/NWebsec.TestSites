// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Builder;

namespace Mvc6
{
    public static class IAppbuilderExtensions
    {
        public static IApplicationBuilder MapWithMvc(this IApplicationBuilder app, string path, Action<IApplicationBuilder> configurer)
        {
            app.MapWhen(context => context.Request.Path.StartsWithSegments(path, StringComparison.OrdinalIgnoreCase),
                builder =>
                {
                    configurer(builder);
                    builder.UseMvc(routes =>
                    {
                        routes.MapRoute(
                            name: "default",
                            template: "{controller=Home}/{action=Index}/{id?}");
                    });
                });

            return app;
        }
    }
}