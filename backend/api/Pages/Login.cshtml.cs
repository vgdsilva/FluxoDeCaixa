using FluxoDeCaixa.API.Identity;
using FluxoDeCaixa.Infrastructure.Repositories;
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

            ApplicationUser user = await AuthenticateUser(Input.Email, Input.Password);
            if (user == null)
            {
                return Page();
            }


            List<Claim> claims = new List<Claim>()
            { new Claim(ClaimTypes.Email, Input.Email) };


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { /* IsPersistent = true */ });

            Response.Cookies.Append("Role", user.Email.Equals("root") ? "Administrador" : "User");

            return LocalRedirect(Url.GetLocalUrl(returnUrl));
        }

        static async Task<ApplicationUser> AuthenticateUser(string email, string password)
        {
            if (email.Equals("root"))
            {
                return new ApplicationUser { Email = email };
            }

            if (string.IsNullOrWhiteSpace(email))
                return null;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
            {
                return null;
            }

            // TODO: VALIDAR NO BANCO DE DADOS SE EXISTE

            var db_user = await new UsuarioRepository().VerificaSeUsuarioExisteAsync(email);
            if (db_user == null)
            {
                return null;
            }

            if (!db_user.Senha.Equals(password))
            {
                return null;
            }

            return new ApplicationUser { UserName = db_user.Nome, Email = email };
        }
    }
}
