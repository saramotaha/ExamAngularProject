using ExamSystem.DTO;
using ExamSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public Account(UserManager<AppUser> userManager   , RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }



        [HttpPost("/AddRole")]
        public async Task<IActionResult> AddRoles(string role) {

            if(role != null)
            {
                bool roleExist = await roleManager.RoleExistsAsync(role);

                if (roleExist == false)
                {

                    await roleManager.CreateAsync(new IdentityRole<int>(role));
                    return BadRequest("role is added Successfully");

                }
                return BadRequest("role is found");
            }


            return BadRequest("U Must Enter the Role It's Required");

        }




        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {

            if(userDto!=null)
            {

                if(ModelState.IsValid)
                {
                    AppUser user=new AppUser()
                    {
                        Name = userDto.Name,
                        Email = userDto.Email,
                        UserName = userDto.Name,
                        PasswordHash = userDto.PassWord,
  
                    };

                   
                    var identityResult =await userManager.CreateAsync(user, userDto.PassWord);

                    await userManager.AddToRoleAsync(user, userDto.role);


                    if(identityResult.Succeeded)
                    {
                        return Ok(new { message = "User registered successfully" });
                    }
                    return BadRequest(identityResult.Errors);
                }

            }

            return BadRequest("Invalid user data");



        }




        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {

            if(userLoginDto != null)
            {

                if (ModelState.IsValid) {

                   var user= await userManager.FindByEmailAsync(userLoginDto.Email);

                    if(user !=null)
                    {
                        bool passWord= await userManager.CheckPasswordAsync(user, userLoginDto.PassWord);

                        if (passWord)
                        {
                            //JwtSecurityToken jwt=new JwtSecurityToken()
                            return Ok("Login successful");
                        }
                    }


                    return BadRequest("Login failed ");


                }




            }

            return BadRequest("Invalid login data");



        }

    }
}
