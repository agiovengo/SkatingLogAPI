using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkatingLogAPI.Contexts;
using SkatingLogAPI.Infrastructure.Models;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkatingLogAPI.Services
{
    public class UserService
    {
        private readonly dBContext context;
        private readonly IConfiguration configuration;

        public UserService(dBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task<User> Register(UserRegistrationDto userRegistrationDto)
        {
            User user = new User
            {
                Username = userRegistrationDto.Username,
                FirstName = userRegistrationDto.FirstName,
                LastName = userRegistrationDto.LastName,
                Email = userRegistrationDto.Email
            };

            if (UsernameExists(user.Username))
                throw new Exception("Username " + user.Username + " is already taken");

            if (EmailExists(user.Email))
                throw new Exception("Email " + user.Email + " is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userRegistrationDto.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        public bool UsernameExists(string username)
        {
            if (context.Users.Any(x => x.Username == username))
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (context.Users.Any(x => x.Email == email))
                return true;

            return false;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                    // You can add more claims here if needed
                }),
                Expires = DateTime.Now.AddDays(1), // Token expiration, you can set it to whatever you want
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
