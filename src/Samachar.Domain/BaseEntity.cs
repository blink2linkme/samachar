using System;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents a Base Entity
    /// </summary>
    public abstract class BaseEntity
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}