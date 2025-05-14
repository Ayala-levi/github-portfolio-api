using Microsoft.Extensions.Options;
using Octokit;
using Service.Classes;

public class GitHubService : IGitHubService
{
    private readonly GitHubClient _client;
    private readonly GitHubIntegrationOptions _options;

    public GitHubService(IOptions<GitHubIntegrationOptions> options)
    {
        _options = options.Value;
        _client = new GitHubClient(new ProductHeaderValue(_options.UserName)); 
        _client.Credentials = new Credentials(_options.Token);
    }
    //מחזירה את רשימת ה-repositories שלך
    public async Task<List<RepositoryInfo>> GetUserRepositories()
    {
        //מקבל את כל המאגרים של המשתמש המאומת הנוכחי
        var repositories = await _client.Repository.GetAllForCurrent();

        //יוצר רשימה חדשה שתכיל מידע מותאם על המאגרים
        var portfolio = new List<RepositoryInfo>();

        //עובר על המאגר
        foreach (var repo in repositories)
        {
            //מקבל את פרטי הרפו
            var languages = await _client.Repository.GetAllLanguages(repo.Owner.Login, repo.Name);
            var lastCommit = await GetLastCommit(repo.Owner.Login, repo.Name);
            var pullRequests = await _client.PullRequest.GetAllForRepository(repo.Owner.Login, repo.Name);

            //יוצר אובייקט חדש עם המידע הרלוונטי מהמאגר RepositoryInfo
            portfolio.Add(new RepositoryInfo
            {
                Name = repo.Name,
                Languages = languages.Select(l => l.Name).ToList(),
                LastCommitDate = lastCommit?.Commit.Author.Date,
                StarCount = repo.StargazersCount,
                PullRequestCount = pullRequests.Count(),
                HtmlUrl = repo.HtmlUrl
            });
        }

        return portfolio;
    }


    private async Task<GitHubCommit> GetLastCommit(string owner, string repoName)
    {
        var commits = await _client.Repository.Commit.GetAll(owner, repoName);
        return commits.FirstOrDefault();
    }

    



}
















