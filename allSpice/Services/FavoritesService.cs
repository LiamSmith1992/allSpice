
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




}
