using Samachar.Domain;
using Samachar.Domain.ViewModels;
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
        /// <param name="page">Page Number</param>
        /// <param name="rows">Number or Rows</param>
        /// <returns>Category Collection</returns>
        Task<CategoryViewModel> GetCategoriesAsync(int page, int rows, string search);

        /// <summary>
        /// Returns the Collection of Category
        /// </summary>
        /// <returns>Category Collection</returns>
        Task<IEnumerable<Category>> GetCategoriesAsync();

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

        /// <summary>
        /// Delete the category
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Returns True or False</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Sequence of Categories
        /// </summary>
        /// <returns>Collection of category</returns>
        Task<ICollection<Category>> GetSequenceCategoriesAsync();
    }
}
