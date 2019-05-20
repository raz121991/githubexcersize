using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GitHubExcersize.ViewModels;

namespace GitHubExcersize.Controllers
{
    public class BookmarksController : Controller
    {
        // GET: Bookmarks
        public ActionResult Index()
        {
            var bookmarkedRepositories = Session["repositories"] as List<RepositoryDTO>;
            if (bookmarkedRepositories == null)
            {
                List<RepositoryDTO> empRepository = new List<RepositoryDTO>();
                return View(empRepository);
            }

            return View(bookmarkedRepositories);
        }
    }
}