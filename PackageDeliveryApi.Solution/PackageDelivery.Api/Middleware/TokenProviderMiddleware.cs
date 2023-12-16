using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PackageDelivery.Api.Models;
using PackageDelivery.Infrastructure.CrossCuttingConcerns.FaultTolerance;
using PackageDelivery.Persistence.Stores;
using Polly;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace PackageDelivery.Api.Middleware
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next = null!;
        private TokenProviderOptions _options = null!;
        private ILogger _logger = null!;
        private ApplicationUserManager _applicationUserManager;
        protected Polly.Retry.AsyncRetryPolicy _asyncPolicy { get; }

        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options, ILogger<TokenProviderMiddleware> logger)
        {
            this._next = next;

            this._options = options.Value;

            this._logger = logger;

            this._asyncPolicy = Polly.Policy.Handle<Exception>().WaitAndRetryAsync(ExceptionJitter.Get5RetryCount());
        }

        public Task Invoke(HttpContext context, ApplicationUserManager applicationUserManager)
        {
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(context);
            }

            if (!context.Request.Method.Equals("POST") || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = "Bad request.", success = false }, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }

            _applicationUserManager = applicationUserManager;

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];

            var now = DateTime.UtcNow;

            var identity = await GetIdentityAsync(username.ToString().Trim(), password.ToString().Trim(), now);

            if (identity is null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = "Invalid username or password.", success = false }, new JsonSerializerSettings { Formatting = Formatting.Indented }));
                return;
            }

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: identity.Claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds,
                token_type = "Bearer"
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string username, string password, DateTime now)
        {
            try
            {
                return await this._asyncPolicy.ExecuteAsync(
                  async () =>
                  {
                      var user = await _applicationUserManager.Users.Where(x => x.UserName.Equals(username)).FirstOrDefaultAsync();

                      if (user is null)
                      {
                          return await Task.FromResult<ClaimsIdentity>(null);
                      }

                      var result = await _applicationUserManager.CheckPasswordAsync(user, password);

                      if (!result)
                      {
                          return await Task.FromResult<ClaimsIdentity>(null);
                      }

                      return await Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token")));
                  });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}