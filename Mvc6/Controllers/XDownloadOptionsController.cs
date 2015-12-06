﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using NWebsec.Mvc.HttpHeaders;

namespace Mvc6.Controllers
{
    [XDownloadOptions]
    public class XDownloadOptionsController : Controller
    {
        //
        // GET: /XDownloadOptions/

        public ActionResult Index()
        {
            return View("Index");
        }

        [XDownloadOptions(Enabled = false)]
        public ActionResult Disabled()
        {
            return View("Index");
        }

    }
}
