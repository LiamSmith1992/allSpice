
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

  internal Recipe Update(Recipe recipeData, int id)
  {
    Recipe original = GetOne(id);
    original.Title = recipeData.Title ?? original.Title;
    original.Instructions = recipeData.Instructions ?? original.Instructions;
    original.Img = recipeData.Img ?? original.Img;
    original.Category = recipeData.Category ?? original.Category;

    bool edited = _repo.Update(original);
    if (edited == false)
    {
      throw new Exception("recipe was not updated");
    };
    return original;
  }

  internal string Remove(int id, string userId)
  {
    Recipe original = GetOne(id);
    if (original.CreatorId != userId)
    {

      throw new Exception("nacho lebre your recipe");
    }

    _repo.Remove(id);
    return $"{original.Title} has been removed";
  }
}
