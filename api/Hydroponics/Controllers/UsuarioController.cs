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

        /// <summary>
        /// Método para cadastrar usuário comum ou administrador no sistema.
        /// </summary>
        /// <param name="usuario">Envia nome completo, nome de usuário, email e senha.</param>
        /// <returns>Retorna os dados do usuário recém cadastrado.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {  
            try
            {
                var senhaEncrypt = encrypt.Encrypt(usuario.Senha);
                usuario.Senha = senhaEncrypt;
                await repositorio.Post(usuario);
            }
            catch (System.Exception e) 
            {
                return StatusCode(500, e);
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Método para atualizar a senha do usuário.
        /// </summary>
        /// <param name="model">Envia a senha que seja ser atualizada.</param>
        /// <returns>Retorna a senha do usuário atualizada.</returns>
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
                return Ok(usr);
            } 
            catch(System.Exception e) 
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para enviar um email com uma nova senha para o usuário que à esqueceu.
        /// </summary>
        /// <param name="verificacao">Envia o nome completo e o email do usuário.</param>
        /// <returns>Retorna os dados do usuário com uma nova senha.</returns>
        [AllowAnonymous]
        [HttpPatch ("forgotPassword")]
        public async Task<IActionResult> PostForgotPassword([FromBody] ForgotPasswordViewModel verificacao) 
        {
            try
            {
                IActionResult response = Unauthorized("Dados inválidos.");
                var user = AutenticacaoEmail(verificacao);
                if(user != null) 
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
                    return Ok(user);
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