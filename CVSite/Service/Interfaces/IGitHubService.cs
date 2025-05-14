using Octokit;
using Service.Classes;

public interface IGitHubService
{
    //מחזירה את רשימת ה-repositories שלך
    Task<List<RepositoryInfo>> GetUserRepositories();

}