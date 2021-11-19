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
                if (Login.Paciente == true) Login.TipoLogin = "Paciente";
                if (Login.Profissional == true) Login.TipoLogin = "Profissional";
                JObject json = await Usuario.Login(Login.Email, Login.Senha, Login.TipoLogin == "Paciente");

                string returno = json.SelectToken("userNotFound") != null ? json.SelectToken("userNotFound").ToString() : null;
                if (Convert.ToBoolean(returno))
                {

                }
                else
                {
                    HttpContext.Session.Set("Token", Encoding.ASCII.GetBytes(Usuario.GerarToken(json["nome"].ToString(), json["email"].ToString())));
                    //HttpContext.Session.SetString("idClinica", json["idClinica"].ToString());
                    HttpContext.Session.SetString("idUsuario", json["id"].ToString());
                    HttpContext.Session.SetString("tipoUsuario", Login.TipoLogin);
                    await HttpContext.Session.CommitAsync();
                    await HttpContext.Session.LoadAsync();
                    byte[] session;
                    if (HttpContext.Session.TryGetValue("Token", out session))
                    {
                        if (HttpContext.Session.GetString("tipoUsuario") == "Paciente") return Redirect("/Cliente/Prontuario?idCliente=" + HttpContext.Session.GetString("idUsuario"));
                        if (HttpContext.Session.GetString("tipoUsuario") == "Profissional") return Redirect("/Profissional/Prontuario?idProfissional" + HttpContext.Session.GetString("idUsuario"));
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
        public string TipoLogin { get; set; } = "Paciente";
        public bool Paciente { get; set; }
        public bool Profissional { get; set; }
    }
}
