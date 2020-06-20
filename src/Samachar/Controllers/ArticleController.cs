using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Samachar.Domain;
using Samachar.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samachar.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUtilityService _utilityService;

        public ArticleController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                //var articles = await _articleService.GetAsync();
                //return View(articles);
                ViewBag.Categories = new List<Category>();
                ViewBag.ArticleTypes = _utilityService.ArticleTypes().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() });
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Add()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Article article, string returnUrl)
        {
            try
            {
                ViewBag.ReturnUrl = returnUrl;
                ModelState.Remove("ArticleId");
                if (ModelState.IsValid)
                {
                    //if (article.BaseImage != null && article.BaseImage.ContentLength > 0 && article.BaseImage.ContentType.Contains("image"))
                    //{
                    //    string picArticle = System.IO.Path.GetFileNameWithoutExtension(article.BaseImage.FileName);
                    //    string picArticleExt = System.IO.Path.GetExtension(article.BaseImage.FileName);
                    //    string articleBaseImagePath = Server.MapPath("~/Uploads/Images/");
                    //    string galleryRootPath = Server.MapPath("~/Uploads/Gallery/");
                    //    if (!Directory.Exists(articleBaseImagePath))
                    //        Directory.CreateDirectory(articleBaseImagePath);
                    //    if (!Directory.Exists(galleryRootPath))
                    //        Directory.CreateDirectory(galleryRootPath);
                    //    string filePath = Path.Combine(picArticle + DateTime.Now.Ticks + picArticleExt);
                    //    string galleryPath = Path.Combine(picArticle + DateTime.Now.Ticks + picArticleExt);
                    //    article.BaseImagePath = "/Uploads/Images/" + filePath;
                    //    filePath = Path.Combine(articleBaseImagePath, filePath);
                    //    galleryPath = Path.Combine(galleryRootPath, galleryPath);
                    //    article.BaseImage.SaveAs(filePath);
                    //    article.BaseImage.SaveAs(galleryPath);
                    //}
                    int result = await _articleService.AddOrUpdateAsync(article);
                    if (result == 1 && article.Id == 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else if (result == 2 && article.Id != 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else if (result == 3)
                    {
                        ModelState.AddModelError("", "Multiple Values.");
                        return View();
                    }
                }
                ModelState.AddModelError("", "Not Working!!");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> Get(int identifier)
        {
            try
            {
                var article = await _articleService.GetbyIdentifierAsync(identifier);
                return View("Add", article);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
