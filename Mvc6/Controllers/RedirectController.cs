// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc;

namespace Mvc6.Controllers
{
    public class RedirectController : Controller
    {
        //
        // GET: /Redirect/

        public ActionResult Relative()
        {
            return Redirect("/");
        }

        public ActionResult SameSite()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult WhitelistedSite()
        {
            return Redirect("https://www.nwebsec.com/");
        }

        public ActionResult DangerousSite()
        {
            return Redirect("http://www.unexpectedsite.com/");
        }

        public ActionResult ValidationDisabledDangerousSite()
        {
            return Redirect("http://www.unexpectedsite.com/");
        }

    }
}
