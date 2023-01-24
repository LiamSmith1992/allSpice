
namespace allSpice.Repositories;

public class FavoritesRepository
{

  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }


  internal Favorite Create(Favorite favData)
  {
    string sql = @"
INSERT INTO favorites
(accountId, recipeId)
VALUES
(@accountId, @recipeId);
SELECT LAST_INSERT_ID();
";
    int id = _db.ExecuteScalar<int>(sql, favData);
    favData.Id = id;
    return favData;

  }



}
