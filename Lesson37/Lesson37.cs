using Azure.Core;
using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hikitocAPI.Controllers
{
    [Route("api/[controller]")] // localhost:port/api/solarsystems
    //[ApiController]
    public class SolarSystemsController : ControllerBase
    {

        [HttpPost("explicit/{vs?}/{auth?}")]
        public IActionResult Explicit([FromQuery] int? vs, [FromRoute] string? auth, MyPoco? myPoco)
        {
            if (vs <= 5)
            {
                return Content("First if check");
            }

            if (auth == "mydata")
            {
                return Content("Second if check");
            }

            return Content($"Return from the method: vs: {vs}; auth: {auth};\nMyPoco {myPoco}");
        }











        //private readonly HikitocDbContext hikitocDbContext;

        //public SolarSystemsController(HikitocDbContext hikitocDbContext)
        //{
        //    this.hikitocDbContext = hikitocDbContext;
        //}
        ////GET ALL SOLAR SYSTEMS
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var solarSystems = hikitocDbContext.SolarSystems.ToList();

        //    var solarSystemsDto = solarSystems.Select(solarSystem => new SolarSystemDto()
        //    {
        //        Id = solarSystem.Id,
        //        Code = solarSystem.Code,
        //        Name = solarSystem.Name,
        //        Image = solarSystem.Image,
        //    }).ToList();

        //    return Ok(new { Message = "Success from GetAll action method", Data = solarSystemsDto });
        //}

        ////GET 1 SOLAR SYSTEM BY ID
        ////[HttpGet("{id}")]

        //[HttpGet]
        //[Route("{id:Guid}")] // localhost:port/api/solarsystems/{id}
        //public IActionResult GetById([FromRoute] Guid id)
        //{
        //    var solarSystemSingle = hikitocDbContext.SolarSystems.SingleOrDefault(item => item.Id == id);

        //    if (solarSystemSingle == null)
        //    {
        //        return NotFound(new { Message = "No Solar System found!" });
        //    }

        //    var solarSystemDto = new SolarSystemDto
        //    {
        //        Id = solarSystemSingle.Id,
        //        Code = solarSystemSingle.Code,
        //        Name = solarSystemSingle.Name,
        //        Image = solarSystemSingle.Image,
        //    };

        //    return Ok(new { Message = "1 Solar System found!", Data = solarSystemDto });
        //}

        ////POST/INSERT A SOLAR SYSTEM

        //[HttpPost] // localhost:port/api/solarsystems/
        //public IActionResult InsertSingle([FromBody] InsertSolarSystemDto insertSolarSystemDto)
        //{
        //    var solarSystem = new SolarSystem
        //    {
        //        Code = insertSolarSystemDto.Code,
        //        Name = insertSolarSystemDto.Name,
        //        Image = insertSolarSystemDto.Image,
        //    };

        //    hikitocDbContext.SolarSystems.Add(solarSystem);
        //    hikitocDbContext.SaveChanges();

        //    var solarSystemDto = new SolarSystemDto
        //    {
        //        Id = solarSystem.Id,
        //        Code = solarSystem.Code,
        //        Name = solarSystem.Name,
        //        Image = solarSystem.Image,
        //    };

        //    return Created("/api/solarsystems/" + solarSystem.Id, new { Message = "Solar System created!", Data = solarSystemDto });
        //}

        ////PUT/UPDATE 1 SOLAR SYSTEM BY ID
        ////[HttpPut("{id}")]

        //[HttpPut]
        //[Route("{id:Guid}")] // localhost:port/api/solarsystems/{id}
        //public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateSolarSystemDto updateSolarSystemDto)
        //{
        //    try
        //    {
        //        var solarSystemSingle = await hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

        //        if (solarSystemSingle == null)
        //        {
        //            return NotFound(new { Message = "No Solar System found!" });
        //        }

        //        solarSystemSingle.Code = updateSolarSystemDto.Code;
        //        solarSystemSingle.Name = updateSolarSystemDto.Name;
        //        solarSystemSingle.Image = updateSolarSystemDto.Image;

        //        await hikitocDbContext.SaveChangesAsync();

        //        var solarSystemDto = new SolarSystemDto
        //        {
        //            Id = solarSystemSingle.Id,
        //            Code = solarSystemSingle.Code,
        //            Name = solarSystemSingle.Name,
        //            Image = solarSystemSingle.Image,
        //        };

        //        return Ok(new { Message = "1 Solar System updated!", Data = solarSystemDto });
        //    }

        //    catch (DbUpdateException ex)
        //    {
        //        Console.WriteLine($"Database Update Error: {ex}");

        //        return StatusCode(500, new { Message = "An error occured while updating the database" });
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex}");

        //        return StatusCode(500, new { Message = "An error occured while processing the request" });
        //    }
        //}

        ////DELETE A SOLAR SYSTEM BY ID
        ////[HttpDelete("{id}")]

        //[HttpDelete]
        //[Route("{id:Guid}")] // localhost:port/api/solarsystems/{id}
        //public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        //{
        //    try
        //    {
        //        var solarSystemSingle = await hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

        //        if (solarSystemSingle == null)
        //        {
        //            return NotFound(new { Message = "No Solar System found!" });
        //        }

        //        hikitocDbContext.SolarSystems.Remove(solarSystemSingle);
        //        await hikitocDbContext.SaveChangesAsync();

        //        return Ok(new { Message = "1 Solar System deleted!" });
        //    }

        //    catch (DbUpdateException ex)
        //    {
        //        Console.WriteLine($"Database Update Error: {ex}");

        //        return StatusCode(500, new { Message = "An error occured while updating the database" });
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex}");

        //        return StatusCode(500, new { Message = "An error occured while processing the request" });
        //    }
        //}

    }
}
