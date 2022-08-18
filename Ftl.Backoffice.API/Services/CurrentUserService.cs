using Ftl.Backoffice.Shared.Services;
using System.Security.Claims;

namespace Ftl.Backoffice.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public bool IsAuthenticated => throw new NotImplementedException();
    }
}
