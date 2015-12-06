// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;

namespace Mvc6.Controllers
{
    public class ReferrerPolicyController : Controller
    {
        //
        // GET: /Home/

        public ActionResult None()
        {
            return View();
        }

        public ActionResult NoneWhenDowngrade()
        {
            return View();
        }
        public ActionResult Origin()
        {
            return View();
        }

        public ActionResult OriginWhenCrossOrigin()
        {
            return View();
        }

        public ActionResult UnsafeUrl()
        {
            return View();
        }
    }
}
