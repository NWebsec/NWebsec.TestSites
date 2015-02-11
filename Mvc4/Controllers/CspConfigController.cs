﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Web.Mvc;
using NWebsec.Mvc.HttpHeaders.Csp;

namespace Mvc4.Controllers
{
    public class CspConfigController : Controller
    {
        //
        // GET: /CspConfig/

        public ActionResult Index()
        {
            return View("Index");
        }

        [CspScriptSrc(CustomSources = "attributescripthost")]
        public ActionResult AddSource()
        {
            return View("Index");
        }

        [CspScriptSrc(CustomSources = "attributescripthost", InheritCustomSources = false)]
        public ActionResult OverrideSource()
        {
            return View("Index");
        }

        [Csp(Enabled = false)]
        public ActionResult DisableCsp()
        {
            return View("Index");
        }

        [CspScriptSrc(UnsafeInline = true, UnsafeEval = true)]
        public ActionResult ScriptSrcAllowInlineUnsafeEval()
        {
            return View("Index");
        }
    }
}
