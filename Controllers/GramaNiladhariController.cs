using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using serveSLhub.Entities;
using serveSLhub.Models.Authentication.LogIn;
using serveSLhub.Models.Authentication.Register;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace serveSLhub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GramaNiladhariController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public GramaNiladhariController(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private string GenerateRandomPassword(int length = 8)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?";
            const string validUppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string validLowercase = "abcdefghijklmnopqrstuvwxyz";
            const string validDigits = "0123456789";
            const string validNonAlphanumeric = "!@#$%^&*?";

            var random = new Random();

            var result = new StringBuilder(length);

            // Ensure at least one character from each category
            result.Append(validUppercase[random.Next(validUppercase.Length)]);
            result.Append(validLowercase[random.Next(validLowercase.Length)]);
            result.Append(validDigits[random.Next(validDigits.Length)]);
            result.Append(validNonAlphanumeric[random.Next(validNonAlphanumeric.Length)]);

            // Fill the rest of the password length
            for (int i = 4; i < length; i++)
            {
                result.Append(validChars[random.Next(validChars.Length)]);
            }

            // Shuffle the characters to ensure randomness
            var passwordArray = result.ToString().ToCharArray();
            for (int i = 0; i < passwordArray.Length - 1; i++)
            {
                var j = random.Next(i, passwordArray.Length);
                (passwordArray[i], passwordArray[j]) = (passwordArray[j], passwordArray[i]);
            }

            return new string(passwordArray);
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup(GramaNiladhariReg model)
        {
            if (ModelState.IsValid)
            {
                var randomPassword = "Password123!"; //For testing otherwise use GenerateRandomPassword()

                // Assign the random password to the model
                model.password = randomPassword;


                var user = new Users
                {
                    UserId = model.GN_ID,
                    firstName = model.firstName,
                    lastName = model.lastName,
                    address = model.address,
                    officeAddress = model.officeAddress,
                    mobileNumber = model.mobileNumber,
                    dateofBirth = model.dateofBirth,
                    joinedDate = model.joinedDate,
                    UserName = model.email,
                    Email = model.email
                };

                var result = await _userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                    // Create the role "GN" if it doesn't exist
                    if (!await _roleManager.RoleExistsAsync("GN"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("GN"));
                    }

                    // Assign role "GN" to the user
                    await _userManager.AddToRoleAsync(user, "GN");

                    // Add claims to the user
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        // Add additional claims as needed
                    };

                    await _userManager.AddClaimsAsync(user, claims);

                    // Add role claim for "GN" role
                    var role = await _roleManager.FindByNameAsync("GN");
                    if (role != null)
                    {
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role.Name));
                    }

                    return CreatedAtAction(nameof(Signup), new { id = user.Id }, new { message = "User created successfully." }); 
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(new { message = "Invalid model data.", errors = ModelState });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(GramaNiladhariLogIn model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.email);
                if (user != null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, model.password);
                    if (result)
                    {
                        // Get claims from the database
                        var userClaims = await _userManager.GetClaimsAsync(user);

                        // Create claims for the authenticated user
                        var claims = new List<Claim> { };
                

                        // Add userClaims fetched from the database
                        claims.AddRange(userClaims);

                        // Get roles assigned to the user
                        //var roles = await _userManager.GetRolesAsync(user);
                        //foreach (var role in roles)
                        //{
                        //    claims.Add(new Claim(ClaimTypes.Role, role));
                        //}

                        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                        var tokenOptions = new JwtSecurityToken(
                            issuer: "https://localhost:44309",
                            audience: "https://localhost:44309",
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(5),
                            signingCredentials: signinCredentials
                        );
                        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                        return Json(new { success = true, token = tokenString });
                    }
                }
            }

            return BadRequest(new { message = "Invalid email or password." });
        }




    }



}
