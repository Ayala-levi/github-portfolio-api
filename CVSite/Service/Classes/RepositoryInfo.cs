using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Classes
{
    public class RepositoryInfo
    {
        //פרטים על הרפו
        public string Name { get; set; }
        public List<string> Languages { get; set; }
        public DateTimeOffset? LastCommitDate { get; set; }
        public int StarCount { get; set; }
        public int PullRequestCount { get; set; }
        public string HtmlUrl { get; set; }
    }
}
