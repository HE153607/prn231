using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenAndAuthor.Pages
{
    [AllowAnonymous]
    public class AnonymousModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
