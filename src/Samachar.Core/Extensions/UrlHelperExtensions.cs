using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Samachar.Core.Extensions
{
    /// <summary>
    /// An extension for Url Helper
    /// </summary>
    public static class UrlHelperExtenstions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(new UrlActionContext { Action = "ConfirmEmail", Controller = "Account", Values = new { userId, code }, Protocol = scheme });
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(new UrlActionContext { Action = "ResetPassword", Controller = "Account", Values = new { userId, code }, Protocol = scheme });
        }
    }
}
