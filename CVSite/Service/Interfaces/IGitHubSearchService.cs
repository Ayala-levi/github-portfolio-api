using Service.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IGitHubSearchService
    {
        //חיפוש רפו ציבורי
        Task<List<RepositoryInfo>> SearchPublicRepositories(string query);

    }
}
