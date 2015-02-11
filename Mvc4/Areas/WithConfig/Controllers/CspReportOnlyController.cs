// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Web.Mvc;
using NWebsec.Mvc.HttpHeaders.Csp;

namespace Mvc4.Areas.WithConfig.Controllers
{
    [CspReportOnly]
    [CspDefaultSrcReportOnly(Self = true)]
    public class CspReportOnlyController : Controller
    {
        //
        // GET: /CspReportOnly/

        public ActionResult Index()
        {
            return View("Index");
        }

        [CspReportOnly(Enabled = false)]
        public ActionResult Disabled()
        {
            return View("Index");
        }
    }
}
