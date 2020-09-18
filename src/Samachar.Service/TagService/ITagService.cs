using Samachar.Domain;
using Samachar.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Service
{
    /// <summary>
    /// Represents a service tag
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Returns the Collection of Tag
        /// </summary>
        /// <param name="page">Page Number</param>
        /// <param name="rows">Number or Rows</param>
        /// <returns>tag Collection</returns>
        Task<TagsViewModel> GetTagsAsync(int page, int rows, string search);

        /// <summary>
        /// Returns the Collection of Tag
        /// </summary>
        /// <returns>tag Collection</returns>
        Task<ICollection<Tag>> GetTagsAsync();

        /// <summary>
        /// Add or Update the tag
        /// </summary>
        /// <param name="tag">Tag Object</param>
        /// <returns>Operation Status</returns>
        Task<int> AddOrUpdate(Tag tag);

        /// <summary>
        /// Returns a tag
        /// </summary>
        /// <param name="id">Tag Identifier</param>
        /// <returns>tag Object</returns>
        Task<Tag> GetTagAsync(int id);

        /// <summary>
        /// Delete the tag
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Returns True or False</returns>
        Task<bool> DeleteAsync(int id);
    }
}
