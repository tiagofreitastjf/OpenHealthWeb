using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenHealthWeb.Pages.Profissional
{
    public class FichaConsultaModel : PageModel
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
