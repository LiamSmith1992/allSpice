
namespace allSpice.Services;

public class IngredientsService
{

  private readonly IngredientsRepository _repo;
  private readonly RecipesService _recipesService;


  public IngredientsService(IngredientsRepository repo, RecipesService recipesService)
  {
    _repo = repo;
    _recipesService = recipesService;
  }


  internal Ingredient Create(Ingredient ingredientData)
  {
    Ingredient ingredient = _repo.Create(ingredientData);
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    Recipe recipe = _recipesService.GetOne(recipeId);
    List<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }

  internal string Remove(int id)
  {
    // TODO getOneIngredient to check the creator of ingredient 
    bool result = _repo.Remove(id);
    if (result == false)
    {
      throw new Exception("nothing was deleted");
    }
    return "was deleted";
  }

  // FIXME make a getOneIngredient function 
}
