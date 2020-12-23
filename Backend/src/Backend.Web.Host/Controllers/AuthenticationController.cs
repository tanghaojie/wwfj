using Abp.Domain.Repositories;
using Abp.Runtime.Security;
using Backend.Entities;
using Backend.Web.Host.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Abp.AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Backend.Web.Host.Controllers
{
    [Route("api/services/app/[controller]")]
    [ApiController, IgnoreAntiforgeryToken]

    public class AuthenticationController : BackendWebHostControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly TokenAuthConfiguration _configuration;
        public AuthenticationController(IRepository<User> userRepository, TokenAuthConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public AuthenticateOutput Authenticate(AuthenticateInput input)
        {
            if (string.IsNullOrWhiteSpace(input.UsernameOrPhone) || string.IsNullOrWhiteSpace(input.Password))
            {
                return null;
            }
            var result = _userRepository
                .GetAll()
                .Where(x => (x.Username == input.UsernameOrPhone || x.Phone == input.UsernameOrPhone) && x.Password == input.Password)
                .FirstOrDefault();
            if (result != null)
            {
                if (result.Locked)
                {
                    return null;
                }
                var claims = new List<Claim>
                {
                    new Claim(AbpClaimTypes.UserId, result.Id.ToString()),
                    new Claim(ClaimTypes.Name, result.Username),
                    new Claim(ClaimTypes.NameIdentifier, result.Username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //await HttpContext.SignInAsync(
                //    CookieAuthenticationDefaults.AuthenticationScheme,
                //    new ClaimsPrincipal(claimsIdentity),
                //    new AuthenticationProperties());

                var accessToken = CreateAccessToken(CreateJwtClaims(claimsIdentity));

                return new AuthenticateOutput
                {
                    AccessToken = accessToken,
                    ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                    UserId = result.Id,
                    Phone = result.Phone,
                    Realname = result.Realname,
                    Username = result.Username,
                    //Role = (int)result.Role,
                    RegionCode = result.RegionCode,
                    //Department = result.Department,
                    RegionIndex = result.RegionIndex,
                    RegionName = result.RegionName
                };
            }
            return null;
        }

        [HttpGet]
        public async Task<AuthenticateOutput> IsAuthenticated()
        {
            var userid = AbpSession.UserId;
            if (!userid.HasValue)
            {
                return null;
            }
            var result = await _userRepository.GetAsync((int)userid.Value);
            if (result.Locked)
            {
                return null;
            }
            var token = await HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
            var utc = new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo;

            if (result != null)
            {
                return new AuthenticateOutput
                {
                    AccessToken = token,
                    ExpireInSeconds = (int)(utc.ToLocalTime() - DateTime.Now).TotalSeconds,
                    UserId = result.Id,
                    Phone = result.Phone,
                    Realname = result.Realname,
                    Username = result.Username,
                    //Role = (int)result.Role,
                    RegionCode = result.RegionCode,
                    //Department = result.Department,
                    RegionIndex = result.RegionIndex,
                    RegionName = result.RegionName
                };
            }
            return null;
        }




        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? _configuration.Expiration),
                signingCredentials: _configuration.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private static List<Claim> CreateJwtClaims(ClaimsIdentity identity)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }

        private string GetEncryptedAccessToken(string accessToken)
        {
            return SimpleStringCipher.Instance.Encrypt(accessToken, AppConsts.DefaultPassPhrase);
        }


    }
}
