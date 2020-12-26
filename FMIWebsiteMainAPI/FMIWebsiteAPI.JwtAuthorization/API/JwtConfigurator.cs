﻿using System.Text;
using FMIWebsiteAPI.Models.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace FMIWebsiteAuthorizationAPI.API
{
    public class JwtConfigurator : IJwtConfigurator
    {
        public JwtConfiguration Configuration { get; }

        public JwtConfigurator(JwtConfiguration jwtConfiguration)
        {
            Configuration = jwtConfiguration;
        }

        public TokenValidationParameters ValidationParameters => new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = Configuration.Issuer,
            ValidateAudience = true,
            ValidAudience = Configuration.Audience,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            IssuerSigningKey = GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };

        public SigningCredentials GetSigningCredentials() =>
            new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);

        private byte[] GetByteKey() => Encoding.UTF8.GetBytes(Configuration.SecretKey);
        private SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(GetByteKey());
    }
}