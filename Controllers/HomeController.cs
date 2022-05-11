using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Authorize]
    [Route("user")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Usuário Autenticado --> {User.Identity.Name}";

        [HttpGet]
        [Route("user")]
        [Authorize(Roles = "admin,user")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin,user")]
        public string Manager() => "Gerente";
    }
}
