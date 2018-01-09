namespace PetsLostAndFound.Web.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PetsLostAndFound.Services;

  public class PostsController : BaseController
  {
    private readonly IPetService pets;

    public PostsController(IPetService pets)
    {
      this.pets = pets;
    }

    [HttpGet]
    public IActionResult All()
    {
      return Ok(pets.AllListing());
    }

  }
}
