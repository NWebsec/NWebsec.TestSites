﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Web.Mvc;
using NWebsec.Mvc.HttpHeaders;

namespace Mvc5owin.Controllers
{
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
