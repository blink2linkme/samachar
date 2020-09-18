using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Samachar.Core.Helper;
using Samachar.Domain;
using Samachar.Domain.ViewModels;
using Samachar.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Samachar.Controllers
{
    public class ArticleController : AdminController
    {
        private readonly IArticleService _articleService;
        private readonly IUtilityService _utilityService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IArticleTagsService _articleTagsService;
        private readonly IFileHelper _fileHelper;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IUtilityService utilityService, IArticleService articleService, ICategoryService categoryService, ITagService tagService, IFileHelper fileHelper, IHostEnvironment hostEnvironment, ILogger<ArticleController> logger, IArticleTagsService articleTagsService)
        {
            _articleService = articleService;
            _utilityService = utilityService;
            _categoryService = categoryService;
            _tagService = tagService;
            _fileHelper = fileHelper;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
            _articleTagsService = articleTagsService;
        }

        public async Task<ActionResult> Index(int page = 1, int rows = 10)
        {
            try
            {
                var articles = await _articleService.GetAsync(page, rows);
                return View(articles);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Add()
        {
            try
            {
                ViewBag.Categories = (await _categoryService.GetCategoriesAsync()).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                ViewBag.ArticleTypes = _utilityService.ArticleTypes().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() });
                ViewBag.Tags = (await _tagService.GetTagsAsync()).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(ArticleViewModel article, string returnUrl)
        {
            try
            {
                ViewBag.ReturnUrl = returnUrl;
                ModelState.Remove("ArticleId");
                ModelState.Remove("Id");
                ModelState.Remove("ArticleContent.Id");
                if (article.Id == 0)
                {
                    ModelState.Remove("IsActive");
                    ModelState.Remove("IsPublished");
                }
                if (ModelState.IsValid)
                {
                    if (article.BaseImage != null && article.BaseImage.Length > 0 && article.BaseImage.ContentType.Contains("image"))
                    {
                        string picArticle = Path.GetFileNameWithoutExtension(article.BaseImage.FileName);
                        string picArticleExt = Path.GetExtension(article.BaseImage.FileName);
                        string articleBaseImagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Uploads", "Images");
                        string galleryRootPath = Path.Combine(_hostEnvironment.ContentRootPath, "Uploads", "Gallery");
                        string filePath = Path.Combine(picArticle + DateTime.Now.Ticks + picArticleExt);
                        string galleryPath = Path.Combine(picArticle + DateTime.Now.Ticks + picArticleExt);
                        article.BaseImageUrl = "/Uploads/Images/" + filePath;
                        filePath = Path.Combine(articleBaseImagePath, filePath);
                        galleryPath = Path.Combine(galleryRootPath, galleryPath);
                        await _fileHelper.CopyFormFileAsync(article.BaseImage, filePath);
                        await _fileHelper.CopyFormFileAsync(article.BaseImage, galleryPath);
                    }
                    if (article.SelectedTags != null && article.SelectedTags.Length > 0)
                    {
                        article.ArticleTags = new List<ArticleTags>();
                        foreach (var tag in article.SelectedTags)
                        {
                            article.ArticleTags.Add(new ArticleTags { TagId = tag });
                        }
                    }
                    int result = await _articleService.AddOrUpdateAsync(article);
                    if (result == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else if (result == 2)
                    {
                        return RedirectToAction("Index");
                    }
                    else if (result == 3)
                    {
                        ModelState.AddModelError("", "Multiple Values.");
                        return View();
                    }
                }
                ViewBag.Categories = (await _categoryService.GetCategoriesAsync()).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                ViewBag.ArticleTypes = _utilityService.ArticleTypes().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() });
                ViewBag.Tags = (await _tagService.GetTagsAsync()).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                ModelState.AddModelError("", "Not Working!!");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                ViewBag.Categories = (await _categoryService.GetCategoriesAsync()).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                ViewBag.ArticleTypes = _utilityService.ArticleTypes().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() });
                ViewBag.Tags = (await _tagService.GetTagsAsync()).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                ArticleViewModel articleViewModel = new ArticleViewModel();
                var article = await _articleService.GetbyIdentifierAsync(id);
                articleViewModel.Title = article.Title;
                articleViewModel.Slug = article.Slug;
                articleViewModel.IsActive = article.IsActive;
                articleViewModel.ArticleContent = article.ArticleContent;
                articleViewModel.ArticleStatus = article.ArticleStatus;
                articleViewModel.ArticleStatusId = article.ArticleStatusId;
                articleViewModel.ArticleTags = await _articleTagsService.GetArticlesTagsAsync(id);
                articleViewModel.ArticleTypes = article.ArticleTypes;
                articleViewModel.BaseImageUrl = article.BaseImageUrl;
                articleViewModel.CategoryId = article.CategoryId;
                articleViewModel.PublishOn = article.PublishOn;
                articleViewModel.SelectedTags = articleViewModel.ArticleTags != null ? articleViewModel.ArticleTags.Select(x => x.TagId).ToArray() : new int[] { };
                return View("Add", articleViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
