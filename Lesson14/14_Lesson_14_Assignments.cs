
//CREATE DIFFERENT ENDPOINTS FOR A WEBSITE

using Microsoft.AspNetCore.Mvc;

namespace hikitocAPI.Controllers
{
    [Controller]
    public class HomeController
    {
        [Route("/")]
        [Route("/my-blog/{all-posts:alpha}")]
        public string Home()
        {
            return "Blog Home Page";
        }

        [Route("/about-my-blog")]
        public string Blog()
        {
            return "About my Blog";
        }

        [Route("/post/{id:int}")]
        public string User()
        {
            return "My Blog post";
        }

        [Route("/contact-us")]
        public string Contacts()
        {
            return "My contacts";
        }
    }
}
