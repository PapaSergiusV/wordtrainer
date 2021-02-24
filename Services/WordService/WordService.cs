using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vocabulary.Models;
using Vocabulary.AppExceptions;

namespace Vocabulary.Services
{
  public class WordService : IWordService
  {
    private readonly Context _context;

    public WordService(Context context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Word>> FindAll() => await Task.Run(() => _context.Words.ToList());

    public async Task<IEnumerable<Word>> FindAll(BaseFilter<Word> filter) =>
      await Task.Run(
        () => _context.Words
                      .OrderBy(x => x.Points)
                      .ThenBy(x => x.UpdatedAt)
                      .Where(filter.Predicate)
                      .Skip(filter.Skip)
                      .Take(filter.Take)
                      .ToList()
      );

    public async Task<Word> Find(int id) => await _context.Words.FindAsync(id);

    public async Task<Word> Add(Word word)
    {
      if (IsDuplicate(word))
        throw new RequestArgumentException("Same word already exists", 422);
      word.UpdatedAt = DateTime.UtcNow;
      await _context.Words.AddAsync(word);
      await _context.SaveChangesAsync();
      return word;
    }

    public async Task<IEnumerable<Word>> AddRange(IEnumerable<Word> words)
    {
      // TO DO: updated at field ?
      foreach (Word word in words)
      {
        if (IsDuplicate(word))
          throw new RequestArgumentException($"Word '{word.Eng} - {word.Rus}' already exists", 422);
      }
      await _context.Words.AddRangeAsync(words);
      await _context.SaveChangesAsync();
      return words;
    }

    public async Task<Word> Update(Word word)
    {
      if (IsDuplicate(word))
        throw new RequestArgumentException("Same word already exists", 422);
      Word updatedWord = await Find(word.Id);
      if (updatedWord == null)
        throw new RequestArgumentException("Word not found", 404);
      updatedWord.CopyFrom(word);
      updatedWord.UpdatedAt = DateTime.UtcNow;
      _context.Words.Update(updatedWord);
      await _context.SaveChangesAsync();
      return updatedWord;
    }

    public async Task<(bool, string)> UpdateRange(IEnumerable<Word> words)
    {
      Word[] originals = words.Select((w) => _context.Words.Find(w.Id)).ToArray();
      Word[] updated = words.ToArray();
      for (int i = 0; i < originals.Length; ++i)
      {
        if (originals[i].Id == updated[i].Id)
        {
          originals[i].CopyFrom(updated[i]);
        }
        else
        {
          Word copy = updated.First((w) => w.Id == originals[i].Id);
          originals[i].CopyFrom(copy);
        }
        originals[i].UpdatedAt = DateTime.UtcNow;
      }
      //   if (IsDuplicate(word))
      //     return (false, $"Word {word.Eng} is duplicate");
      _context.Words.UpdateRange(originals);
      await _context.SaveChangesAsync();
      return (true, string.Empty);
    }

    public async Task Remove(int id)
    {
      _context.Remove(id);
      await _context.SaveChangesAsync();
    }

    public async Task<bool> HasPermission(int userId, int wordId)
    {
      Word word = await _context.Words.FindAsync(wordId);
      return userId == word.UserId;
    }

    public async Task<int> Count(Expression<Func<Word, bool>> predicate)
    {
      return await Task.Run(() => _context.Words.Where(predicate).ToList().Count);
    }

    private bool IsDuplicate(Word word)
    {
      if (word.Id != 0)
        return _context.Words.Where(w => w.Id != word.Id).Any(w => w.Eng == word.Eng || w.Rus == word.Rus);
      return  _context.Words.Any(w => w.Eng == word.Eng || w.Rus == word.Rus);
    }
  }
}
