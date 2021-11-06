using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenHealthWeb.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Login { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Login.Email != null && Login.Senha != null)
            {
                JObject json = await Usuario.Login(Login.Email, Login.Senha, Login.TipoLogin == "Paciente");

                string returno = json.SelectToken("userNotFound") != null ? json.SelectToken("userNotFound").ToString() : null;
                if (Convert.ToBoolean(returno))
                {

                }
                else
                {
                    HttpContext.Session.Set("Token", Encoding.ASCII.GetBytes(Usuario.GerarToken(json["nome"].ToString(), json["email"].ToString())));
                    HttpContext.Session.SetString("idClinica", json["idClinica"].ToString());
                    HttpContext.Session.SetString("idUsuario", json["id"].ToString());
                    HttpContext.Session.SetString("tipoUsuario", Login.TipoLogin);
                    await HttpContext.Session.CommitAsync();
                    await HttpContext.Session.LoadAsync();
                    byte[] session;
                    if (HttpContext.Session.TryGetValue("Token", out session))
                    {
                        return Redirect("/Index");
                    }
                }
            }
            return null;
        }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string TipoLogin { get; set; } = "Profissional";
    }
}
