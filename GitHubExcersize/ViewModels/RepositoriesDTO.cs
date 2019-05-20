using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubExcersize.ViewModels
{
    public class RepositoriesDTO
    {
        public List<RepositoryDTO> RepositoriesDtos { get; set; }

        public RepositoriesDTO()
        {
            RepositoriesDtos = new List<RepositoryDTO>();
        }
    }
}