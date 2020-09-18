using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samachar.Domain;
using Samachar.Service;
using System;
using System.Threading.Tasks;

namespace Samachar.Controllers
{
    public class TagController : AdminController
    {
        private readonly ITagService _tagService;
        private readonly ILogger<TagController> _logger;

        public TagController(ILogger<TagController> logger, ITagService tagService)
        {
            _tagService = tagService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1, int rows = 10, string search = null)
        {
            try
            {
                var tags = await _tagService.GetTagsAsync(page, rows, search);
                tags.Rows = rows;
                tags.Page = page;
                return View(tags);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _tagService.AddOrUpdate(tag) > 0)
                        return RedirectToAction("Index");
                }
                return View(tag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var tag = await _tagService.GetTagAsync(id);
                return View(tag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _tagService.AddOrUpdate(tag) > 0)
                        return RedirectToAction("Index");

                }
                return View(tag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _tagService.DeleteAsync(id))
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
