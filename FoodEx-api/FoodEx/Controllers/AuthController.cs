using FoodEx.Application.IServices;
using FoodEx.Domain;
using FoodEx.Helpers;
using FoodEx.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Xml;

namespace FoodEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("authUser")]
        [Authorize]
        public async Task<ActionResult<User>> GetAuthUserFromClaims()
        {
            User? currentUser = await _userService.GetUserByLogin(User.Identity.Name);
            if (currentUser == null)
            {
                return Unauthorized(new { errorText = "User not authorized" });
            }
            else
            {
                return Ok(currentUser);
            }
        }


        [HttpPost("registration")]
        public async Task<ActionResult<User>> Registration(User user)
        {
            if(user == null)
            {
                return BadRequest(new { errorText = "Object user is null" });
            }
            await _userService.AddUser(user);
            //await LoginWithJwt(new UserLogin(user.Login, user.Password));

            return Ok(user);
        }

        [HttpPost("loginJwt")]
        public async Task<ActionResult> LoginWithJwt(UserLogin user)
        {
            var identity = await GetIdentity(user.Login, user.Password);

            if(identity == null)
            {
                return Unauthorized(new { errorText = "Invalid login or passwod" });
            }

            var now = DateTime.UtcNow;

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
          
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                login = identity.Name
            };

            return Ok(response);
        }

        private async Task<ClaimsIdentity> GetIdentity(string login, string password)
        {
            User user = await _userService.GetUserByLogin(login);
            if (user.Login == login && user.Password == password && user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token",
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }

    }
}
