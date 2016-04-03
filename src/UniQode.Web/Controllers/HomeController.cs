using System;
using System.Web.Mvc;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;

namespace UniQode.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IMultiTenantService<NewsArticle, long> newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }
        
        private readonly IMultiTenantService<NewsArticle, long> _newsArticleService;

        public ActionResult Index(bool preview = false, long? p = null)
        {
            if (p != null)
            {
                // this is the legacy route for news arcticles

                var newsArticle = _newsArticleService.Primary.Get(p.Value);

                if (newsArticle == null)
                {
                    return RedirectToAction("NotFound", "Error");
                }

                return RedirectToActionPermanent("Public", "News", new { newsArticle.SearchableTitle });
            }
            return View();
        }
    }
}