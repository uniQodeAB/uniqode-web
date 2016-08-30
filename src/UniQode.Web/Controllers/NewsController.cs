using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;
using UniQode.Entities.Enums;
using UniQode.Models.Shared;

namespace UniQode.Web.Controllers
{
    [Authorize]
    [RoutePrefix("news")]
    public class NewsController : Controller
    {
        public NewsController(IMultiTenantService<NewsArticle, long> newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        private readonly IMultiTenantService<NewsArticle, long> _newsArticleService;

        [AllowAnonymous]
        [Route("{searchableTitle}")]
        public ActionResult Public(string searchableTitle, bool preview = false)
        {
            NewsArticle dto = null;

            if (preview)
            {
                dto = _newsArticleService.Secondary.Get(n => n.SearchableTitle.Equals(searchableTitle), true);
            }
            else
            {
                dto = _newsArticleService.Primary.Get(n => n.SearchableTitle.Equals(searchableTitle));
            }

            if (dto == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var model = NewsArticleModel.FromDto(dto);

            return View(model);
        }

        [ChildActionOnly]
        [HttpGet]
        public ActionResult List()
        {
            var dtos = _newsArticleService.Secondary.List(true);
            var models = dtos.Select(NewsArticleModel.FromDto).ToList();
            models.Sort((a, b) => -1 * a.Created.CompareTo(b.Created));

            return PartialView("Partials/Admin/_News", models);
        }
        
        /// <summary>
        /// Used when editing a news article 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/details")]
        public ActionResult AddEdit(string id)
        {
            NewsArticleModel model = null;

            if (id.Equals("0") || id.ToLower().Equals("new"))
            {
                model = new NewsArticleModel
                {
                    State = State.Adding
                };
            }
            else
            {
                var dtos = _newsArticleService.Secondary.List();
                model = dtos.Select(NewsArticleModel.FromDto).First(n => n.Id == long.Parse(id));
                model.State = State.Updating;
            }

            return View(model);
        }

        /// <summary>
        /// Saving changes when editing/creating new
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/details")]
        public ActionResult AddEdit(string id, NewsArticleModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.State == State.None)
                {
                    switch (model.Action)
                    {
                        case AdminAction.Preview:
                        case AdminAction.Publish:
                        case AdminAction.Update:
                        case AdminAction.Save:
                            model.State = State.Updating;
                            break;
                        case AdminAction.Add:
                            model.State = State.Adding;
                            break;
                        case AdminAction.Delete:
                            model.State = State.Deleting;
                            break;
                    }
                }

                if (model.Action != AdminAction.Delete)
                    return View(model);
            }


            switch (model.Action)
            {
                case AdminAction.Delete:
                    try
                    {
                        _newsArticleService.Primary.Delete(model.Id, User.Identity);
                    }
                    catch
                    {
                        // suppress since it could be missing in the primary schema (if not published yet)
                    }
                    _newsArticleService.Secondary.Delete(model.Id, User.Identity);
                    break;
                case AdminAction.Save:
                    model.Modified = DateTime.UtcNow;

                    if(model.State == State.Adding)
                        model.Created = DateTime.UtcNow;

                    _newsArticleService.Secondary.Update(model.ToDto(), User.Identity);
                    break;
                case AdminAction.Preview:
                    model.Modified = DateTime.UtcNow;

                    if (model.State == State.Adding)
                        model.Created = DateTime.UtcNow;

                    _newsArticleService.Secondary.Update(model.ToDto(), User.Identity);

                    return RedirectToAction("Public", "News", new { model.SearchableTitle, Preview = true });
                case AdminAction.Publish:
                    model.Modified = DateTime.UtcNow;

                    if (model.State == State.Adding)
                        model.Created = DateTime.UtcNow;

                    _newsArticleService.Primary.Update(model.ToDto(), User.Identity);
                    _newsArticleService.Secondary.Update(model.ToDto(), User.Identity);

                    return RedirectToAction("Public", "News", new { model.SearchableTitle });
            }

            return RedirectToAction("News", "Admin");
        }
    }
}