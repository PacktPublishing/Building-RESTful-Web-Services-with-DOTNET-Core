using System.IdentityModel.Tokens.Jwt;
using Chap08_03.Midleware;
using Chap08_03.Models;
using Chap08_03.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chap08_03.Controllers
{
    [Route("api/[controller]")]
    public class GenerateTokenController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public GenerateTokenController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] AuthRequest request)
        {
            //Kept it simple for demo purpose
            var user = _loginRepository.GetBy(request.UserName, request.Password);
            if (user == null) return BadRequest("Invalid credentials.");
            var token = new TokenUtility().GenerateToken(user.UserName, user.Id.ToString());
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}