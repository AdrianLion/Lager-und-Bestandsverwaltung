using ALSM.UI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.Library.Api
{
    public interface IApiAuthenticator
    {
        HttpClient ApiClient { get; }
        void LogOffUser();
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetCurrentUserInfo(string token);
    }
}
