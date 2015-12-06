// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;

namespace Mvc6.Controllers
{
    public class HstsController : Controller
    {
        //
        // GET: /Hsts/

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult NoHttpsOnly()
        {
            return View("Index");
        }

        public ActionResult UpgradeInsecureRequests()
        {
            return View("Index");
        }
    }
}
