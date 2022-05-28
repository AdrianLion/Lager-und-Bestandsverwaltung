using ALSM.UI.Library.Api;
using ALSM.UI.Library.Models;
using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Dictionary<int, string> _materialDescriptions;

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
            var materials = await _materialEndpoint.GetAll();
            _materialDescriptions = materials.ToDictionary(x => x.Id, x => x.Description);
            Materials = new BindableCollection<MaterialModel>(materials);
        }

        private BindableCollection<MaterialModel> _materials;

        public BindableCollection<MaterialModel> Materials
        {
            get { return _materials; }
            set
            {
                _materials = value;
                NotifyOfPropertyChange(() => Materials);
            }
        }

        private MaterialModel _selectedMaterial;

        public MaterialModel SelectedMaterial
        {
            get { return _selectedMaterial; }
            set
            {
                _selectedMaterial = value;
                NotifyOfPropertyChange(() => SelectedMaterial);
            }
        }

        public async void SaveChanges()
        {
            var result = new List<MaterialModel>();
            foreach (var item in Materials)
            {
                if (_materialDescriptions.ContainsKey(item.Id) && _materialDescriptions[item.Id] != item.Description)
                {
                    result.Add(item);
                }
            }

            await _materialEndpoint.Update(result);



        }

        public void AddNewMaterial()
        {
            _window.ShowWindowAsync(IoC.Get<CreateMaterialViewModel>());
        }

    }
}
