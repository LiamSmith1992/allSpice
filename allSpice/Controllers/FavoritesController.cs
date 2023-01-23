

namespace allSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{

  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0provider;

  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0provider)
  {
    _favoritesService = favoritesService;
    _auth0provider = auth0provider;
  }

}

