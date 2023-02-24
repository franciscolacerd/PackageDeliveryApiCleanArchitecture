using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PackageDelivery.Api.Models;
using System.Text;

namespace PackageDelivery.Api.Startup
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PackageDelivery.Api",
                    Description = "This Api will be responsible for package delivery operations."
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
            });
        }

        public static TokenProviderOptions AddJWTAuthentication(
            this IServiceCollection services,
            IConfiguration configuration,
            string environmentName)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("TokenProviderSettings:SecretKey").Value));

            var TokenProviderSettings = new TokenProviderOptions
            {
                Path = configuration.GetSection("TokenProviderSettings:TokenPath").Value,
                Audience = configuration.GetSection("TokenProviderSettings:Audience").Value,
                Issuer = configuration.GetSection("TokenProviderSettings:Issuer").Value,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512)
            };

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = environmentName.Equals("PROD"),
                ValidateAudience = environmentName.Equals("PROD"),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidIssuer = configuration.GetSection("TokenProviderSettings:Issuer").Value,
                ValidAudience = configuration.GetSection("TokenProviderSettings:Audience").Value,
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Audience = configuration.GetSection("TokenProviderSettings:Audience").Value;
                options.ClaimsIssuer = configuration.GetSection("TokenProviderSettings:Issuer").Value;
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

            return TokenProviderSettings;
        }
    }
}