using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using BankApi.DataAccess;
using Microsoft.Extensions.Configuration;
using BankApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using BankApiFinder.API.Controllers;

namespace BankApiFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        private readonly IConfiguration _configuration;

        public AuthController(UserDbContext userDbContext, IConfiguration configuration)
        {
            _userDbContext = userDbContext;
            _configuration = configuration;
        }

       /* [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _userDbContext.Users.AnyAsync(u => u.username == user.username))
                return BadRequest("Kullanıcı adı zaten var");

            _userDbContext.Users.Add(user);
            await _userDbContext.SaveChangesAsync();

            return Ok("Kullanıcı girişi başarılı.");
        }*/

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var userLogin = await _userDbContext.Users.FirstOrDefaultAsync(u => u.username == user.username);
            if (userLogin == null || userLogin.password != user.password)
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");

            var token = GenerateJwtToken(userLogin);
            return Ok(new { token });
        }
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
    new Claim(JwtRegisteredClaimNames.Sub, user.username),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}