// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Web.Mvc;
using NWebsec.Mvc.HttpHeaders.Csp;

namespace Mvc3.Controllers
{
    [Csp]
    public class CspDirectivesController : Controller
    {
        //
        // GET: /CspDirectives/
        [CspDefaultSrc(Self = true)]
        public ActionResult DefaultSrc()
        {
            return View("Index");
        }

        [CspScriptSrc(Self = true)]
        public ActionResult ScriptSrc()
        {
            return View("Index");
        }

        [CspStyleSrc(Self = true)]
        public ActionResult StyleSrc()
        {
            return View("Index");
        }

        [CspImgSrc(Self = true)]
        public ActionResult ImgSrc()
        {
            return View("Index");
        }

        [CspConnectSrc (Self = true)]
        public ActionResult ConnectSrc()
        {
            return View("Index");
        }

        [CspFontSrc(Self = true)]
        public ActionResult FontSrc()
        {
            return View("Index");
        }

        [CspFrameSrc(Self = true)]
        public ActionResult FrameSrc()
        {
            return View("Index");
        }

        [CspMediaSrc(Self = true)]
        public ActionResult MediaSrc()
        {
            return View("Index");
        }

        [CspObjectSrc(Self = true)]
        public ActionResult ObjectSrc()
        {
            return View("Index");
        }

        [CspFrameAncestors(Self = true)]
        public ActionResult FrameAncestors()
        {
            return View("Index");
        }

        [CspDefaultSrc(Self = true)]
        [CspReportUri(EnableBuiltinHandler = true)]
        public ActionResult ReportUriBuiltin()
        {
            return View("Index");
        }

        [CspDefaultSrc(Self = true)]
        [CspReportUri(ReportUris = "/reporturi")]
        public ActionResult ReportUriCustom()
        {
            return View("Index");
        }

        [CspReportUri(ReportUris = "/reporturi")]
        public ActionResult ReportUriOnly()
        {
            return View("Index");
        }

        public ActionResult Nonces()
        {
            return View();
        }
    }
}
