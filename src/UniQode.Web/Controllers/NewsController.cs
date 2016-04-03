using System.Web.Mvc;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;
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
    }
}