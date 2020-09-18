using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Samachar.Domain;
using Samachar.Domain.ViewModels;
using Samachar.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Service
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly ILogger<TagService> _logger;

        public TagService(ITagRepository tagRepository, ILogger<TagService> logger)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }

        public async Task<TagsViewModel> GetTagsAsync(int page, int rows, string search)
        {
            return await _tagRepository.GetTagsAsync(page, rows, search);
        }

        public async Task<ICollection<Tag>> GetTagsAsync()
        {
            return await _tagRepository.GetTagsAsync();
        }

        public async Task<int> AddOrUpdate(Tag category)
        {
            return await _tagRepository.AddOrUpdate(category);
        }

        public async Task<Tag> GetTagAsync(int id)
        {
            return await _tagRepository.GetTagAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _tagRepository.DeleteAsync(id);
        }
    }
}
