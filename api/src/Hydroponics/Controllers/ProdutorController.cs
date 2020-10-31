using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.Repositories;
using Hydroponics.Useful;
using Hydroponics.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hydroponics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutorController : ControllerBase
    {
        ProdutorRepositorio repository = new ProdutorRepositorio();
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
                var idDoProdutor = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var pdt = await repository.GetById(int.Parse(idDoProdutor));
                return Ok(pdt);
            }
            catch (System.Exception e)
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
                var listUser = await repository.GetList();
                foreach (var item in listUser)
                {
                    if (produtor.Email == item.Email)
                    {
                        return BadRequest("Este email já possui um cadastro.");
                    }
                }
                var senhaEncrypt = encrypt.Encrypt(produtor.Senha);
                produtor.Senha = senhaEncrypt;
                return Ok(await repository.Post(produtor));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para atualizar a senha do usuário.
        /// </summary>
        /// <param name = "model" > Envia uma senha.</param>
        /// <returns>Retorna um valor vazio ou erro 500.</returns>

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] updatePasswordViewModel model)
        {
            try
            {
                var idDoProdutor = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var pdt = await repository.GetById(int.Parse(idDoProdutor));
                pdt.Senha = model.Senha;
                var senhaEncrypt = encrypt.Encrypt(model.Senha);
                pdt.Senha = senhaEncrypt;
                await repository.Put(pdt);
                return Ok();
            }
            catch (System.Exception e)
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
                var idDoProdutor = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var pdt = await repository.GetById(int.Parse(idDoProdutor));
                var arquivo = Request.Form.Files[0];
                pdt.Imagem = image.Upload(arquivo, "Resourses/images");
                await repository.Put(pdt);
                return Ok();
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para enviar um email com uma nova senha para o usuário que à esqueceu.
        /// </summary>
        /// <param name = "verificacao" > Envia um email.</param>
        /// <returns>Retorna um valor vazio ou erro 500.</returns>

        [AllowAnonymous]
        [HttpPatch("forgotPassword")]
        public async Task<IActionResult> PostForgotPassword([FromBody] ForgotPasswordViewModel verificacao)
        {
            try
            {
                IActionResult response = Unauthorized("Dados inválidos.");
                var pdt = AutenticacaoEmail(verificacao);
                if (pdt != null)
                {
                    string novaSenha = "CIFV@Y#" + pdt.Email.Length.ToString();
                    var senhaEncrypy = encrypt.Encrypt(novaSenha);
                    pdt.Senha = senhaEncrypy;
                    await repository.Put(pdt);
                    string email = pdt.Email;
                    string titulo = "Alteração de senha Hydroponics";
                    string body = $"<h1>Alteração de senha Hydroponics</h1>" +
                                  $"<br>" +
                                  $"<br>" +
                                  $"<p>Prezado(a) {pdt.Nome},</p>" +
                                  $"<br>" +
                                  $"<p>Atendendo ao seu pedido, segue abaixo a sua nova senha." +
                                  $"<p>Nova senha: {novaSenha}</p>" +
                                  $"<br>" +
                                  $"<p><strong>ATENÇÂO:<strong> Está é uma senha provisória, favor altera-la após o seu login.</p>";
                    sendEmail.EnvioEmail(email, titulo, body);
                    return Ok();
                }
                else
                {
                    return response;
                }
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        private Produtor AutenticacaoEmail(ForgotPasswordViewModel verificacao)
        {
            Produtor usuario = repository.VerificacaoEmail(verificacao);
            return usuario;
        }
    }
}