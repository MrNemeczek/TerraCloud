namespace TerraCloud.Server.Common
{
    public static class HttpContextData
    {
        public static Guid GetUserGuid(this IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext is null)
            {
                throw new InvalidOperationException("HTTP context is not available.");
            }

            var user = httpContext.User;
            if (user is null || !user.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            var claim = user.Claims.FirstOrDefault(c => c.Type == "guid");

            if (claim is null || !Guid.TryParse(claim.Value, out var userGuid))
            {
                throw new InvalidOperationException("The claim does not exist or is not a valid GUID.");
            }

            return userGuid;
        }

        public static Guid GetDeviceGuid(this IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext is null)
            {
                throw new InvalidOperationException("HTTP context is not available.");
            }

            var user = httpContext.User;
            if (user is null || !user.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            var claim = user.Claims.FirstOrDefault(c => c.Type == "deviceguid");

            if (claim is null || !Guid.TryParse(claim.Value, out var userGuid))
            {
                throw new InvalidOperationException("The claim does not exist or is not a valid GUID.");
            }

            return userGuid;
        }
    }
}
