using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Vocabulary.Models;
using Vocabulary.Services;

namespace Vocabulary.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IWordService _wordService;
    private readonly UserManager<User> _userManager;

    public HomeController(ILogger<HomeController> logger, IWordService wordService, UserManager<User> userManager)
    {
      _logger = logger;
      _wordService = wordService;
      _userManager = userManager;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
      User user = _userManager.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
      var now = DateTime.UtcNow;
      var date = new DateTime(now.Year, now.Month, now.Day);
      List<Word> words = (await _wordService.FindAll(new BaseFilter<Word>(1, w => w.UserId == user.Id, int.MaxValue))).ToList();
      ViewBag.LearnedToday = words == null ? 0 : words.Where(w => w.UpdatedAt > date).Count();
      ViewBag.EnCount = words == null ? 0 : words.Where(w => w.Language == "en").Count();
      ViewBag.FrCount = words == null ? 0 : words.Where(w => w.Language == "fr").Count();
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
