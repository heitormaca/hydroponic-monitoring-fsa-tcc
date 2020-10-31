using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Hydroponics.Repositories;
using Hydroponics.Useful;
using Hydroponics.ViewModel;
using Hydroponics.Models;

namespace Hydroponics.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class LoginController : ControllerBase
    {
        LoginRepositorio loginRepositorio = new LoginRepositorio();
        Cryptography encrypt = new Cryptography();
        private IConfiguration configuracao;
        public LoginController(IConfiguration config)
        {
            configuracao = config;
        }
        private string GenerateJSONWebToken(Produtor userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracao["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
                new Claim ("id", userInfo.IdProdutor.ToString())
            };
            var token = new JwtSecurityToken(configuracao["Jwt:Issuer"],
                configuracao["Jwt:Issuer"], claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Produtor Autenticacao(LoginViewModel login)
        {
            var senhaEncrypt = encrypt.Encrypt(login.Senha);
            login.Senha = senhaEncrypt;
            Produtor usuario = loginRepositorio.Login(login);
            return usuario;
        }
        /// <summary>
        /// Método para logar no sistema.
        /// </summary>
        /// <param name="login">Envia um email e uma senha.</param>
        /// <returns>Retorna o token de acesso.</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostLogin([FromBody] LoginViewModel login)
        {
            try
            {
                IActionResult response = Unauthorized("Usuário ou senha incorreto.");
                var user = Autenticacao(login);
                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenString });
                }
                return response;
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}