using System;
using System.Linq.Expressions;

namespace Vocabulary.Services
{
  public class BaseFilter<Entity> where Entity : class
  {
    private readonly int _page;
    private readonly int _itemsPerPage;
    private readonly Expression<Func<Entity, bool>> _predicate;
    private const int ITEMS_PER_PAGE = 20;

    public BaseFilter(int page = 1, int itemsPerPage = ITEMS_PER_PAGE)
    {
      _page = page > 0 ? page : 1;
      _itemsPerPage = itemsPerPage;
      _predicate = x => true;
    }

    public BaseFilter(int page, Expression<Func<Entity, bool>> predicate, int itemsPerPage = ITEMS_PER_PAGE)
    {
      _page = page > 0 ? page : 1;
      _itemsPerPage = itemsPerPage;
      _predicate = predicate;
    }

    public int Skip
    {
      get => (_page - 1) * _itemsPerPage;
    }

    public int Take { get => _itemsPerPage; }

    public Expression<Func<Entity, bool>> Predicate { get => _predicate; }
  }
}
