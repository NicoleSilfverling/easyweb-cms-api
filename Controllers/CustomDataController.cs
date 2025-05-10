// using System.Net.Http;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;

// namespace Easyweb.Controllers;

// public class CustomDataController : Controller
// {
//     [HttpGet("/data")]
//     public virtual async Task<IActionResult> Index()
//     {
//         string result;

//         using (var client = new HttpClient())
//         {
//             var response = await client.GetAsync("https://en.wikipedia.org/api/rest_v1/page/summary/mars");
//             result = await response.Content.ReadAsStringAsync();
//         }

//         return Ok(result);
//     }
// }



using Microsoft.AspNetCore.Mvc;

namespace Easyweb.Controllers;

public class CustomDataController : Controller
{
    [HttpGet("/data")]
    public IActionResult Index()
    {
        // Set the custom layout for this page
        ViewData["Layout"] = "~/Views/Shared/_CustomLayout.cshtml";

        return View();
    }
}