namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Article Status
    /// </summary>
    public class ArticleStatus : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
    }
}
