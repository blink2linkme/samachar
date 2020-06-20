using System;
using System.Security.Claims;

/// <summary>
/// An extension for Claims Principal
/// </summary>
namespace Samachar.Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            //if (principal == null)
            //    throw new ArgumentException(nameof(principal));
            //return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return "1";
        }
    }
}
