﻿using API.Context;
using API.IRepository;
using API.Model;
using API.ModelsDTO.UserDto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EntityState = System.Data.Entity.EntityState;

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
        public async Task<ActionResult<UserLoginDTO>> Login(UserLoginDTO userLogDTO)
        {
            try
            {
                var validateUser = await _context.Users
                       .Where(u => u.Email == userLogDTO.Email && u.Password == userLogDTO.Password && u.isActive == true)
                       .SingleOrDefaultAsync();

                if (validateUser == null)
                {
                    return BadRequest("Email or password is incorrect or not exists");
                }

                var dbUser = _mapper.Map<User>(userLogDTO);
                var token = this.getToken(dbUser);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expire = token.ValidTo
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Register"
        [HttpPost("Register")]
        public async Task<ActionResult<UserRegistrationDTO>> Register(UserRegistrationDTO userRegDTO)
        {
            try
            {
                var existUserEmail = await _context.Users
                                .Where(u => u.Email == userRegDTO.Email && u.isActive == true)
                                .SingleOrDefaultAsync();

                if (existUserEmail != null)
                {
                    return BadRequest($"User with email: '{userRegDTO.Email}' is already exists");
                }
                else
                {
                    var user = _mapper.Map<User>(userRegDTO);
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    return Ok("User is successfully registered");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error" + ex.Message);
            }
        }
        #endregion

        #region "Get all users"
        [HttpGet("GetUsers")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();

                if (users != null)
                {
                    var userMapper = _mapper.Map<IEnumerable<UserDTO>>(users);
                    return Ok(userMapper);
                }
                else
                {
                    return BadRequest("There is no infromation");
                }
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Get user by id"
        [HttpGet("{userId}")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetUserById(int userId)
        {
            try
            {
                //GET THE INFORMATION FROM THE DATABASE!
                var result = await _context.Users.FindAsync(userId);
                //var result = await _context.Users.FirstOrDefaultAsync(user => user.UserId == userId);

                if (result != null)
                {
                    //I map to the GenreDTO table to provide to the client
                    var resUserMapper = _mapper.Map<UserDTO>(result);
                    return Ok(resUserMapper);
                }
                else
                {
                    return NotFound($"The user with id: ' {userId} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "information search by email field"
        [HttpGet("email")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> SearchUserByEmail(string email)
        {
            try
            {
                var searchUser = await _context.Users
                                    .Where(u => u.Email == email)
                                    .SingleOrDefaultAsync();

                if (searchUser == null)
                {
                    return BadRequest($"User with email: '{email}' was not found");
                }

                var result = _mapper.Map<UserDTO>(searchUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Update User"
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO userDTO)
        {
            try
            {
                if (id != userDTO.UserId)
                {
                    return BadRequest($"The ids are not the same: {id} != {userDTO.UserId}");
                }
                var user = _mapper.Map<User>(userDTO);
                var existUser = await _context.Users.FindAsync(user.UserId);
                if (existUser != null)
                {
                    //_context.Entry(user).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                    //await _context.SaveChangesAsync();
                    return Ok("To do implement update....");
                }
                else
                {
                    return NotFound($"The user with id: ' {id} ' was not found!");
                }

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Generate token with user"
        private JwtSecurityToken getToken(User user)
        {
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            
            var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.UserId.ToString()),
                        //new Claim("UserName", user.UserName),
                        new Claim("Password", user.Password),
                        new Claim("Email", user.Email)
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
        #endregion
    }
    #endregion
}
