using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebApplication1.Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        [HttpPost]
        [Route("/token/create")]
        public IActionResult Create(string username, string password)
        {

            if(CombinaSenhaNomeValido(username, password))
            {
                return new ObjectResult(GerarToken(username));
            }

            return BadRequest();
        }

        [Route("/token/gerartoken")]
        private object GerarToken(string username)
        {

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };


            //Token = header + payload(claims) + signature (chave simétrica + segredo)
            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("adriana.carvsilva")), SecurityAlgorithms.HmacSha256)),
                                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool CombinaSenhaNomeValido(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && username == password;
        }


    }
}