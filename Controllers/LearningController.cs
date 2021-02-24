using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Vocabulary.Models;
using Vocabulary.Services;

namespace Vocabulary.Controllers
{
  [ApiController]
  [Authorize]
  [Route("learning")]
  public class LearningController : Controller
  {
    private readonly ILogger<LearningController> _logger;
    private readonly IWordService _wordService;
    private readonly UserManager<User> _userManager;
    private User _user;

    public LearningController(ILogger<LearningController> logger, IWordService wordService, UserManager<User> userManager)
    {
      _logger = logger;
      _wordService = wordService;
      _userManager = userManager;
    }

    [HttpGet]
    public FileStreamResult Index()
    {
      FileStream fs = new FileStream("./wwwroot/learningApp/index.html", FileMode.Open);
      return File(fs, "text/html");
    }

    [HttpGet("open_session")]
    public async Task<IActionResult> OpenSession(bool isLearned = false, Scope scope = Scope.All)
    {
      if ((int)scope < 6)
      {
        int points = (int)scope;
        BaseFilter<Word> filter = new BaseFilter<Word>(
          1, w => w.UserId == _user.Id && w.IsLearned == isLearned && w.Points == points, 20
        );
        return Json(new { words = await _wordService.FindAll(filter) });
      }
      var schema = new Dictionary<int, int>();
      if (scope == Scope.All)
      {
        schema[0] = 5;
        schema[1] = 4;
        schema[2] = 3;
        schema[3] = 2;
        schema[4] = 3;
        schema[5] = 3;
      }
      else if (scope == Scope.HighLevel)
      {
        schema[3] = 7;
        schema[4] = 8;
        schema[5] = 5;
      }
      else
      {
        schema[0] = 7;
        schema[1] = 8;
        schema[2] = 5;
      }
      return Json(new { words = await GenTask(schema, isLearned) });
    }

    [HttpPost("close_session")]
    public async Task<IActionResult> CloseSession([FromBody] WordsContainer wordsContainer)
    {
      var (succeed, error) = await _wordService.UpdateRange(wordsContainer.words);
      if (succeed)
        return Ok();
      return BadRequest(new { error });
    }

    [NonAction]
    private async Task<List<Word>> GenTask(Dictionary<int, int> schema, bool isLearned)
    {
      List<Word> words = new List<Word> {};
      int remained = 0;
      for (int i = schema.First().Key; i <= schema.Last().Key; ++i)
      {
        List<Word> buff = (await _wordService.FindAll(
          new BaseFilter<Word>(1, w => w.UserId == _user.Id && w.Points == i && w.IsLearned == isLearned, schema[i] + remained)
        )).ToList();
        int length = 0;
        foreach (var word in buff)
        {
          ++length;
          words.Add(word);
        }
        remained += schema[i] - length;
      }
      return words;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      _user = _userManager.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
    }
  }

  public enum Scope
  {
    zero,
    one,
    two,
    three,
    four,
    five,
    All,
    HighLevel,  // 3..5
    LowLevel   // 0..2
  }

  public class WordsContainer {
    public IEnumerable<Word> words { get; set; }
  }
}
