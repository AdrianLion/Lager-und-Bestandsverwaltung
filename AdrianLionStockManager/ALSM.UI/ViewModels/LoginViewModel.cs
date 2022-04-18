using ALSM.UI.Library.Api;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ALSM.UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName = "noidem33@gmail.com";
        private string _password;
        private readonly IApiAuthenticator _apiAuthenticator;
        private readonly IEventAggregator _events;

        public LoginViewModel(IApiAuthenticator apiAuthenticator, IEventAggregator events)
        {
            _apiAuthenticator = apiAuthenticator;
            _events = events;
        }

        public void OnPasswordChanged(PasswordBox source)
        {
            Password = source.Password;
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        public bool CanLogin
        {
            get
            {
                return !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Password);
            }
        }

        public async Task Login()
        {
            try
            {
                var result = await _apiAuthenticator.Authenticate(UserName, Password);

                await _apiAuthenticator.GetCurrentUserInfo(result.AccessToken);

            }
            catch (Exception)
            {

                //TODO display error in UI
            }
        }


    }
}
