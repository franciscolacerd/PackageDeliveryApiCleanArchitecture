using Microsoft.AspNetCore.Http;
using PackageDelivery.Domain.Constants;
using PackageDelivery.Domain.Constants.Structs;
using PackageDelivery.Domain.Exceptions;
using System.Security.Claims;

namespace PackageDelivery.Domain.Common
{
    public class BaseIdentityProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseIdentityProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaims.UserId)?.Value;

                if (_httpContextAccessor.HttpContext?.User == null ||
                    _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == false)
                    throw new UserNotLoggedException(ExceptionMessages.UserNotLoggedException);

                if (string.IsNullOrEmpty(userId))
                    throw new InvalidUserException(ExceptionMessages.InvalidUserException);

                var isValid = int.TryParse(userId, out int id);

                if (!isValid)
                    throw new InvalidUserException(ExceptionMessages.InvalidUserException);

                return id;
            }
        }

        public string Username
        {
            get
            {
                var username = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

                if (_httpContextAccessor.HttpContext?.User == null ||
                    _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == false)
                    throw new UserNotLoggedException(ExceptionMessages.UserNotLoggedException);

                if (string.IsNullOrEmpty(username))
                    throw new InvalidUserException(ExceptionMessages.InvalidUserException);

                return username;
            }
        }
    }
}