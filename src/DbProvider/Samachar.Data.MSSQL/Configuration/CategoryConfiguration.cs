using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samachar.Domain;

namespace Samachar.Data.MSSQL.Configuration
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(x => x.ImageUrl).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Sequence).IsRequired().HasColumnType("int").HasDefaultValue(999);
            builder.HasOne(x => x.ParentCategory).WithMany(x => x.SubCategories).HasForeignKey(x => x.Id);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnType("bit");
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false).HasColumnType("bit");
            builder.Property(x => x.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.CreatedBy).IsRequired().HasColumnType("int");
            builder.Property(x => x.UpdatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.UpdatedBy).IsRequired().HasColumnType("int");
        }
    }
}
