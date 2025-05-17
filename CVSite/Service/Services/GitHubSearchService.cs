using Octokit;
using Service.Classes;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNamespace.Services
{
    public class GitHubSearchService : IGitHubSearchService
    {
        private readonly GitHubClient _client;

        public GitHubSearchService()
        {
            _client = new GitHubClient(new ProductHeaderValue("PublicSearchApp"));
        }

        //פונרצית חיפוש רפו ציבורי
        public async Task<List<RepositoryInfo>> SearchPublicRepositories(string query)
        {
            //יוצר בקשת חיפוש מאגרים עם שאילתה נתונה
            var searchRequest = new SearchRepositoriesRequest(query);

            try
            {
                //מבצע חיפוש מאגרים פומביים באמצעות הלקוח של Octokit
                var searchResult = await _client.Search.SearchRepo(searchRequest);
                //ממיר את תוצאות החיפוש לרשימה של RepositoryInfo
                return searchResult.Items.Select(repo => new RepositoryInfo
                {
                    Name = repo.FullName,
                    HtmlUrl = repo.HtmlUrl,
                    StarCount = repo.StargazersCount,
                    LastCommitDate=repo.PushedAt

                }).ToList();
            }
            catch (RateLimitExceededException)
            {
                // לוגיקה לטיפול בחריגה ממגבלת הקצב (למשל, המתנה וניסיון חוזר)
                throw;

            }
            catch (ApiException ex)
            {
                // לוגיקה לטיפול בשגיאות API אחרות
                Console.WriteLine($"GitHub API error: {ex.StatusCode} - {ex.Message}");
                return new List<RepositoryInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return new List<RepositoryInfo>();
            }
        }
    }
}
