using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using ViewModels;
using Business.Account;
using Microsoft.AspNetCore.Authorization;
using Utils;
using System.Security.Claims;
using DataModels;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            //if (model != null)
            //{
            //    _accountManager.SignIn(model);
            //}

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            
            return Ok();   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterModel model)
        {
            if (model != null)
            {
                _accountManager.SignUp(model);
            }
            return Ok();
        }


        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login", "Account");
        }


        //private async Task<ClaimsIdentity> GetIdentity(User model)
        //{
        //    if (model == null || model.Id == Guid.Empty)
        //        return null;

        //    var user = await _accountManager.GetUserById(model.Id);
            
        //    if (user == null || user.Password != model.Password)
        //        return null;




        //    return null;
        //}

    }
}
