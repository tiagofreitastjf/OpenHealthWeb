using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenHealthWeb.Pages.Profissional
{
    public class AgendaModel : PageModel
    {
        public IActionResult OnGet()
        {
            string id = HttpContext.Request.Query["idProfissional"];

            byte[] session;
            if (!HttpContext.Session.TryGetValue("Token", out session))
            {
                return Redirect("/Login");
            }
            else if (HttpContext.Session.GetString("tipoUsuario") == "Cliente")
            {
                return Redirect("/Cliente/Prontuario?idProfissional=" + HttpContext.Session.GetString("idUsuario"));
            }
            else if (id == null)
            {
                return Redirect("/Profissional/Agenda?idProfissional=" + HttpContext.Session.GetString("idUsuario"));
            }

            return null;
        }
    }
}
