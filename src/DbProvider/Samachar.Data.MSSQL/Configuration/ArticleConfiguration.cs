using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samachar.Domain;

namespace Samachar.Data.MSSQL.Configuration
{
    /// <summary>
    /// Entity Configuration for Article
    /// </summary>
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasColumnType("nvarchar(200)");
            builder.Property(x => x.ArticleTypes).IsRequired().HasColumnType("int");
            builder.Property(x => x.Slug).IsRequired().HasColumnType("nvarchar(300)");
            builder.Property(x => x.PublishOn).HasColumnType("datetime");
            builder.Property(x => x.IsPublished).HasDefaultValue(false).HasColumnType("bit");
            builder.Property(x => x.ArticleStatusId).HasColumnType("int");
            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.Culture).HasColumnType("nvarchar(5)").HasDefaultValue("en-US");
            //builder.HasMany(x => x.Tags).WithMany(x => x.Articles);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnType("bit");
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false).HasColumnType("bit");
            builder.Property(x => x.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.CreatedBy).IsRequired().HasColumnType("int");
            builder.Property(x => x.UpdatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.UpdatedBy).IsRequired().HasColumnType("int");
        }
    }
}
