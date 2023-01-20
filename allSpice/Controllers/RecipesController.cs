

namespace allSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0provider;

  public RecipesController(RecipesService recipesService, Auth0Provider auth0provider)
  {
    _recipesService = recipesService;
    _auth0provider = auth0provider;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.Create(recipeData);
      recipe.Creator = userInfo;
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }


  [HttpGet]
  public ActionResult<List<Recipe>> Get()
  {
    try
    {
      List<Recipe> recipes = _recipesService.Get();
      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }


  [HttpGet("{id}")]
  public ActionResult<Recipe> GetOne(int id)
  {
    try
    {

      Recipe recipe = _recipesService.GetOne(id);
      return Ok(recipe);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

}
