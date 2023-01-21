
namespace allSpice.Services;

public class IngredientsService
{

  private readonly IngredientsRepository _repo;

  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }


  internal Ingredient Create(Ingredient ingredientData)
  {
    Ingredient ingredient = _repo.Create(ingredientData);
    return ingredient;
  }



}
