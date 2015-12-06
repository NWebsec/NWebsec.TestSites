﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using NWebsec.Mvc.HttpHeaders;

namespace Mvc6.Controllers
{
    [XFrameOptions]
    public class XFrameOptionsController : Controller
    {
        //
        // GET: /XFrameOptions/

        public ActionResult Index()
        {
            return View("Index");
        }
        [XFrameOptions(Policy = XFrameOptionsPolicy.Disabled)]
        public ActionResult Disabled()
        {
            return View("Index");
        }

    }
}
