using Microsoft.Extensions.Caching.Memory;
using Service.Classes;
using System.Collections.Generic;

namespace WebApi.CachedService
{
    //מחלקה שתשמור את הנתונים ב cache
    public class CachedGitHubService : IGitHubService
    {
        private readonly IGitHubService _gitHubService;
        private readonly MemoryCache _memoryCache;
        private const string UserPortfolioKey = "UserPortfolioKey";
        public CachedGitHubService(IGitHubService gitHubService,MemoryCache memoryCache)
        {
            _gitHubService = gitHubService;
            _memoryCache = memoryCache;
            
        }
       
        public async Task<List<RepositoryInfo>> GetUserRepositories()
        {
            // מנסה לקבל נתונים מהמטמון. אם נמצא, מחזיר אותם.
            if (!_memoryCache.TryGetValue(UserPortfolioKey, out List<RepositoryInfo> repositoryInfo))
            {
                //  אם לא נמצא במטמון, מקבל את הנתונים משירות GitHub האמיתי.
                repositoryInfo = await _gitHubService.GetUserRepositories();

                //מגדיר אפשרויות מטמון
                var cacheOption = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))//הזמן שהנתונים ישארו ב cache
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));//אם לא ביקשו תוך 10 שניות את הנתונים תנקה אותם

                //  שומר את הנתונים שהתקבלו במטמון.
                _memoryCache.Set(UserPortfolioKey, repositoryInfo, cacheOption);

                //  מחזיר את הנתונים
                return repositoryInfo;
            }

            return repositoryInfo;
        }
    }
}
