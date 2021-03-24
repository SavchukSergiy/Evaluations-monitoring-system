using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using Business.Account;
using Microsoft.AspNetCore.Authorization;
using Utils;
using System.Security.Claims;
using DataModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var identity = await GetIdentity(username, password);
                
                if (identity == null)
                    return BadRequest();

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
                    username = identity.Name
                };

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.AddNewUser(model);

                if (result)
                {

                    var identity = await GetIdentity(model.Login, model.Password);

                    if (identity == null)
                        return BadRequest();

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
                        username = identity.Name
                    };

                    return Ok(response);
                }
                else
                {
                    return StatusCode(500);
                }
            }


            return Ok();
        }


        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login", "Account");
        }


        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            List<UserModel> users = _userManager.GetAllUsers();
            UserModel user = users.FirstOrDefault(u => u.Login == username && u.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // if user is not found
            return null;
        }

    }
}
