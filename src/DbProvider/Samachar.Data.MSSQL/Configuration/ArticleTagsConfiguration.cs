using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samachar.Domain;

namespace Samachar.Data.MSSQL.Configuration
{
    /// <summary>
    /// Entity Configuration for Article Tags
    /// </summary>
    public class ArticleTagsConfiguration : IEntityTypeConfiguration<ArticleTags>
    {
        public void Configure(EntityTypeBuilder<ArticleTags> builder)
        {
            builder.HasKey(x => new { x.ArticleId, x.TagId });
        }
    }
}
