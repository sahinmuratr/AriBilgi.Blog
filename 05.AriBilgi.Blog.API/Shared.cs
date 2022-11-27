using _02.AriBilgi.Blog.Model.UserDtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _05.AriBilgi.Blog.API
{
    public class Shared
    {
        public string SecretKey { get { return "MURATMURATMURATMURATMURATMURATMURATMURATMURATMURATMURAT"; } }

        public string GenerateToken(UserDto userDto)
        {
            var claims = new[]
            {
                new Claim("Id", userDto.Id.ToString()),
                new Claim("Username", userDto.Username),
                new Claim("NameSurname", userDto.Name+" "+userDto.Surname)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                null,
                null,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
