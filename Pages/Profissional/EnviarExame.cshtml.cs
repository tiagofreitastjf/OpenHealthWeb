using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenHealthWeb.Pages.Profissional
{
    public class EnviarExameModel : PageModel
    {
        public IActionResult OnGet()
        {
            byte[] session;
            if (!HttpContext.Session.TryGetValue("Token", out session))
            {
                return Redirect("/Login");
            }
            else if (HttpContext.Session.GetString("tipoUsuario") == "Paciente")
            {
                return Redirect("/Cliente/Prontuario?idCliente=" + HttpContext.Session.GetString("idUsuario"));
            }

            return null;
        }
    }
}
