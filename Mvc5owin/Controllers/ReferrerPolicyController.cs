// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Web.Mvc;

namespace Mvc5owin.Controllers
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
