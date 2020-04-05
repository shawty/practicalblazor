using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using dsnetops.Datamodels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using practicalblazor.Services;

namespace practicalblazor.Pages
{
  [AllowAnonymous]
  public class LoginModel : PageModel
  {
    private readonly Users _usersService;

    [BindProperty]
    public LoginData loginData { get; set; }

    public string ReturnUrl { get; set; } = "";

    [BindProperty]
    public string AlertMessage { get; set; } = "";

    public LoginModel(Users usersService)
    {
      _usersService = usersService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        AlertMessage = "Form has validation errors.";
        return Page();
      }

      //try
      //{
        _usersService.Authenticate(loginData.UserName, loginData.Password);
      //}
      //catch (UserVerificationFailedException)
      //{
      //  AlertMessage = "User name and password not recognized";
      //  return Page();
      //}

      string returnUrl = Url.Content("~/");
      var userRecord = _usersService.FetchUser(loginData.UserName);

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, userRecord.LoginName),
        new Claim("FullName", $"{userRecord.FirstName} {userRecord.LastName}"),
        new Claim(ClaimTypes.Role, "User")
      };

      // You can add as many roles as you like, these can be used in blazor components
      // using normal roles/auth attributes
      //claims.Add(new Claim(ClaimTypes.Role, "Editor"));
      //claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

      AuthenticationProperties authProperties = new AuthenticationProperties
      {
        //AllowRefresh = <bool>,
        // Refreshing the authentication session should be allowed.

        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
        // The time at which the authentication ticket expires. A 
        // value set here overrides the ExpireTimeSpan option of 
        // CookieAuthenticationOptions set with AddCookie.

        //IsPersistent = true,
        // Whether the authentication session is persisted across 
        // multiple requests. When used with cookies, controls
        // whether the cookie's lifetime is absolute (matching the
        // lifetime of the authentication ticket) or session-based.

        //IssuedUtc = <DateTimeOffset>,
        // The time at which the authentication ticket was issued.

        //RedirectUri = <string>
        // The full path or absolute URI to be used as an http 
        // redirect response value.
      };

      await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(claimsIdentity),
        authProperties);

      return LocalRedirect(returnUrl);
    }
  }
}