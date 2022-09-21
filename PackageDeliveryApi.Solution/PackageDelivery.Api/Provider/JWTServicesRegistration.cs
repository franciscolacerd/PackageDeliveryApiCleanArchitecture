using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PackageDelivery.Api.Models;
using System.Text;

namespace PackageDelivery.Api.Provider
{
    public static class JWTServicesRegistration
    {
        public static TokenProviderOptions ConfigureJWTServices(IServiceCollection services, IConfiguration configuration, string environmentName)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("TokenProviderOptions:SecretKey").Value));

            var tokenProviderOptions = new TokenProviderOptions
            {
                Path = configuration.GetSection("TokenProviderOptions:TokenPath").Value,
                Audience = configuration.GetSection("TokenProviderOptions:Audience").Value,
                Issuer = configuration.GetSection("TokenProviderOptions:Issuer").Value,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512)
            };

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = environmentName.Equals("PROD"),
                ValidateAudience = environmentName.Equals("PROD"),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidIssuer = configuration.GetSection("TokenProviderOptions:Issuer").Value,
                ValidAudience = configuration.GetSection("TokenProviderOptions:Audience").Value,
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Audience = configuration.GetSection("TokenProviderOptions:Audience").Value;
                options.ClaimsIssuer = configuration.GetSection("TokenProviderOptions:Issuer").Value;
                options.TokenValidationParameters = tokenValidationParameters;
                options.SaveToken = true;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            return tokenProviderOptions;
        }
    }
}