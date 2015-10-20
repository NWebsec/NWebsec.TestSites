// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Web.Mvc;

namespace Mvc3.Controllers
{
    public class CspUpgradeInsecureRequestsController : Controller
    {
        //
        // GET: /Csp/

        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
