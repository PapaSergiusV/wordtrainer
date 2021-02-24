using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vocabulary.Models;
using Vocabulary.ViewModels;

namespace Vocabulary.Controllers
{
  [Route("account")]
  public class AccountController : Controller
  {
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AccountController(ILogger<AccountController> logger, SignInManager<User> signInManager, UserManager<User> userManager)
    {
      _logger = logger;
      _signInManager = signInManager;
      _userManager = userManager;
    }

    [HttpGet("signin")]
    public IActionResult SignIn()
    {
      return View();
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
      if (ModelState.IsValid)
      {
        User user = await _userManager.Users
                                      .Where(u => u.Email == model.Email)
                                      .FirstOrDefaultAsync();
        if (user != null)
        {
          var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
          if (result.Succeeded)
          {
            _logger.LogInformation($"account/signin: User {user.Email} successfully signed in");
            return RedirectToAction("Index", "Home");
          }
        }
        ModelState.AddModelError(string.Empty, "Wrong email or password");
      }
      return View(model);
    }

    [HttpGet("signup")]
    public IActionResult SignUp()
    {
      return View();
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
      if (ModelState.IsValid)
      {
        Console.WriteLine("here");
        User user = new User() { Email = model.Email, UserName = model.Username };
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          _logger.LogInformation($"account/signup: User {user.Email} successfully signed up");
          return RedirectToAction("Index", "Home");
        }
        else
          foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);
      }
      return View(model);
    }

    [HttpGet("signout")]
    public async Task<IActionResult> SignOut()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
  }
}
