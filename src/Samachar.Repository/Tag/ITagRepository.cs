using Samachar.Domain;
using Samachar.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    /// <summary>
    /// Represents a Repository for Tag
    /// </summary>
    public interface ITagRepository
    {
        /// <summary>
        /// Get the Tags from Data source
        /// </summary>
        /// <param name="page">Page Number</param>
        /// <param name="rows">Number or Rows</param>
        /// <returns>Collection of Tag</returns>
        Task<TagsViewModel> GetTagsAsync(int page, int rows, string search);

        /// <summary>
        /// Get the Tags from Data source
        /// </summary>
        /// <returns>Collection of Tag</returns>
        Task<ICollection<Tag>> GetTagsAsync();

        /// <summary>
        /// Add or Update the Tag
        /// </summary>
        /// <param name="tag">Tag object</param>
        /// <returns>Status of the process</returns>
        Task<int> AddOrUpdate(Tag tag);

        /// <summary>
        /// Returns a tag
        /// </summary>
        /// <param name="id">Tag Identifier</param>
        /// <returns>Tag Object</returns>
        Task<Tag> GetTagAsync(int id);

        /// <summary>
        /// Delete the tag
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Returns True or False</returns>
        Task<bool> DeleteAsync(int id);
    }
}
