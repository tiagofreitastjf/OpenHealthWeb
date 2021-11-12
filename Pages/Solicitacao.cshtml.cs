using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenHealthWeb.Pages
{
    public class SolicitacaoModel : PageModel
    {
        public IActionResult OnGet()
        {
            //byte[] session;
            //if (!HttpContext.Session.TryGetValue("Token", out session))
            //{
            //    return Redirect("/Login");
            //}

            return null;
        }
    }
}
