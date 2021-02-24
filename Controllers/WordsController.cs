using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Vocabulary.Models;
using Vocabulary.Services;
using Vocabulary.AppExceptions;

namespace Vocabulary.Controllers
{
  [Route("words")]
  [Authorize]
  public class WordsController : Controller
  {
    private readonly ILogger<WordsController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly IWordService _wordService;
    private User _user;

    public WordsController(ILogger<WordsController> logger, UserManager<User> userManager, IWordService wordService)
    {
      _logger = logger;
      _userManager = userManager;
      _wordService = wordService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, string searchWord = "")
    {
      BaseFilter<Word> filter = new BaseFilter<Word>(
        page, w => w.UserId == _user.Id && (Regex.IsMatch(w.Eng, searchWord) || Regex.IsMatch(w.Rus, searchWord))
      );
      IEnumerable<Word> words = await _wordService.FindAll(filter);
      ViewBag.Words = words;
      ViewBag.Page = page;
      ViewBag.SearchWord = searchWord;
      return View();
    }

    [HttpGet("add")]
    public IActionResult Add() => View();

    [HttpPost("add")]
    public async Task<IActionResult> Add(Word word)
    {
      if (ModelState.IsValid)
      {
        word.UserId = _user.Id;
        try
        {
          await _wordService.Add(word);
          return RedirectToAction("Index");
        }
        catch (RequestArgumentException ex)
        {
          ModelState.AddModelError(string.Empty, ex.Message);
        }
      }
      return View(word);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
      Word word = await _wordService.Find(id);
      if (word != null)
        return View(word);
      return BadRequest();
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(int id, Word word)
    {
      if (ModelState.IsValid)
      {
        try
        {
          if (await _wordService.HasPermission(_user.Id, id))
            await _wordService.Update(word);
          return RedirectToAction("Index");
        }
        catch (RequestArgumentException ex)
        {
          ModelState.AddModelError(string.Empty, ex.Message);
        }
      }
      return View(word);
    }

    [HttpGet("remove/{id}")]
    public async Task<IActionResult> Remove(int id)
    {
      if (await _wordService.HasPermission(_user.Id, id))
        await _wordService.Remove(id);
      return RedirectToAction("Index");
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      _user = _userManager.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
    }
  }
}
