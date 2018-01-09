namespace PetsLostAndFound.Web.Controllers
{
  using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
  public class HomeController : BaseController
=======
  [Route("[controller]/[action]")]
  public class HomeController : Controller
>>>>>>> e56d7b23ebf54997a9494fc880acbacc9cd5faff
  {
    [HttpGet]
    public IActionResult Index()
    {
      return Ok();
    }
<<<<<<< HEAD
=======

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
>>>>>>> e56d7b23ebf54997a9494fc880acbacc9cd5faff
  }
}
