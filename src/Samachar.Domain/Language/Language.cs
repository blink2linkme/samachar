namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Language
    /// </summary>
    public class Language : BaseEntity
    {
        public int Id { get; set; }
        public string ISO3166 { get; set; }
    }
}