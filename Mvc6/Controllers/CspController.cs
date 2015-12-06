﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using NWebsec.Mvc.HttpHeaders.Csp;

namespace Mvc6.Controllers
{
    [Csp]
    [CspDefaultSrc(Self = true)]
    public class CspController : Controller
    {
        //
        // GET: /Csp/

        public ActionResult Index()
        {
            return View("Index");
        }

        [Csp(Enabled = false)]
        public ActionResult Disabled()
        {
            return View("Index");
        }

        public ActionResult Redirect()
        {
            return RedirectToAction("Index");
        }

    }
}
