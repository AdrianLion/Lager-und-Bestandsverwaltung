using ALSM.UI.Library.Api;
using ALSM.UI.Library.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.ViewModels
{
    public class CreateMaterialViewModel : Screen
    {
        private readonly IMaterialEndpoint _materialEndpoint;
        public CreateMaterialViewModel(IMaterialEndpoint materialEndpoint)
        {
            _materialEndpoint = materialEndpoint;
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanCreateMaterial);
            }
        }
        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
                NotifyOfPropertyChange(() => CanCreateMaterial);
            }
        }
        public bool CanCreateMaterial
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Description);
            }
        }
        public async Task CreateMaterial()
        {
            await _materialEndpoint.Add(new MaterialModel
            {
                Description = Description,
                Name = Name
            });
            Name = "";
            Description = "";
        }
    }
}
