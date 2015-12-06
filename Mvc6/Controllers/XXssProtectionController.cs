﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using NWebsec.Mvc.HttpHeaders;

namespace Mvc6.Controllers
{
    [XXssProtection]
    public class XXssProtectionController : Controller
    {
        //
        // GET: /XXssProtection/

        public ActionResult Index()
        {
            return View("Index");
        }

        [XXssProtection(Policy = XXssProtectionPolicy.Disabled)]
        public ActionResult Disabled()
        {
            return View("Index");
        }
    }
}
