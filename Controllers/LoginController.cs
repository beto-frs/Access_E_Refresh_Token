using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("auth")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserInputModel model)
        {
            //Recupera User
            var user = UserRepository.Get(model.Username, model.Password);

            //Verifica se existe
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
            //Gera Token
            var token = TokenService.GenerateToken(user);
            var refreshToken = TokenService.GenerateRefreshToken();
            TokenService.SaveRefreshToken(user.Username, refreshToken);

            //Oculta a senha
            user.Password = "";

            //Retorna os dados
            return new
            {
                //user = user,
                token = token,
                //create = DateTime.Now.ToString("g"),
                //validate = DateTime.Now.AddMinutes(30).ToString("g"),
                refreshToken = refreshToken
            };

        }

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<dynamic>> Refresh([FromBody] InputRefreshModel inputRefresh)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(inputRefresh.token);
            var username = principal.Identity.Name;
            var savedRefreshToken = TokenService.GetRefreshToken(username);
            if (savedRefreshToken != inputRefresh.refreshToken)
            {
                throw new SecurityTokenException("Inválido Refresh");
            }

            var newJwtToken = TokenService.GenerateToken(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();
            TokenService.DeleteRefreshToken(username, inputRefresh.refreshToken);
            TokenService.SaveRefreshToken(username, newRefreshToken);

            return new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken,
                //create = DateTime.Now.ToString("g"),
                validate = DateTime.Now.AddMinutes(30).ToString("g")
                //usuario = principal.Identity.Name
            };
        }
    }
}
