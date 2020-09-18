namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Article Tags Many to Many Relationship
    /// </summary>
    public class ArticleTags : BaseEntity
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public Tag Tags { get; set; }
        public int ArticleId { get; set; }
        public Article Articles { get; set; }
    }
}
