using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.Repositories;
using Hydroponics.Useful;
using Hydroponics.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hydroponics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutorController : ControllerBase
    {
        ProdutorRepository repository = new ProdutorRepository();
        Cryptography encrypt = new Cryptography();
        Email sendEmail = new Email();
        UploadImage image = new UploadImage();

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
        /// <param name = "produtor" > Envia um nome, email e senha.</param>
        /// <returns>Retorna o usuário cadastrado ou erro 500.</returns>

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
        /// <param name = "password" > Envia uma senha.</param>
        /// <returns>Retorna um valor vazio ou erro 500.</returns>

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] updatePasswordViewModel password)
        {
            try
            {
                var idProdutor = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var produtor = await repository.GetById(int.Parse(idProdutor));
                produtor.Senha = password.Senha;
                var EncryptPass = encrypt.Encrypt(password.Senha);
                produtor.Senha = EncryptPass;
                await repository.Put(produtor);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para atualizar a imagem do usuário logado.
        /// </summary>
        /// <returns>Retorna um valor vazio ou erro 500.</returns>
        [Authorize]
        [HttpPut("userImage")]
        public async Task<IActionResult> PutImage()
        {
            try
            {
                var idProdutor = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var produtor = await repository.GetById(int.Parse(idProdutor));
                var file = Request.Form.Files[0];
                produtor.Imagem = image.Upload(file, "Resourses/images");
                await repository.Put(produtor);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para enviar um email com uma nova senha para o usuário que à esqueceu.
        /// </summary>
        /// <param name = "email" > Envia um email.</param>
        /// <returns>Retorna um valor vazio ou erro 500.</returns>

        [AllowAnonymous]
        [HttpPatch("forgotPassword")]
        public async Task<IActionResult> PostPassword([FromBody] ForgotPasswordViewModel email)
        {
            try
            {
                IActionResult response = Unauthorized("Dados inválidos.");
                var produtor = AutenticacaoEmail(email);
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
                    sendEmail.EnvioEmail(ProdutorEmail, title, body);
                    return Ok();
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

        private Produtor AutenticacaoEmail(ForgotPasswordViewModel email)
        {
            Produtor produtor = repository.EmailCheck(email);
            return produtor;
        }
    }
}