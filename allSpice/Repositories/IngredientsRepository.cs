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
    INSERT INTO ingredients
    (Name, Quantity, RecipeId)
    VALUES
    (@Name, @Quantity, @RecipeId)
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, ingredientData);

    return ingredientData;

  }





}