using ALSM.UI.Library.Api;
using ALSM.UI.Models;
using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.ViewModels
{
    public class MaterialViewModel : Screen
    {
        private readonly IWindowManager _window;
        private readonly IMaterialEndpoint _materialEndpoint;
        private readonly IMapper _mapper;

        public MaterialViewModel(IWindowManager window, IMaterialEndpoint materialEndpoint,
            IMapper mapper)
        {
            _window = window;
            _materialEndpoint = materialEndpoint;
            _mapper = mapper;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadMaterials();
        }

        private async Task LoadMaterials()
        {
            var materialList = await _materialEndpoint.GetAll();
            var materials = _mapper.Map<List<MaterialDisplayModel>>(materialList);
            Materials = new BindableCollection<MaterialDisplayModel>(materials);
        }

        private BindableCollection<MaterialDisplayModel> _materials;

        public BindableCollection<MaterialDisplayModel> Materials
        {
            get { return _materials; }
            set
            {
                _materials = value;
                NotifyOfPropertyChange(() => Materials);
            }
        }
        // TODO add some way of displaying the description since it can be long and should not be displayed fully in the datagrid

    }
}
