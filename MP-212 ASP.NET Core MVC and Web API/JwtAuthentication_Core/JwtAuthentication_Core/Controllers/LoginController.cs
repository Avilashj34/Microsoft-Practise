using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using JwtAuthentication_Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace JwtAuthentication_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _congif;

        public LoginController(IConfiguration congif)
        {
            _congif = congif;
        }

        [HttpGet]
        public IActionResult Login(string username, string pass)
        {
            UserModel login = new UserModel
            {
                UserName = username,
                Password = pass
            };
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user!=null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token= tokenStr});
            }
            return response;
        }

        private string GenerateJSONWebToken(UserModel user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_congif["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub,user.Password),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
            issuer: _congif["Jwt:Issuer"],
            audience: _congif["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        public UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;
            if (login.UserName=="avilashjha" && login.Password =="Qwerty@123")
            {
                user = new UserModel {UserName="Avilash Jha",Password="Qwerty@123",EmailAddress="avi@gmail.com" };
            }
            return user;
        }

        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "welcome to " + userName;
        }

        [HttpGet("GetValues")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"Value1","Value2" };
        }
    }
}