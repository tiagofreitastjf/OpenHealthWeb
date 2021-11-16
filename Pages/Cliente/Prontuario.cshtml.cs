using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenHealthWeb.Pages.Cliente
{
    public class ProntuarioModel : PageModel
    {
        public IActionResult OnGet()
        {
            byte[] session;
            if (!HttpContext.Session.TryGetValue("Token", out session))
            {
                return Redirect("/Login");
            }

            return null;
        }
    }
}
