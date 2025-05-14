using Microsoft.AspNetCore.Mvc;
using Service.Classes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        //פונקציה לקבלת הרפו האישיים
        [HttpGet("GetPortfolio")]
        public async Task<ActionResult<IEnumerable<RepositoryInfo>>> GetPortfolio()
        {
            var repositories = await _gitHubService.GetUserRepositories();
            return Ok(repositories);
        }

    }
}
