﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PersonalPortal.Helper;
using PersonalPortal.Services;
using PersonalPortal.ViewModels;

namespace PersonalPortal.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [Route("token")]
        [HttpPost]
        public async Task<IActionResult> Token([FromBody] IdentityViewModel model)
        {
            var identity = await GetIdentity(model.Username, model.Password);
            if (identity == null) return Unauthorized();

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer:AuthOptions.ISSUER,
                audience:AuthOptions.AUDIENCE,
                notBefore:now,
                claims:identity.Claims,
                expires:now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials:new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            var response = new
            {
                access_token = encodedJwt,
                user_name = identity.Name
            };
            return Ok(response);
        }

        public async Task<ClaimsIdentity> GetIdentity(string userName, string password)
        {
            ClaimsIdentity identity = null;
            var user = await _identityService.GetUser(userName);

            if (user != null)
            {
                var sha256 = new SHA256Managed();
                var passwordHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
                if (passwordHash == user.Password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                    };
                    identity = new ClaimsIdentity(claims,
                        "Token",
                        ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                }
            }

            return identity;
        }
    }
}