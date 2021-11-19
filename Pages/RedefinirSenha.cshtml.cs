using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace OpenHealthWeb.Pages
{
    public class RedefinirSenhaModel : PageModel
    {
        [BindProperty]
        public Redefinir Redefinir { get; set; }
        public string[] Tipos = new[] { "Paciente", "Profissional" };

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Redefinir.Senha != null && Redefinir.Senha != null)
            {

            }
            return null;
        }
    }

    public class Redefinir
    {
        public string SenhaConfirmar { get; set; }
        public string Senha { get; set; }
        public string TipoLogin { get; set; } = "Paciente";
    }
}
