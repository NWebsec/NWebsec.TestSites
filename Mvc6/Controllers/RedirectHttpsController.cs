// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc;

namespace Mvc6.Controllers
{
    public class RedirectHttpsController : Controller
    {
        //TODO have a look at the new behaviour
        //[RequireHttps]
        public ActionResult DefaultHttpsAllowed()
        {
            var ub = new UriBuilder("https://" + Request.Host)
            {
                Port = 443,
                Path = Url.Action("Index", "Home"),
                Query = ""
            };
            return Redirect(ub.Uri.AbsoluteUri);
        }

        //[RequireHttps]
        public ActionResult DefaultHttpsDenied()
        {
            var ub = new UriBuilder("https://" + Request.Host)
            {
                Port = 443,
                Path = Url.Action("Index", "Home"),
                Query = ""
            };
            return Redirect(ub.Uri.AbsoluteUri);
        }

        public ActionResult CustomHttpsAllowed()
        {
            var ub = new UriBuilder("https://" + Request.Host)
            {
                Port = 4444,
                Path = Url.Action("Index", "Home"),
                Query = ""
            };
            return Redirect(ub.Uri.AbsoluteUri);
        }

        public ActionResult CustomHttpsDenied()
        {
            var ub = new UriBuilder("https://" + Request.Host)
            {
                Port = 4444,
                Path = Url.Action("Index", "Home"),
                Query = ""
            };
            return Redirect(ub.Uri.ToString());
        }

    }
}
