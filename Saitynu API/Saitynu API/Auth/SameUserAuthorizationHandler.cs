using Microsoft.AspNetCore.Authorization;
using Saitynu_API.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Auth
{
    public class SameUserAuthorizationHandler : AuthorizationHandler<SameUserRequirement, IUserOwnedResource>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement, IUserOwnedResource resource)
        {
            if (context.User.IsInRole(RestUserRoles.Admin) || context.User.FindFirst(CustomClaims.UserId).Value == resource.UserId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        //protected Task HandleRequirementRolesAsync(AuthorizationHandlerContext context, SameUserRequirement requirement, IUserOwnedResource resource)
        //{
        //    if (context.User.IsInRole(RestUserRoles.Admin) || context.User.IsInRole(RestUserRoles.Tester))
        //    {
        //        context.Succeed(requirement);
        //    }

        //    return Task.CompletedTask;
        //}
    }

    public record SameUserRequirement : IAuthorizationRequirement;
}
