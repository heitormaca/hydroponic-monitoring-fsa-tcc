using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.Repositorios;
using Hydroponics.Useful;
using Hydroponics.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hydroponics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();  
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
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await repositorio.GetById(int.Parse(idDoUsuario));
                return Ok(usr);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para cadastrar um usuário no sistema.
        /// </summary>
        /// <param name="usuario">Envia um nome, email e senha.</param>
        /// <returns>Retorna o usuário cadastrado ou erro 500.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {  
            try
            {
                var senhaEncrypt = encrypt.Encrypt(usuario.Senha);
                usuario.Senha = senhaEncrypt;
                return Ok(await repositorio.Post(usuario));
            }
            catch (System.Exception e) 
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para atualizar a senha do usuário.
        /// </summary>
        /// <param name="model">Envia uma senha.</param>
        /// <returns>Retorna um valor vazio ou erro 500.</returns>
        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] updatePasswordViewModel model) 
        {
            try 
            {
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await repositorio.GetById(int.Parse(idDoUsuario));
                usr.Senha = model.Senha;
                var senhaEncrypt = encrypt.Encrypt(model.Senha);
                usr.Senha = senhaEncrypt;
                await repositorio.Put(usr);
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
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await repositorio.GetById(int.Parse(idDoUsuario));
                var arquivo = Request.Form.Files[0];
                usr.Imagem = image.Upload(arquivo,"Resourses/images");
                await repositorio.Put(usr);
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
        /// <param name="verificacao">Envia um email.</param>
        /// <returns>Retorna um valor vazio ou erro 500.</returns>
        [AllowAnonymous]
        [HttpPatch("forgotPassword")]
        public async Task<IActionResult> PostForgotPassword([FromBody] ForgotPasswordViewModel verificacao) 
        {
            try
            {
                IActionResult response = Unauthorized("Dados inválidos.");
                var user = AutenticacaoEmail(verificacao);
                if (user != null) 
                {
                    string novaSenha = "CIFV@Y#" + user.Email.Length.ToString();
                    var senhaEncrypy = encrypt.Encrypt(novaSenha);
                    user.Senha = senhaEncrypy;
                    await repositorio.Put(user);
                    string email = user.Email;
                    string titulo = "Alteração de senha Hydroponics";
                    string body = $"<h1>Alteração de senha Hydroponics</h1>" +
                                  $"<br>" +
                                  $"<br>" +
                                  $"<p>Prezado(a) {user.Nome},</p>" +
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

        private Usuario AutenticacaoEmail(ForgotPasswordViewModel verificacao) 
        {
            Usuario usuario = repositorio.VerificacaoEmail(verificacao);
            return usuario;
        }
    } 
}