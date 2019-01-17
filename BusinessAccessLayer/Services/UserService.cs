using DataAccessLayer.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BusinessAccessLayer.Services.Interfaces;
using Microsoft.Extensions.Options;
using BusinessAccessLayer.Helpers;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BusinessAccessLayer.Services
{
   public class UserService:IUserService
    {
        HotelContext _hotelContext;
        private readonly AppSettings _appSettings;

        public UserService(HotelContext hotelContext, IOptions<AppSettings> appSettings)
        {
            _hotelContext = hotelContext;
            _appSettings = appSettings.Value;
        }

        public List<User> GetAll()
        {
            return _hotelContext.Users.ToList();
        }

        public string Authenticate(string username, string password)
        {
            var user = _hotelContext.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenTmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tokenTmp);

            //// remove password before returning
            //user.Password = null;

            return token ;
        }

    }
}
