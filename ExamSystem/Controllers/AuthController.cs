using ExamSystem.DTO;
using ExamSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public AuthController(UserManager<AppUser> userManager   , RoleManager<IdentityRole<int>> roleManager)
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
                    return Ok(new {Message = "role is added Successfully" });

                }
                return BadRequest(new {error = "role is found , Add new&different role" });
            }


            return BadRequest(new {error= "U Must Enter the Role It's Required" });

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

            return BadRequest(new {error = "Invalid user data" });



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
                            List<Claim> claims = new List<Claim>();

                            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                            claims.Add(new Claim(ClaimTypes.Name ,user.Name));
                            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                             var roles = await  userManager.GetRolesAsync(user);

                            foreach (var role in roles)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, role));
                                
                            }

                            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Sara&Rawan7/11/2025ITITanta4MonthsThatIsOurChallange"));

                            SigningCredentials signingCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                            JwtSecurityToken jwt = new JwtSecurityToken(
                                issuer:"https://localhost:5026",
                                audience:"https://localhost:4200",
                                claims: claims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: signingCred
                                );



                            string tokenHandler = new JwtSecurityTokenHandler().WriteToken(jwt);
                            return Ok(new { token = tokenHandler });

                           

                        }
                        return BadRequest( new {error ="Not Valid PassWord" });
                    }


                    return BadRequest(new {error = "Not Valid Account , register please" });


                }




            }

            return BadRequest(new {error = "Invalid login data" });



        }




        [HttpPost("/LogOut")]
        public IActionResult LogOut()
        {

            return Ok(new {message = "You are logged out successfully" });

        }
    }
}
