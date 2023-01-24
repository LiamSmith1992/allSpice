
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

  internal List<MyFav> GetFavorites(string userId)
  {
    string sql = @"
    SELECT
    fav.*,
    r.*,
    a.*
FROM favorites fav
JOIN recipes r On r.id = fav.recipeId
Join accounts a On r.creatorId = a.id
WHERE fav.accountId = @userId;
    ";
    List<MyFav> myFav = _db.Query<Favorite, MyFav, Account, MyFav>(sql, (fav, r, a) =>
    {
      r.FavoriteId = fav.Id;
      r.Creator = a;
      return r;
    }, new { userId }).ToList();
    return myFav;
  }

  internal Favorite getOne(int id)
  {
    string sql = @"
    SELECT * FROM favorites
    WHERE id = @id;
    ";
    Favorite favorite = _db.Query<Favorite>(sql, new { id }).FirstOrDefault();
    return favorite;
    // r.*,
    // a.*
    // From favorites f
    // JOIN recipe r ON f.RecipeId = r.Id
    // JOIN accounts a On f.AccountId = a.Id
    // WHERE f.id = @id

    // Favorite favorite = _db.Query<Favorite, MyFav, Account, Favorite>(sql, (f, r, a) =>
    // {
    //   f.RecipeId = r.Id;
    //   f.AccountId = a.Id;
    //   return f;
    // }, new { id }).FirstOrDefault();
    // return favorite;

  }

  internal bool UnLike(int id)
  {
    string sql = @"
   DELETE FROM favorites
   WHERE id = @id;
   ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }
}
