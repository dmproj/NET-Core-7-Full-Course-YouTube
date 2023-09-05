using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using hikitocAPI.Model;

namespace hikitocAPI.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/home")]
        public ContentResult Home()
        {
            return new ContentResult()
            {
                Content = "<h1>reply from Home</h1>",
                ContentType = "text/html"
            };
        }

        [Route("/blog")]
        public ContentResult Blog()
        {
            return new ContentResult()
            {
                Content = "reply from Blog",
                ContentType = "text/plain"
            };
        }

        [Route("/users-id/{id:int}")]
        public ContentResult Users()
        {
            return Content("Users ID's", "text/plain");
        }

        [Route("/db-access")]
        public ContentResult DbAccess()
        {
            var data = new { userID = 12345 };
            var json = JsonSerializer.Serialize(data);
            return Content(json, "application/json");
        }

        [Route("/db-accessor")]
        public JsonResult Accessor()
        {
            Access access = new Access()
            {
                Login = "login",
                Password = "password",
                Id = Guid.NewGuid(),
                Auth = true
            };
            return Json(access);
        }

        [Route("/downloads-physical")]
        public PhysicalFileResult DownloadsOne()
        {
            //return new PhysicalFileResult(@"c:\lessons\hikitoc.pdf", "application/pdf");
            return PhysicalFile(@"c:\lessons\hikitoc.pdf", "application/pdf");
        }

        [Route("/downloads-virtual")]
        public VirtualFileResult DownloadsTwo()
        {
            //return new VirtualFileResult("/hikitoc.pdf", "application/pdf");
            return File("/hikitoc.pdf", "application/pdf");
        }

        [Route("/downloads")]
        public FileContentResult DownloadsThree()
        {
            byte[] readByBytes = System.IO.File.ReadAllBytes(@"c:\lessons\hikitoc.pdf");
            //return new FileContentResult(readByBytes, "application/pdf");
            return File(readByBytes, "application/pdf");
        }

        [Route("/contacts")]
        public string Contacts()
        {
            return "Contacts";
        }
    }
}
