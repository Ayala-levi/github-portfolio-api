using Microsoft.AspNetCore.Mvc;
using Octokit;
using Service.Classes;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubSearchController : ControllerBase
    {
        private readonly IGitHubSearchService _gitHubSearchService;

        public GitHubSearchController(IGitHubSearchService gitHubSearchService)
        {
            _gitHubSearchService = gitHubSearchService;
        }

   
        //חיפוש רפו ציבורי
        [HttpGet("public")]
        public async Task<ActionResult<IEnumerable<RepositoryInfo>>> SearchPublic([FromQuery] string query)
        {
            try
            {
                var results = await _gitHubSearchService.SearchPublicRepositories(query);
                return Ok(results);
            }
            catch (RateLimitExceededException)
            {
                return StatusCode(429, "GitHub API rate limit exceeded. Please try again later.");
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, $"GitHub API error: {ex.Message}");
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
        }
}
