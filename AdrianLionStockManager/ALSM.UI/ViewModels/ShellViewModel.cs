using ALSM.UI.EventModels;
using ALSM.UI.Library.Api;
using ALSM.UI.Library.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALSM.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IEventAggregator _events;
        private readonly ICurrentUserModel _currentUser;
        private readonly IApiHelper _apiHelper;

        public ShellViewModel(IEventAggregator events, ICurrentUserModel currentUser, 
            IApiHelper apiHelper)
        {
            _events = events;
            _currentUser = currentUser;
            _apiHelper = apiHelper;
            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }
        public bool IsLoggedIn
        {
            get
            {
                return !String.IsNullOrWhiteSpace(_currentUser.Token);
            }
        }

        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            NotifyOfPropertyChange(() => IsLoggedIn);
            ActivateItemAsync(IoC.Get<MaterialViewModel>(),cancellationToken);
            return Task.CompletedTask;
        }

        public void Material()
        {
            ActivateItemAsync(IoC.Get<MaterialViewModel>());
        }
        public void Inventory()
        {
            ActivateItemAsync(IoC.Get<InventoryViewModel>());
        }
        public void Order()
        {
            ActivateItemAsync(IoC.Get<OrderViewModel>());
        }
        public void LogOut()
        {
            _currentUser.Reset();
            _apiHelper.LogOffUser();
            ActivateItemAsync(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
            
        }

    }
}
