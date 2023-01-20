
namespace allSpice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  [HttpPost]
  internal Recipe Create(Recipe recipeData)
  {
    Recipe recipe = _repo.Create(recipeData);
    return recipe;
  }

  internal List<Recipe> Get()
  {
    List<Recipe> recipes = _repo.Get();
    return recipes;
  }

  internal Recipe GetOne(int id)
  {
    Recipe recipe = _repo.GetOne(id);
    if (recipe == null)
    {
      throw new Exception("no recipe with this id");
    }
    return recipe;
  }
}
