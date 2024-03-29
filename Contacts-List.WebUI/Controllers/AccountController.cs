﻿using Contacts_List.Application.Interfaces;
using Contacts_List.Domain.Models.Authentication;
using Contacts_List.Domain.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts_List.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IIdentityService _identityService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IIdentityService identityService, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _identityService = identityService;
            _signInManager = signInManager;
            _logger = logger;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(Register registerModel)
        {
            if (await _identityService.UserExist(registerModel.Email))
            {
                return BadRequest("Username already exists");
            }

            var user = new IdentityUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            _logger.LogInformation("Success register new user");

            return new User
            {
                Token = _identityService.GenerateToken(user),
                Email = user.Email,
            };

        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(Login loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            _logger.LogInformation("Success login user");

            return new User
            {
                Token = _identityService.GenerateToken(user),
                Email = user.Email,
            };

        }


    }
}
