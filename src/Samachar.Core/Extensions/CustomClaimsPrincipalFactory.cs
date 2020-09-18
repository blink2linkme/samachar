using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Samachar.Domain;
using Samachar.Domain.User;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Samachar.Core.Extensions
{
    /// <summary>
    /// Custom Claim Principal Implementation
    /// </summary>
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public CustomClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor, RoleManager<ApplicationRole> roleManager) : base(userManager, optionsAccessor)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            if (roles.Count() > 0)
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(
                new[] { new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                });
            }
            return principal;
        }
    }
}
