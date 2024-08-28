using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Application.Interfaces;

namespace UserManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public Task<IdentityResult> RegisterAsync(RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel.InputModel registerModel)
        {
            var user = new IdentityUser { Email = registerModel.Email };
            return await _userManager.CreateAsync(user, registerModel.Password);
        }

        public async Task<string?> LoginAsync(LoginModel.InputModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);

            if (!result.Succeeded)
            {
                return null;
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            return GenerateJwtToken(user!);
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            if (user.UserName == null)
            {
                throw new ArgumentNullException(nameof(user.UserName), "User name cannot be null");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwtKey = _configuration["Jwt:Key"];
            if (jwtKey == null)
            {
                throw new ArgumentNullException(nameof(jwtKey), "JWT key cannot be null");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
