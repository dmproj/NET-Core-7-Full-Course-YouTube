using Microsoft.AspNetCore.Mvc;

namespace hikitocAPI.Controllers
{
    [Controller]
    public class HomeController : Controller
    //CREATE AN ENDPOINT USING ContentResult() text/html
    {
        [Route("/")]
        public ContentResult Root()
        {
            return new ContentResult() { Content = "<h2>using ContentResult</h2>", ContentType = "text/html" };
        }

        //CREATE AN ENDPOINT USING Content() text/plain
        [Route("/content")]
        public ContentResult Cont()
        {
            return Content("using Content", "text/plain");
        }

        //CREATE AN ENDPOINT USING PhysicalFileResult()
        [Route("/downloads-physical")]
        public PhysicalFileResult Physical()
        {
            return new PhysicalFileResult(@"c:\path_on_your_PC\filename.pdf", "application/pdf");
        }

        [Route("/downloads-virtual")]
        public VirtualFileResult Virtual()
        {
            return File("/filename.pdf", "application/pdf");
        }
    }
}


