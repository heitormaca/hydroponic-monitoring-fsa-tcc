using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.Repositorios;
using Hydroponics.Useful;
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
                return StatusCode (500, e);
            }
            return Ok(usuario);
        }   
    }
}