using Banking.API.Models;
using DigitalBankingManagementSystem.Data;
using DigitalBankingManagementSystem.DTOs;
using DigitalBankingManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalBankingManagementSystem.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly BankingDbContext _context;
		private readonly IConfiguration _configuration;

		public AuthController(
			BankingDbContext context,
			IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		[HttpPost("login")]
		public IActionResult Login(LoginRequestDtos request)
		{
			// 1. Find the user
			var user = _context.Users
				.FirstOrDefault(u =>
					u.Username == request.Username &&
					u.IsActive);

			if (user == null)
			{
				return Unauthorized(new
				{
					message = "Invalid username or password"
				});
			}

			// 2. Verify the password
			var passwordHasher = new PasswordHasher<User>();

			var passwordResult = passwordHasher.VerifyHashedPassword(
				user,
				user.PasswordHash,
				request.Password);

			if (passwordResult == PasswordVerificationResult.Failed)
			{
				return Unauthorized(new
				{
					message = "Invalid username or password"
				});
			}

			// 3. Create claims
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Username),
				new Claim(ClaimTypes.Role, user.Role)
			};

			// 4. Create security key
			var key = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(
					_configuration["Jwt:Key"]!));

			// 5. Create signing credentials
			var credentials = new SigningCredentials(
				key,
				SecurityAlgorithms.HmacSha256);

			// 6. Create JWT
			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(
					double.Parse(
						_configuration["Jwt:ExpiryMinutes"]!)),
				signingCredentials: credentials);

			// 7. Convert token to string
			var jwtToken = new JwtSecurityTokenHandler()
				.WriteToken(token);

			// 8. Return token
			return Ok(new
			{
				token = jwtToken,
				username = user.Username,
				role = user.Role
			});
		}
	}
}