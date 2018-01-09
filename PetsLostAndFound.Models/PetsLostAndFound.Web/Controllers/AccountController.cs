namespace PetsLostAndFound.Web.Controllers
{
  using Microsoft.AspNetCore.Authentication;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Logging;
  using PetsLostAndFound.Db.Models;
  using PetsLostAndFound.Web.Models.AccountViewModels;
  using PetsLostAndFound.Web.Services;
  using System;
  using System.Threading.Tasks;


  [Authorize]
  public class AccountController : BaseController
  {
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IEmailSender emailSender;
    private readonly ILogger logger;

    public AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IEmailSender emailSender,
        ILogger<AccountController> logger)
    {
      this.userManager = userManager;
      this.signInManager = signInManager;
      this.emailSender = emailSender;
      this.logger = logger;
    }


    [TempData]
    public string ErrorMessage { get; set; }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string returnUrl = null)
    {
      await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

      ViewData["ReturnUrl"] = returnUrl;

      return this.Ok();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([FromBody] PostLoginRequrestModel model, string returnUrl = null)
    {
      ViewData["ReturnUrl"] = returnUrl;
      if (ModelState.IsValid)
      {
        var result = await this.signInManager
          .PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
        if (result.Succeeded)
        {
          this.logger.LogInformation("User logged in.");
          return RedirectToLocal(returnUrl);
        }
        else
        {
          ModelState.AddModelError(string.Empty, "Invalid login attempt.");
          return BadRequest();
        }
      }

      return this.Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register(string returnUrl = null)
    {
      ViewData["ReturnUrl"] = returnUrl;
      return Ok();
    }

    [HttpPost]
    [AllowAnonymous]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromBody] PostRegisterRequestModel model, string returnUrl = null)
    {
      ViewData["ReturnUrl"] = returnUrl;
      if (ModelState.IsValid)
      {
        var user = new User { UserName = model.Username, Email = model.Email };
        var result = await this.userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          this.logger.LogInformation("User created a new account with password.");
          var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);

          await this.signInManager.SignInAsync(user, isPersistent: false);
          this.logger.LogInformation("User created a new account with password.");

          return RedirectToLocal(returnUrl);
        }
        AddErrors(result);
      }
      // If we got this far, something failed, redisplay form
      return Ok(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
      await this.signInManager.SignOutAsync();
      this.logger.LogInformation("User logged out.");

      return this.Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPassword()
    {
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
      if (ModelState.IsValid)
      {
        var user = await this.userManager.FindByEmailAsync(model.Email);
        if (user == null || !(await this.userManager.IsEmailConfirmedAsync(user)))
        {
          return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
        
        var code = await this.userManager.GeneratePasswordResetTokenAsync(user);

        return RedirectToAction(nameof(ForgotPasswordConfirmation));
      }
      
      return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPasswordConfirmation()
    {
      return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPassword(string code = null)
    {
      if (code == null)
      {
        throw new ApplicationException("A code must be supplied for password reset.");
      }
      var model = new ResetPasswordViewModel { Code = code };
      return View(model);
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      var user = await this.userManager.FindByEmailAsync(model.Email);
      if (user == null)
      {
        return RedirectToAction(nameof(ResetPasswordConfirmation));
      }
      var result = await this.userManager.ResetPasswordAsync(user, model.Code, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction(nameof(ResetPasswordConfirmation));
      }
      AddErrors(result);
      return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPasswordConfirmation()
    {
      return View();
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
      return View();
    }

    #region Helpers

    private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError(string.Empty, error.Description);
      }
    }

    private IActionResult RedirectToLocal(string returnUrl)
    {
      if (Url.IsLocalUrl(returnUrl))
      {
        return Redirect(returnUrl);
      }
      else
      {
        return RedirectToAction(nameof(HomeController.Index), "Home");
      }
    }

    #endregion
  }
}
