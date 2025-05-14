using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Classes
{
    public class GitHubIntegrationOptions
    {
        //מאפיין שמירת שם המשתמש שלך ב-GitHub
        public string UserName { get; set; }
        //מאפייין לשמירת אסימון הגישה האישי
        public string Token { get; set; }
    }
}
