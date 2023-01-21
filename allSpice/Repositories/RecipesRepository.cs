
namespace allSpice.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Recipe Create(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes
    (title, instructions, img, category, creatorId)
    VALUES
    (@title, @instructions, @img, @category, @creatorId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, recipeData);
    recipeData.Id = id;
    return recipeData;

  }

  internal List<Recipe> Get()
  {
    string sql = @"
    SELECT 
    rp.*,
    ac.*
    FROM recipes rp
    JOIN accounts ac ON ac.id = rp.creatorId;
    ";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }).ToList();
    return recipes;
  }

  internal Recipe GetOne(int id)
  {
    string sql = @"
    SELECT
    recipes.*,
    accounts.*
    
    FROM recipes 
    JOIN accounts On accounts.id = recipes.creatorId
    WHERE recipes.id = @id;
    ";
    return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, new { id }).FirstOrDefault();
  }

  internal void Remove(int id)
  {
    string sql = @"
    DELETE FROM recipes
    WHERE id = @id;

    ";
    _db.Execute(sql, new { id });
  }

  internal bool Update(Recipe original)
  {
    string sql = @"
    UPDATE recipes
    Set
    title = @title,
    instructions = @instructions,
    img = img,
    category = @category
WHERE id = @id
    ";
    int rows = _db.Execute(sql, original);
    return rows > 0;
  }
}
