using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AstudentApplication.Models.DataModel;
using AstudentApplication.Repository.Interface.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AstudentApplication.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private readonly IConfiguration _config;
        public AdminController(IRepositoryWrapper repoWrapper, IConfiguration config)
        {
            _config = config;
            _repoWrapper = repoWrapper;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login(LoginInfo obLoginInfo)
        {
            IActionResult response = Unauthorized();
            LoginInfo user = AuthenticateUser(obLoginInfo);
            if (user != null)
            {
                var tokenString = GenerateJWTToken(user);
                response = Ok(new
                {
                    token = tokenString,
                });
            }
            return response;
        }
        private LoginInfo AuthenticateUser(LoginInfo loginCredentials)
        {

            var result = _repoWrapper.loginInfo.FindByCondition(x => x.UserName == loginCredentials.UserName && x.Password == loginCredentials.Password).FirstOrDefault();
            return new LoginInfo()
            {
                UserName = result.UserName,
                UserRole = result.UserRole,
                FullName = result.FullName
            };
        }

        private string GenerateJWTToken(LoginInfo userInfo)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:SecretKey")));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("fullName", userInfo.FullName.ToString()),
                new Claim("role",userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
                var token = new JwtSecurityToken(
                issuer: _config.GetValue<string>("Jwt:Issuer"),
                audience: _config.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
