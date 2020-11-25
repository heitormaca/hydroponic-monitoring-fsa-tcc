using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.Repositories;
using Hydroponics.Useful;
using Hydroponics.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Hydroponics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutorController : ControllerBase
    {
        private readonly ProdutorRepository repository;
        private readonly Cryptography encrypt;
        private readonly Email email;
        private readonly UploadImage image;
        private readonly IConfiguration config;
        public ProdutorController(ProdutorRepository repository, Cryptography encrypt, Email email, UploadImage image, IConfiguration config)
        {
            this.config = config;
            this.repository = repository;
            this.encrypt = encrypt;
            this.email = email;
            this.image = image;
        }
        private async Task<Produtor> EmailAuthorization(sendPassViewModel _email)
        {
            return await repository.EmailCheck(_email);   
        }
        private async Task<Produtor> Authorization(LoginViewModel login)
        {
            var senhaEncrypt = encrypt.Encrypt(login.Senha);
            login.Senha = senhaEncrypt;
            Produtor produtor = await repository.Login(login);
            return produtor;
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

        /// <summary>
        /// Método para logar no sistema.
        /// </summary>
        /// <param name="login">Envia um email e uma senha.</param>
        /// <returns>Retorna o token de acesso.</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginViewModel login)
        {
            try
            {
                IActionResult response = Unauthorized("Usuário ou senha incorreto.");
                var produtor = await Authorization(login);
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


        /// <summary>
        /// Método para buscar os dados do usuário logado.
        /// </summary>
        /// <returns>Retorna os dados do usuário logado ou Erro 500.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var idProdutor = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var produtor = await repository.GetById(int.Parse(idProdutor));
                return Ok(produtor);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para cadastrar um usuário no sistema.
        /// </summary>
        /// <param name = "produtor" >Envia um nome, email e senha.</param>
        /// <returns>Retorna uma mensagem de sucesso ou erro 500.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(Produtor produtor)
        {
            try
            {
                var listProdutor = await repository.GetList();
                foreach (var item in listProdutor)
                {
                    if (produtor.Email == item.Email)
                    {
                        return BadRequest("Este email já possui um cadastro.");
                    }
                }
                var EncryptPass = encrypt.Encrypt(produtor.Senha);
                produtor.Senha = EncryptPass;
                await repository.Post(produtor);
                return Ok("Seu cadastro foi efetuado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para atualizar a senha do usuário.
        /// </summary>
        /// <param name = "password" >Envia uma senha.</param>
        /// <returns>Uma mensagem de sucesso ou erro 500.</returns>
        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePassViewModel password)
        {
            try
            {
                var idProdutor = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var produtor = await repository.GetAllById(int.Parse(idProdutor));
                produtor.Senha = password.Senha;
                var EncryptPass = encrypt.Encrypt(password.Senha);
                produtor.Senha = EncryptPass;
                await repository.Put(produtor);
                return Ok("Sua senha foi alterada com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para atualizar a imagem do usuário logado.
        /// </summary>
        /// <returns>Retorna uma mensagem de sucesso ou erro 500.</returns>
        [Authorize]
        [HttpPut("userImage")]
        public async Task<IActionResult> PutImage()
        {
            try
            {
                var idProdutor = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var produtor = await repository.GetAllById(int.Parse(idProdutor));
                var file = Request.Form.Files[0];
                produtor.Imagem = image.Upload(file, "Resourses/images");
                await repository.Put(produtor);
                return Ok("Sua imagem foi atualizada com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para enviar um email com uma nova senha para o usuário que à esqueceu.
        /// </summary>
        /// <param name = "_email" >Envia um email.</param>
        /// <returns>Retorna uma mensagem de sucesso ou erro 500.</returns>
        [AllowAnonymous]
        [HttpPatch("forgotPassword")]
        public async Task<IActionResult> PostPassword([FromBody] sendPassViewModel _email)
        {
            try
            {
                IActionResult response = Unauthorized("Dados inválidos.");
                var produtor = await EmailAuthorization(_email);
                if (produtor != null)
                {
                    string newPass = "CIFV@Y#" + produtor.Email.Length.ToString();
                    var EncryptPass = encrypt.Encrypt(newPass);
                    produtor.Senha = EncryptPass;
                    await repository.Put(produtor);
                    string ProdutorEmail = produtor.Email;
                    string title = "Alteração de senha Hydroponics";
                    string body = $"<h1>Alteração de senha Hydroponics</h1>" +
                                  $"<br>" +
                                  $"<br>" +
                                  $"<p>Prezado(a) {produtor.Nome},</p>" +
                                  $"<br>" +
                                  $"<p>Atendendo ao seu pedido, segue abaixo a sua nova senha." +
                                  $"<p>Nova senha: {newPass}</p>" +
                                  $"<br>" +
                                  $"<p><strong>ATENÇÂO:<strong> Está é uma senha provisória, favor altera-la após o seu login.</p>";
                    email.SendEmail(ProdutorEmail, title, body);
                    return Ok("Sua senha foi alterada com sucesso, verifique a sua caixa de e-mail para resgata-lá!");
                }
                else
                {
                    return response;
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}