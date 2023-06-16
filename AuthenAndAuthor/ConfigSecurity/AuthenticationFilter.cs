using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AuthenAndAuthor.Filters
{
    public class AuthenticationFilter
    {
        private readonly RequestDelegate _next;

        public AuthenticationFilter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var user = context.User;

            // Tạo một định danh mới
            var identity = new ClaimsIdentity();

            // Thêm các thông tin định danh (claims) vào đối tượng định danh
            identity.AddClaim(new Claim(ClaimTypes.Name, "John Doe"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

            // Thêm định danh vào đối tượng người dùng
            context.SignInAsync(new ClaimsPrincipal(identity));
            var path = context.Request.Path;
            if (path.HasValue && path.Value.StartsWith("/login"))
            {
                await _next(context);
                return;
            }
            if (path.HasValue && path.Value.StartsWith("/Admin"))
            {
                if(context.Session.GetString("admin") == null)
                {
                    context.Response.Redirect("/login");
                }
            }
             
            else
            {
                if(!context.User.Identity.IsAuthenticated)
                {
                    context.Response.Redirect("/login");
                }
            }
            await _next(context);
        }
    }
}
