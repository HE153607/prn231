using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AuthenAndAuthor.Pages.User
{
    [Authorize(Roles = "User")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
