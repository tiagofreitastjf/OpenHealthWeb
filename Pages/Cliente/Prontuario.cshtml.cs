using Microsoft.AspNetCore.Http;
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
            else if (HttpContext.Session.GetString("tipoUsuario") == "Profissional")
            {
                return Redirect("/Profissional/Prontuario?idProfissional" + HttpContext.Session.GetString("idUsuario"));
            }

            return null;
        }
    }
}
