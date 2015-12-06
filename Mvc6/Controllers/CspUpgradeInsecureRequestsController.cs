// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;

namespace Mvc6.Controllers
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
