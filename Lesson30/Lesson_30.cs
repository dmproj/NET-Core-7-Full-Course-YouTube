using Microsoft.AspNetCore.Mvc;

//implicit binding
[ApiController]
public class IndexController : ControllerBase
{
    public IActionResult Index(IFormCollection form,
                               string requestBody, // if no [ApiController] attribute, rquest body is skipped.
                               IDictionary<string, object> routeData,
                               string queryStrings,
                               IFormFileCollection uploadedFiles)
    {
        // Do something with the form fields, request body, route data, query string parameters, and uploaded files.

        return Ok();
    }
}


//explicit binding
// [ApiController] is not required
public class IndexController1 : ControllerBase
{
    public IActionResult Index([FromForm] IFormCollection form,
                               [FromBody] string requestBody,
                               [FromRoute] IDictionary<string, object> routeData,
                               [FromQuery] string queryStrings,
                               [FromForm] IFormFileCollection uploadedFiles)
    {
        // Do something with the form fields, request body, route data, query string parameters, and uploaded files.

        return Ok();
    }


    //explicit binding, -- SHUFFLED ORDER --
    // [ApiController] is not required
    public IActionResult Index1([FromBody] string requestBody,
                                [FromRoute] IDictionary<string, object> routeData,
                                [FromQuery] string queryStrings,
                                [FromForm] IFormCollection form,
                                [FromForm] IFormFileCollection uploadedFiles)
    {
        // Do something with the form fields, request body, route data, query string parameters, and uploaded files.

        return Ok();
    }
}