using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Easyweb.Controllers
{
    using Easyweb.Models;
    public class CustomDataController : Controller
    {


        // Action to get the planet list and pass it to the view
        [HttpGet("/planets")]
        public IActionResult Index()
        {
            var planets = new List<Planet>
            {
                new Planet { Name = "Mercury", WikiName = "Mercury_(planet)", SizeFactor = 30, Color = "#aaa", HasRings = false },
                new Planet { Name = "Venus", WikiName = "Venus", SizeFactor = 50, Color = "#c9b37e", HasRings = false },
                new Planet { Name = "Earth", WikiName = "Earth", SizeFactor = 55, Color = "#2e77bc", HasRings = false },
                new Planet { Name = "Mars", WikiName = "Mars", SizeFactor = 40, Color = "#d14b3e", HasRings = false },
                new Planet { Name = "Jupiter", WikiName = "Jupiter", SizeFactor = 80, Color = "#d6a16d", HasRings = false },
                new Planet { Name = "Saturn", WikiName = "Saturn", SizeFactor = 70, Color = "#ecdcbf", HasRings = true },
                new Planet { Name = "Uranus", WikiName = "Uranus", SizeFactor = 50, Color = "#7fdbff", HasRings = true },
                new Planet { Name = "Neptune", WikiName = "Neptune", SizeFactor = 50, Color = "#4169e1", HasRings = true }
            };
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
