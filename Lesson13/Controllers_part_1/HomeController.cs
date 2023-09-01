using Microsoft.AspNetCore.Mvc;

namespace hikitocAPI.Controllers
{
    public class HomeController
    {
        [Route("/")]
        public string Res()
        {
            return "HomeController Replied";
        }
    }
}
