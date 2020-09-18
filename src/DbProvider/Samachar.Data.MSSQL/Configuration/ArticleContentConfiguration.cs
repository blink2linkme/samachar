using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samachar.Domain;

namespace Samachar.Data.MSSQL.Configuration
{
    public class ArticleContentConfiguration : IEntityTypeConfiguration<ArticleContent>
    {
        public void Configure(EntityTypeBuilder<ArticleContent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ShortDescription).IsRequired().HasColumnType("nvarchar(500)");
            builder.Property(x => x.Content).IsRequired().HasColumnType("nvarchar(max)");
            builder.HasOne(x => x.Article).WithOne(x => x.ArticleContent).HasForeignKey<ArticleContent>(x => x.Id);
        }
    }
}
