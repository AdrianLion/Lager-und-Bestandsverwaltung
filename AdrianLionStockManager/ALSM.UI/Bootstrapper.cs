using ALSM.UI.Library.Api;
using ALSM.UI.Library.Models;
using ALSM.UI.Models;
//using ALSM.UI.Models;
using ALSM.UI.ViewModels;
using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ALSM.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }
        private IMapper ConfigureAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MaterialModel, MaterialDisplayModel>();
                cfg.CreateMap<OrderModel, OrderDisplayModel>();
            });
            var result = config.CreateMapper();
            return result;
        }
        protected override void Configure()
        {
            _container.Instance(ConfigureAutomapper());

            _container.Instance(_container)
                .PerRequest<IMaterialEndpoint, MaterialEndpoint>()
                .PerRequest<IInventoryEndpoint, InventoryEndpoint>();




            _container.Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ICurrentUserModel, CurrentUserModel>()
                .Singleton<IApiHelper, ApiHelper>();
            
            GetType().Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
