

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

  [HttpPost]
  public async Task<ActionResult<Favorite>> Create([FromBody] Favorite favData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      favData.AccountId = userInfo.Id;
      Favorite fav = _favoritesService.Create(favData);

      return fav;
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> UnLike(int id)
  {
    Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
    string message = _favoritesService.UnLike(id, userInfo.Id);
    return Ok(message);
  }


}

