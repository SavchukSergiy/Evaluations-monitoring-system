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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (model != null)
            {
                _accountManager.SignIn(model);
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

    }
}
