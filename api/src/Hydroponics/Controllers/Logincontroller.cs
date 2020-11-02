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
        private readonly IConfiguration config;
        private readonly LoginRepository repository;
        private readonly Cryptography encrypt;
        public LoginController(LoginRepository repository, Cryptography encrypt, IConfiguration config)
        {
            this.repository = repository;
            this.encrypt = encrypt;
            this.config = config;
        }

        private string GenerateJSONWebToken(Produtor produtorInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Email, produtorInfo.Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
                new Claim ("id", produtorInfo.IdProdutor.ToString())
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Issuer"], claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Produtor Autenticacao(LoginViewModel login)
        {
            var senhaEncrypt = encrypt.Encrypt(login.Senha);
            login.Senha = senhaEncrypt;
            Produtor produtor = repository.Login(login);
            return produtor;
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
                var produtor = Autenticacao(login);
                if (produtor != null)
                {
                    var tokenString = GenerateJSONWebToken(produtor);
                    response = Ok(new { token = tokenString });
                }
                return response;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}