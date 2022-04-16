using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly IEventAggregator _events;

        public ShellViewModel(IEventAggregator events)
        {
            _events = events;
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }
    }
}
