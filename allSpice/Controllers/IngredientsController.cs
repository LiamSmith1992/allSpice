
namespace allSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth0provider;

  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0provider, RecipesService recipesService)
  {
    _ingredientsService = ingredientsService;
    _auth0provider = auth0provider;
    _recipesService = recipesService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      ingredientData.CreatorId = userInfo.Id;

      Ingredient ingredient = _ingredientsService.Create(ingredientData);
      return Ok(ingredient);

    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }





}
