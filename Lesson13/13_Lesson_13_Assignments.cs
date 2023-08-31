using Microsoft.AspNetCore.Mvc;

namespace hikitocAPI.Controllers
{
    public class HomeController
    {
        [Route("/res")]
        public string Res()
        {
            return "HomeController Replied";
        }[Route("/res1")]
        public string Res1()
        {
            return "HomeController Replied 1";
        }[Route("/res2")]
        public string Res2()
        {
            return "HomeController Replied 2";
        }
    }
}
