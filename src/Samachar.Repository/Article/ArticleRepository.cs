using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Samachar.Core.Extensions;
using Samachar.Data.MSSQL;
using Samachar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ILogger<ArticleRepository> _logger;
        private readonly SamacharDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticleRepository(SamacharDbContext dbContext, IHttpContextAccessor httpContextAccessor, ILogger<ArticleRepository> logger)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<int> AddOrUpdate(Article article)
        {
            int result = 0;
            if (article.Id == 0)
            {
                var currentDate = DateTime.UtcNow;
                article.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                article.CreatedOn = currentDate;
                article.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                article.UpdatedOn = currentDate;
                article.ArticleContent.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                article.ArticleContent.CreatedOn = currentDate;
                article.ArticleContent.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                article.ArticleContent.UpdatedOn = currentDate;
                await _dbContext.Articles.AddAsync(article);
                result = 1;
            }
            else
            {
                var articleTags = _dbContext.ArticleTags.Where(x => x.ArticleId == article.Id);
                _dbContext.ArticleTags.RemoveRange(articleTags);
                article.ArticleTags.ToList().ForEach(x =>
                {
                    x.ArticleId = article.Id;
                    x.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                    x.UpdatedBy = x.CreatedBy;
                    x.UpdatedOn = DateTime.UtcNow;
                    x.CreatedOn = x.UpdatedOn;
                });
                _dbContext.ArticleTags.AddRange(article.ArticleTags);
                if (string.IsNullOrEmpty(article.BaseImageUrl))
                {
                    var originalArtice = await FindAsync(article.Id);
                    article.BaseImageUrl = originalArtice.BaseImageUrl;
                }
                article.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                article.UpdatedOn = DateTime.UtcNow;
                article.ArticleContent.UpdatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.User.GetUserId());
                article.ArticleContent.UpdatedOn = DateTime.UtcNow;
                _dbContext.Articles.Update(article);
                _dbContext.Entry(article).State = EntityState.Modified;
                _dbContext.Entry(article).Property(x => x.CreatedBy).IsModified = false;
                _dbContext.Entry(article).Property(x => x.CreatedOn).IsModified = false;
                _dbContext.Entry(article).Property(x => x.Culture).IsModified = false;
                result = 2;
            }
            _logger.LogInformation(article.ToString());
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation(result.ToString());
            return result;
        }

        public async Task<ICollection<Article>> GetArticlesAsync(int page, int rows)
        {
            return await _dbContext.Articles.Where(x => !x.IsDeleted).Take(rows).Skip(page > 1 ? page * rows : 0).ToListAsync();
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await _dbContext.Articles.Include(x => x.ArticleContent).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Article>> GetPopularArticleAsync()
        {
            return await _dbContext.Articles.AsNoTracking().Take(5).ToListAsync();
        }

        public async Task<ICollection<Article>> GetLatestAsync()
        {
            return await _dbContext.Articles.OrderByDescending(x => x.PublishOn).Take(5).AsNoTracking().ToListAsync();
        }

        private async Task<Article> FindAsync(int id)
        {
            return await _dbContext.Articles.Include(x => x.ArticleContent).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
