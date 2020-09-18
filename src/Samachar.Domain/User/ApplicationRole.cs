using Microsoft.AspNetCore.Identity;
using System;

namespace Samachar.Domain.User
{
    /// <summary>
    /// Represents an entity for User Role
    /// </summary>
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
        public bool Deletable { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
