using Microsoft.IdentityModel.Tokens;

namespace PackageDelivery.Api.Models
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/api/token";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(1);

        public SigningCredentials SigningCredentials { get; set; }
    }
}