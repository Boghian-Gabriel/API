using API.Context;
using API.Model;
using API.ModelsDTO.UserDto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class AuthenticationController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly ContextDB _context;
        public readonly IMapper _mapper;
        public AuthenticationController(IConfiguration configuration, ContextDB context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        #region "Login"
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            try
            {
                var dbUser = await _context.Users
                       .Where(u => u.UserName == userDTO.UserName && u.Password == userDTO.Password)
                       .SingleOrDefaultAsync();

                if (dbUser == null)
                {
                    return BadRequest("User or password is incorrect");
                }

                var token = this.getToken(dbUser);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expire = token.ValidTo
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error" + ex.Message);
            }
        }
        #endregion

        #region "Register"
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                var dbUser = await _context.Users
                       .Where(u => u.UserName == userDTO.UserName && u.Password == userDTO.Password)
                       .SingleOrDefaultAsync();

                if (dbUser != null)
                {
                    return BadRequest("User or password is already exists");
                }
                var user = _mapper.Map<User>(userDTO);
                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok("User is successfully registered");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error" + ex.Message);
            }
        }
        #endregion

        [HttpGet("GetUsers")]
        [Authorize]
        public async Task<ActionResult<UserNameDTO>> GetUsers()
        {
            try
            {
                var user = await _context.Users.ToListAsync();
                if (user != null)
                {
                    var userMapper = _mapper.Map<IEnumerable<UserNameDTO>>(user);
                    return Ok(userMapper);
                }
                else 
                {
                    return BadRequest("There is no infromation");
                }
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }

        private JwtSecurityToken getToken(User user)
        {
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            
            var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.UserId.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Password", user.Password)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );

            return token;
        }
        

        //#region "Post"
        //[HttpPost]
        //public async Task<IActionResult> Post(User user)
        //{
        //    sign in
        //    if (user != null && user.UserName != null && user.Password != null)
        //    {
        //        var userData = await GetUser(user.UserName, user.Password);
        //        var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
        //        if (user != null)
        //        {
        //            var claims = new[]
        //            {
        //                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //                new Claim("Id", user.UserId.ToString()),
        //                new Claim("UserName", user.UserName),
        //                new Claim("Password", user.Password)
        //            };

        //            generate token
        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
        //            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //            var token = new JwtSecurityToken(
        //                jwt.Issuer,
        //                jwt.Audience,
        //                claims,
        //                expires: DateTime.Now.AddMinutes(20),
        //                signingCredentials: signIn
        //                );
        //            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        //        }
        //        else
        //        {
        //            return BadRequest("Invalid Credentials");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid Credentials");
        //    }
        //}
        //#endregion
        //#region "GetUser"
        //[HttpGet]
        //public async Task<ActionResult<User>> GetUser(string userName, string password)
        //{
        //    return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

        //    if (_context.Users == null)
        //    {
        //        return NotFound();
        //    }
        //    List<User> users = new List<User>();
        //    users = await _context.Users.ToListAsync();
        //    var result = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return result;
        //}
        //#endregion
    }
    #endregion
}
