using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHealthWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            byte[] session;
            if (!HttpContext.Session.TryGetValue("Token", out session))
            {
                return Redirect("/Login");
            }
            else
            {
                if (HttpContext.Session.GetString("tipoUsuario") == "Paciente") return Redirect("/Cliente/Prontuario?idCliente=" + HttpContext.Session.GetString("idUsuario"));
                if (HttpContext.Session.GetString("tipoUsuario") == "Profissional") return Redirect("/Profissional/Prontuario?idProfissional=" + HttpContext.Session.GetString("idUsuario"));
            }
            //return Redirect($"/Cliente/Prontuario?idCliente=1");
            return null;
        }
    }
}
