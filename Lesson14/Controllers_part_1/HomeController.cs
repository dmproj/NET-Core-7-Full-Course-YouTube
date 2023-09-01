using Microsoft.AspNetCore.Mvc;

namespace hikitocAPI.Controllers
{
    [Controller]
    public class HomeController
    {
        [Route("/")]
        [Route("/home")]
        public string Home()
        {
            return "Home";
        }

        [Route("/blog")]
        public string Blog()
        {
            return "Blog";
        }

        [Route("/users-id/{id:int}")]
        public string User()
        {
            return "Users ID's";
        }

        [Route("/contacts")]
        public string Contacts()
        {
            return "Contacts";
        }
    }
}
