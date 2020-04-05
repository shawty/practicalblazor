﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace practicalblazor.Pages
{
  [Authorize]
  public class LogoutModel : PageModel
  {
    public async Task<IActionResult> OnGetAsync()
    {
      // Clear the existing external cookie
      await HttpContext
        .SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);

      return LocalRedirect(Url.Content("~/Login"));
    }
  }
}