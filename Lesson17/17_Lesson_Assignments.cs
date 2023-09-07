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
        public IActionResult Home()
        {
            return new ContentResult()
            {
                Content = "<h1>reply from Home</h1>",
                ContentType = "text/html"
            };
        }

        [Route("/blog")]
        public IActionResult Blog()
        {
            return new ContentResult()
            {
                Content = "reply from Blog",
                ContentType = "text/plain"
            };
        }

        [Route("/users-id/{id:int}")]
        public IActionResult Users()
        {
            return Content("Users ID's", "text/plain");
        }

        [Route("/db-access")]
        public IActionResult DbAccess()
        {
            var data = new { userID = 12345 };
            var json = JsonSerializer.Serialize(data);
            return Content(json, "application/json");
        }

        [Route("/db-accessor")]
        public IActionResult Accessor()
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
        public IActionResult DownloadsOne()
        {
            //return new PhysicalFileResult(@"c:\lessons\hikitoc.pdf", "application/pdf");
            return PhysicalFile(@"c:\lessons\hikitoc.pdf", "application/pdf");
        }

        [Route("/downloads-virtual")]
        public IActionResult DownloadsTwo()
        {
            //return new VirtualFileResult("/hikitoc.pdf", "application/pdf");
            return File("/hikitoc.pdf", "application/pdf");
        }

        [Route("/downloads")]
        public IActionResult DownloadsThree()
        {
            byte[] readByBytes = System.IO.File.ReadAllBytes(@"c:\lessons\hikitoc.pdf");
            //return new FileContentResult(readByBytes, "application/pdf");
            return File(readByBytes, "application/pdf");
        }
    
        //http://localhost:5226/result?auth=true&id=1&name=JD


        [Route("/result")]
        //public ContentResult Auth()
        public IActionResult Result()
        {
            var auth = Request.Query.ContainsKey("auth");
            var code = Request.Query.ContainsKey("code");
            var id = Request.Query.ContainsKey("id");
            var name = Request.Query.ContainsKey("name");


            //ADD AN ADDITIONAL IF CHECK TO REPLY USING SatusCode method
            if (!code)
            {
                return StatusCode(200, "message goes here");
            }



            if (!auth)
            {
                return Content("not authenticated");
            }

            if (!id)
            {
                //Response.StatusCode = 401;
                //return Json("no id, not authenticated");
                //var noAuth = new UnauthorizedResult("no id, not authenticated");
                //return noAuth;
                return Unauthorized("no id, not authenticated");
            }

            if (!name)
            {
                return NotFound("NOT FOUND");
            }
            //return Content("authenticated");
            return BadRequest("BAD REQUEST :)))");
        }

        //auth?auth=true

        [Route("/contacts")]
        public string Contacts()
        {
            return "Contacts";
        }
    }
}
