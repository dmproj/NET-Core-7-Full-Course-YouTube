[HttpGet("/api/solarsystems")] // Endpoint: https://localhost:7228/api/solarsystems?vs=55
public IActionResult GetVersus(int? vs, bool? auth)
{
    if (vs <= 5)
    {
        return Content("First if check");
    }
    
    if (auth == true)
    {
        return Content("Second if check");
    }
    
    return Content($"Return from the method, vs: {vs}; auth: {auth}");
}
