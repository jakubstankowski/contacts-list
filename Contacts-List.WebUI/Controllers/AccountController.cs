using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts_List.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IIdentityService identityService, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _identityService = identityService;
            _signInManager = signInManager;
            _logger = logger;
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {

            if (await _identityService.UserExist(registerDto.Email))
            {
                return BadRequest("Username already exists");
            }


            var user = new IdentityUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);



            if (!result.Succeeded)
            {
                return BadRequest();
            }


            await _userManager.AddToRoleAsync(user, "User");

            _logger.LogInformation("Success register new user");

            return new UserDto
            {
                Token = await _identityService.GenerateToken(user),
                Email = user.Email,
                IsAdmin = await _userManager.IsInRoleAsync(user, "Admin"),
                Roles = await _userManager.GetRolesAsync(user)
            };

        }



        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            _logger.LogInformation("Success login user");

            return new UserDto
            {
                Token = await _identityService.GenerateToken(user),
                Email = user.Email,
                IsAdmin = await _userManager.IsInRoleAsync(user, "Admin"),
                Roles = await _userManager.GetRolesAsync(user)
            };

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var userId = _identityService.GetUserId();

            var user = await _userManager.FindByIdAsync(userId);


            if (user == null)
            {
                throw new NotFoundException(userId);
            }

            _logger.LogInformation("Success get current user");

            return new UserDto
            {
                Token = await _identityService.GenerateToken(user),
                Email = user.Email,
                IsAdmin = await _userManager.IsInRoleAsync(user, "Admin"),
                Roles = await _userManager.GetRolesAsync(user)
            };
        }
    }
}
