using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenHealthWeb.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("idClinica");
            HttpContext.Session.Remove("idUsuario");
            HttpContext.Session.Remove("tipoUsuario");
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }
    }
}
