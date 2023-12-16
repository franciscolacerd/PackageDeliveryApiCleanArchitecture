using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PackageDelivery.Api.Models;
using PackageDelivery.Domain.Exceptions;
using System.Text;

namespace PackageDelivery.Api.Startup
{
    public static class JwtExtensions
    {
        public static TokenProviderOptions AddJWTAuthentication(
            this IServiceCollection services,
            IConfiguration configuration,
            string environmentName)
        {
            if (configuration is null)
                throw new NullConfigurationException("Configuration is null.");

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration?.GetSection("TokenProviderSettings:SecretKey")?.Value));

            var TokenProviderSettings = new TokenProviderOptions
            {
                Path = configuration?.GetSection("TokenProviderSettings:TokenPath")?.Value,
                Audience = configuration?.GetSection("TokenProviderSettings:Audience")?.Value,
                Issuer = configuration?.GetSection("TokenProviderSettings:Issuer")?.Value,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512)
            };

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = environmentName.Equals("PROD"),
                ValidateAudience = environmentName.Equals("PROD"),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidIssuer = configuration?.GetSection("TokenProviderSettings:Issuer")?.Value,
                ValidAudience = configuration?.GetSection("TokenProviderSettings:Audience")?.Value,
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Audience = configuration?.GetSection("TokenProviderSettings:Audience")?.Value;
                options.ClaimsIssuer = configuration?.GetSection("TokenProviderSettings:Issuer")?.Value;
                options.TokenValidationParameters = tokenValidationParameters;
                options.SaveToken = true;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            return TokenProviderSettings;
        }
    }
}