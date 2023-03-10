
namespace allSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{

  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth0provider;

  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0provider)
  {
    _ingredientsService = ingredientsService;
    _auth0provider = auth0provider;
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
      ingredient.Creator = userInfo;
      return Ok(ingredient);

    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public ActionResult<string> Remove(int id)
  {
    try
    {

      String message = _ingredientsService.Remove(id);
      return Ok(message);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }




}
