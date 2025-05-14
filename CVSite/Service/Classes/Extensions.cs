using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourNamespace.Services;
using Octokit.Caching;

namespace Service.Classes
{

    public static class Extensions
    {
        public static void AddGitHubIntegration(this IServiceCollection services, Action<GitHubIntegrationOptions> configuration)
        {
            services.Configure(configuration);
            //הזרקות של הממשקים
            services.AddScoped<IGitHubSearchService, GitHubSearchService>();

            services.AddScoped<IGitHubService, GitHubService>();//GitHubService יקבל את CachedGitHubService
        
        }

    }
}
