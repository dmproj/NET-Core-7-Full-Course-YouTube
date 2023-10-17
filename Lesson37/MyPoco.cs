using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.Domain
{
    public class MyPoco
    {
        [FromQuery]
        public int? Vs { get; set; }
        public string? Auth { get; set; }

        public override string ToString()
        {
            return $"replies, Vs: {Vs}, Auth: {Auth}";
        }

    }
}
