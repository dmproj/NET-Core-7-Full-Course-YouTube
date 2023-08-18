using System.Text.RegularExpressions;
using System.Text.Json;

namespace MyApp.CustomConstraint
{
    public class CustomConstraint : IRouteConstraint
    {
        private readonly Dictionary<string, bool> _years = new Dictionary<string, bool>();
        private readonly string _jsonFile = "months.json";

        public bool Match(HttpContext? httpContext, IRouter? route,
            string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // Check whether the value exists
            if (!values.ContainsKey(routeKey)) // year
            {
                return false; // not a match
            }

            Regex regex = new Regex("^(2023|2024|2025)$");
            string? yearValue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(yearValue))
            {
                // Record the constraint verification result in the JSON file
                _years[yearValue] = true;
                //Serialize the dictionary to JSON
                string json = JsonSerializer.Serialize(_years);
                //Write the JSON to a file
                using (StreamWriter writer = new StreamWriter(_jsonFile))
                {
                    writer.Write(json);
                }
                return true; // it's a match
            }
            return false; // not a match
        }
    }
}
