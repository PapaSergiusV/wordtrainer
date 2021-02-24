using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Vocabulary.Models;

namespace Vocabulary.Services
{
  public interface IWordService : ICrudService<Word>
  {
    Task<IEnumerable<Word>> AddRange(IEnumerable<Word> words);
    Task<bool> HasPermission(int userId, int wordId);
    Task<int> Count(Expression<Func<Word, bool>> predicate);
  }
}
