using Samachar.Domain;
using Samachar.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    /// <summary>
    /// Represents a Repository for Category
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get the Categories from Data source
        /// </summary>
        /// <param name="page">Page Number</param>
        /// <param name="rows">Number or Rows</param>
        /// <returns>Collection of Category</returns>
        Task<CategoryViewModel> GetCategoriesAsync(int page, int rows, string search);

        /// <summary>
        /// Get the Categories from Data source
        /// </summary>
        /// <returns>Collection of Category</returns>
        Task<ICollection<Category>> GetCategoriesAsync();

        /// <summary>
        /// Add or Update the Category
        /// </summary>
        /// <param name="category">Category object</param>
        /// <returns>Status of the process</returns>
        Task<int> AddOrUpdate(Category category);

        /// <summary>
        /// Returns a category
        /// </summary>
        /// <param name="id">Category Identifier</param>
        /// <returns>Category Object</returns>
        Task<Category> GetCategoryAsync(int id);

        /// <summary>
        /// Delete the Category
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
