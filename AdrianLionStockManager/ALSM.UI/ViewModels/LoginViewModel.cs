using ALSM.UI.Library.Api;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName = "noidem33@gmail.com";
        private string _password = "$Demo123";
        private readonly IApiAuthenticator _apiAuthenticator;
        private readonly IEventAggregator _events;

        public LoginViewModel(IApiAuthenticator apiAuthenticator, IEventAggregator events)
        {
            _apiAuthenticator = apiAuthenticator;
            _events = events;
        }


        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public async Task LogIn()
        {
            try
            {
                var result = await _apiAuthenticator.Authenticate(UserName, Password);

                await _apiAuthenticator.GetCurrentUserInfo(result.AccessToken);

            }
            catch (Exception ex)
            {

                var msg = ex.Message;
            }
        }


    }
}
