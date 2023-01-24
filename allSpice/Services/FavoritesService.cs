
namespace allSpice.Services;

public class FavoritesService
{

  private readonly FavoritesRepository _repo;

  public FavoritesService(FavoritesRepository repo)
  {
    _repo = repo;
  }

  internal Favorite Create(Favorite favData)
  {
    Favorite fav = _repo.Create(favData);
    return fav;

  }

  internal List<MyFav> GetFavorites(string userId)
  {
    List<MyFav> myFav = _repo.GetFavorites(userId);
    return myFav;
  }

  internal string UnLike(int id, string accountId)
  {
    Favorite original = _repo.getOne(id);
    if (original.AccountId != accountId)
    {
      throw new Exception("not your fav");
    }
    bool result = _repo.UnLike(id);
    return "totally deleted";

  }
}