namespace PetsLostAndFound.Web.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PetsLostAndFound.Web.Models;
  using System.Diagnostics;

  [Route("[controller]/[action]")]
  public class HomeController : Controller
  {
    [HttpGet]
    public IActionResult Index()
    {
      return Ok();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return Ok();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return Ok();
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
