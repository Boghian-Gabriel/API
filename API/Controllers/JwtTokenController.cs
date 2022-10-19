using API.Context;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    #region "Jwt class"
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly ContextDB _context;

        public JwtTokenController(IConfiguration configuration, ContextDB context)
        {
            _configuration = configuration;
            _context = context;
        }
         
        #region "Post"
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            //sign in
            if (user != null && user.UserName != null && user.Password != null)
            {
                var userData = await GetUser(user.UserName, user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.UserId.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Password", user.Password)
                    };

                    //generate token
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires:DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else {
                return BadRequest("Invalid Credentials");
            }
        }
        #endregion

        #region "GetUser"
        [HttpGet]
        public async Task<ActionResult<User>> GetUser(string userName, string password)
        {
            //return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

            if (_context.Users == null)
            {
                return NotFound();
            }
            //List<User> users = new List<User>();
            //users = await _context.Users.ToListAsync();
            var result = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        #endregion
    }
    #endregion
}
