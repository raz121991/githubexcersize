using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GitHubExcersize.GitHubAPI;
using GitHubExcersize.ViewModels;
using Octokit;

namespace GitHubExcersize.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SearchRepo(string searchVal,int resultNum)
        {
            if (searchVal == string.Empty)
            {
                List<RepositoryDTO> reposDto = new List<RepositoryDTO>();
                return PartialView("RepositoriesPartialView", reposDto);
            }

          var result = GitApiHandler.GetRepositoriesForSearch(resultNum, searchVal);
          RepositoriesDTO repositoriesView = new RepositoriesDTO();
          MapRepositoriesToRepositoriesView(repositoriesView,result);

            return PartialView("RepositoriesPartialView", repositoriesView.RepositoriesDtos);
        }

        private void MapRepositoriesToRepositoriesView(RepositoriesDTO repositoriesView,List<Repository> repositories)
        {
            foreach (var repository in repositories)
            {
                RepositoryDTO repositoryView = new RepositoryDTO()
                {
                    AvatarURL = repository.Owner.AvatarUrl,
                    Name = repository.Name
                };
               repositoriesView.RepositoriesDtos.Add(repositoryView);
            }
        }

        public JsonResult BookmarkRepository(string name, string avatarUrl)
        {
            var repoList = Session["repositories"] as List<RepositoryDTO>;
            if (repoList == null)
            {
                RepositoryDTO repo = new RepositoryDTO(){Name = name,AvatarURL = avatarUrl};
                List<RepositoryDTO> repository = new List<RepositoryDTO>();
                repository.Add(repo);
                Session["repositories"] = repository;
            }
            else
            {
                repoList.Add(new RepositoryDTO(){AvatarURL = avatarUrl,Name = name});
                Session["repositories"] = repoList;
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            SelectList list = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "10", Value = "10"},
                    new SelectListItem { Text = "50", Value = "50"},
                    new SelectListItem { Text = "100", Value = "100"},
                    new SelectListItem { Text = "200", Value = "200"},
                    new SelectListItem { Text = "300", Value = "300"},
                    new SelectListItem { Text = "400", Value = "400"},

                }, "Value", "Text");

            return View(list);
        }
    }
}