using Microsoft.AspNetCore.Mvc;

namespace hikitocAPI.Controllers
{
    public class RedirectController : Controller
    {
        [Route("/gaming-gpu/sale/{model}")]
        public IActionResult Sale()
        {
            //return Content("GPUs Sale");
            int model = Convert.ToInt32(Request.RouteValues["model"]);
            return Content($"GPUs {model} sale");
        }
    }
}
