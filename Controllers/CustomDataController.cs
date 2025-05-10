using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Easyweb.Controllers
{
    public class CustomDataController : Controller
    {
        [HttpGet("/data")]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://en.wikipedia.org/api/rest_v1/page/summary/mars");
            var content = await response.Content.ReadAsStringAsync();

            var planetData = JsonConvert.DeserializeObject<PlanetDataModel>(content);

            // return Content(content, "application/json");
            return View(planetData);
        }
    }
}
