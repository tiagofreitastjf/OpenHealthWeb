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
            //byte[] session;
            //if (!HttpContext.Session.TryGetValue("Token", out session))
            //{
            //    return Redirect("/Login");
            //}
            return Redirect("/Cliente/Prontuario");
            return null;
        }
    }
}
