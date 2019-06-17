using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Octokit;

namespace GitHubExcersize.GitHubAPI
{
    public class GitApiHandler
    {
        public static List<Repository> GetRepositoriesForSearch(int resultsNum, string searchTerm)
        {
            var github = new GitHubClient(new ProductHeaderValue("Isracart"));
            int resultsToPages = resultsNum < 100 ? 1 : resultsNum / 100;
            List<Repository> result = new List<Repository>();
            for (int page = 1; page <= resultsToPages; page++)
            {
                SearchRepositoriesRequest req = new SearchRepositoriesRequest(searchTerm);
                req.Page = page;
                var res = github.Search.SearchRepo(req).Result;
                var list = res.Items.ToList();
                result = result.Concat(list).ToList();
            }

            if (resultsToPages == 1)
                return result.Take(resultsNum).ToList();

            return result;
        }
    }
}
