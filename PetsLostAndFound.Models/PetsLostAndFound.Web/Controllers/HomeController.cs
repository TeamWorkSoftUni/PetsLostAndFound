namespace PetsLostAndFound.Web.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  public class HomeController : BaseController

  {
    [HttpGet]
    public IActionResult Index()
    {
      return Ok();
    }
  }
}
