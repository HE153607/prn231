using AuthenAndAuthor.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AuthenAndAuthor.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Pass { get; set; }

        private readonly DataBaseContext _context;

        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger, DataBaseContext context)
        {
            _logger = logger;
            _context = context;

        }

        public void OnGet()
        {
            
        }


        public IActionResult OnPost()
        {
             
     
             AuthenAndAuthor.Models.User user = _context.Users.Where(c => c.UserName.Equals(Name.Trim()) && c.PassWord.Equals(Pass.Trim())).FirstOrDefault();
        
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            else
            {
                //Add claims for logged in user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),

                    //get roles of user and assign it to claims, if you are using database
                    //new Claim(ClaimTypes.Role, user.Role)

                    new Claim(ClaimTypes.Role, user.Role)
                };
                var identity = new ClaimsIdentity(claims, "custom");
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7)
                });
                return RedirectToPage($"/{user.Role}/Index");

            }
        }
    }
}