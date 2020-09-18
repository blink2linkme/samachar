//using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Application User
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
