using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenHealthWeb.Pages.Cliente
{
    public class AgendaModel : PageModel
    {
        public IActionResult OnGet()
        {
            string id = HttpContext.Request.Query["idCliente"];

            byte[] session;
            if (!HttpContext.Session.TryGetValue("Token", out session))
            {
                return Redirect("/Login");
            }
            else if (HttpContext.Session.GetString("tipoUsuario") == "Profissional")
            {
                return Redirect("/Profissional/Prontuario?idProfissional=" + HttpContext.Session.GetString("idUsuario"));
            }
            else if (id == null)
            {
                return Redirect("/Cliente/Agenda?idCliente=" + HttpContext.Session.GetString("idUsuario"));
            }

            return null;
        }
    }
}
