using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenHealthWeb
{
    public class Usuario
    {
        public async static Task<JObject> Login(string email, string senha, bool cliente)
        {
            try
            {
                HttpClient client = new HttpClient();
                var sJson = new { Email = email, Senha = senha };
                string jsonSerialize = JsonConvert.SerializeObject(sJson, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                string link = "";
                if (cliente) link = "http://localhost:5000/Cliente/login";
                else link = "http://localhost:5000/Profissional/login";
                HttpResponseMessage response = await client.PostAsync(link, new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json"));
                string content = await response.Content.ReadAsStringAsync();
                return JObject.Parse(content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GerarToken(string nome, string email)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("OpenHealthSecretKeyfedaf7d8863b48e197b9287d492b708e");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, nome),
                        new Claim(ClaimTypes.Email, email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
