using Samachar.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Service
{
    /// <summary>
    /// Represents a service Category
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Returns the Collection of Category
        /// </summary>
        /// <returns>Category Collection</returns>
        Task<ICollection<Category>> GetCategoriesAsync();

        /// <summary>
        /// Add or Update the Category
        /// </summary>
        /// <param name="category">Categor Object</param>
        /// <returns>Operation Status</returns>
        Task<int> AddOrUpdate(Category category);

        /// <summary>
        /// Returns a category
        /// </summary>
        /// <param name="id">Category Identifier</param>
        /// <returns>Category Object</returns>
        Task<Category> GetCategoryAsync(int id);
    }
}
