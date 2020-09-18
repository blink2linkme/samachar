using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samachar.Domain.User;
using System;

namespace Samachar.Data.MSSQL.Configuration
{
    /// <summary>
    /// Configuration for Application Role
    /// </summary>
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
                 new ApplicationRole("SuperAdmin") { NormalizedName = "SuperAdmin", Deletable = false, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                 new ApplicationRole("Admin") { NormalizedName = "Admin", Deletable = false, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
               new ApplicationRole("User") { NormalizedName = "User", Deletable = false, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow });
        }
    }
}
