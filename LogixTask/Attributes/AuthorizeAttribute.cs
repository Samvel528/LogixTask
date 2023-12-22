using LogixTask.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace LogixTask.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IList<UserTypeEnum> _roles;

        public AuthorizeAttribute(params UserTypeEnum[] roles)
        {
            _roles = roles ?? new UserTypeEnum[] { };
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                return;
            }

            var claims = context.HttpContext.User.Identities.FirstOrDefault()?.Claims;
            if (claims == null)
            {
                UnauthorizedRequest(context);
                return;
            }

            var typeClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid);
            if (typeClaim == null)
            {
                UnauthorizedRequest(context);
                return;
            }

            var userTypeClaim = claims.FirstOrDefault((x => x.Type == ClaimTypes.NameIdentifier));
            if (userTypeClaim == null)
            {
                UnauthorizedRequest(context);
                return;
            }
            Enum.TryParse(userTypeClaim.Value, out UserTypeEnum role);
            if ((_roles.Any() && !_roles.Contains(role)))
            {
                UnauthorizedRequest(context);
            }
        }

        private static void UnauthorizedRequest(AuthorizationFilterContext context)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            return;
        }
    }
}
