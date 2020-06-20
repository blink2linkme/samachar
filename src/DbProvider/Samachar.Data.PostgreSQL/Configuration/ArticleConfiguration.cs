using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samachar.Domain;

namespace Samachar.Data.PostgreSQL.Configuration
{
    /// <summary>
    /// Entity Configuration for Article
    /// </summary>
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.ArticleTypes).IsRequired().HasColumnType("smallint");
            builder.Property(x => x.Slug).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.PublishOn).HasColumnType("time");
            builder.Property(x => x.IsPublished).HasDefaultValue(false).HasColumnType("boolean");
            builder.Property(x => x.ArticleStatusId).HasColumnType("smallint");
            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);
        }
    }
}
