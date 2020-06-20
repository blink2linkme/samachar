using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samachar.Domain;

namespace Samachar.Data.PostgreSQL.Configuration
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Image.Url).HasColumnType("varchar(100)");
            builder.Property(x => x.Sequence).IsRequired().HasColumnType("smallserial").HasDefaultValue(999);
            builder.HasOne(x => x.ParentCategory).WithMany(x => x.SubCategories).HasForeignKey(x => x.ParentCategoryId);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnType("boolean");
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false).HasColumnType("boolean");
            builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("").HasColumnType("time");
            builder.Property(x => x.CreatedBy).IsRequired().HasColumnType("smallint");
            builder.Property(x => x.UpdatedOn).IsRequired().HasDefaultValueSql("").HasColumnType("time");
            builder.Property(x => x.UpdatedBy).IsRequired().HasColumnType("smallint");
        }
    }
}
