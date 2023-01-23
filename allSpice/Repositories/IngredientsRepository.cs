namespace allSpice.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Ingredient Create(Ingredient ingredientData)
  {
    string sql = @"
    INSERT INTO ingredient
    (name, quantity, recipeId, creatorId)
    VALUES
    (@name, @quantity, @recipeId, @creatorId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, ingredientData);

    return ingredientData;

  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
   SELECT
   i.*,
   a.*
   FROM ingredient i
   JOIN accounts a On i.creatorId = a.id
   WHERE recipeId = @recipeId;
   ";
    List<Ingredient> ingredients = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
    {
      ingredient.Creator = account;
      return ingredient;
    }, new { recipeId }).ToList();
    return ingredients;
  }

  internal void Remove(int id)
  {
    string sql = @"
   DELETE FROM ingredient
   WHERE id = @id
   ";
    int rows = _db.Execute(sql, new { id });

  }
}