using SkatingLogAPI.Contexts;
using SkatingLogAPI.Infrastructure.Models;
using System.Data.Entity;

namespace SkatingLogAPI.Services
{
    public class UserService
    {
        private readonly dBContext context;

        public UserService(dBContext context)
        {
            this.context = context;
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
    }
}
