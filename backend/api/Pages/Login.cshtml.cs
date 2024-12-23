using FluxoDeCaixa.API.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace FluxoDeCaixa.API.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UsuarioModel Input { get; set; }

        public class UsuarioModel
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = AuthenticateUser(Input.Email, Input.Password);
            if (user == null)
            {
                return Page();
            }


            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, Input.Email)
            };


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { /* IsPersistent = true */ });

            Response.Cookies.Append("Role", "User");

            return LocalRedirect(Url.GetLocalUrl(returnUrl));
        }

        static ApplicationUser AuthenticateUser(string email, string password)
        {
            if (email.Equals("root"))
            {
                return new ApplicationUser { Email = "root" };
            }

            if (string.IsNullOrWhiteSpace(email))
                return null;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
            {
                return null;
            }

            // TODO: VALIDAR NO BANCO DE DADOS SE EXISTE

            return new ApplicationUser { Email = email };
        }
    }
}
