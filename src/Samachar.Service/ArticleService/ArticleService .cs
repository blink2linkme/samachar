using Microsoft.Extensions.Logging;
using Samachar.Domain;
using Samachar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samachar.Service
{
    /// <summary>
    /// Represents a service for article
    /// </summary>
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleTagsRepository _articleTagsRepository;
        private readonly ILogger<ArticleService> _logger;
        public ArticleService(IArticleRepository articleRepository, IArticleTagsRepository articleTagsRepository, ILogger<ArticleService> logger)
        {
            _articleRepository = articleRepository;
            _articleTagsRepository = articleTagsRepository;
            _logger = logger;
        }

        public async Task<int> AddOrUpdateAsync(Article article)
        {
            int articleId = await _articleRepository.AddOrUpdate(article);
            //if (article.ArticleTags != null && article.ArticleTags.Count > 0)
            //{
            //    article.ArticleTags.ToList().ForEach(x => x.ArticleId = articleId);
            //    await _articleTagsRepository.AddOrUpdate(article.ArticleTags);
            //}
            return articleId;
        }

        public async Task<ICollection<Article>> GetAsync(int page, int rows)
        {
            return await _articleRepository.GetArticlesAsync(page, rows);
        }

        public async Task<Article> GetbyIdentifierAsync(int identifier)
        {
            return await _articleRepository.GetArticleAsync(identifier);
        }

        public async Task<ICollection<Article>> GetPopularArticleAsync()
        {
            return await _articleRepository.GetPopularArticleAsync();
        }

        public async Task<ICollection<Article>> GetLatestAsync()
        {
            return await _articleRepository.GetLatestAsync();
        }
    }
}
