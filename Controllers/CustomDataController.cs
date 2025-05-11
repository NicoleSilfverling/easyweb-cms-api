using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Easyweb.Controllers
{
    public class CustomDataController : Controller
    {
        // Action to get the planet list and pass it to the view
        [HttpGet("/planets")]
        public IActionResult Index()
        {
            var planets = new[] { "Mercury_(planet)", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };

            return View(planets);
        }

        // Action to fetch the data for a specific planet
        [HttpGet("/data/{planet}")]
        public async Task<IActionResult> GetPlanetData(string planet)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://en.wikipedia.org/api/rest_v1/page/summary/{planet}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var content = await response.Content.ReadAsStringAsync();
            var planetData = JsonConvert.DeserializeObject<PlanetDataModel>(content);

            return Json(planetData);
        }
    }
}
