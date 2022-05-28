using ALSM.UI.Library.Api;
using ALSM.UI.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.ViewModels
{
    public class InventoryViewModel : Screen
    {
        private readonly IMaterialEndpoint _materialEndpoint;
        private readonly IInventoryEndpoint _inventoryEndpoint;

        public InventoryViewModel(IMaterialEndpoint materialEndpoint, IInventoryEndpoint inventoryEndpoint)
        {
            _materialEndpoint = materialEndpoint;
            _inventoryEndpoint = inventoryEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadInventory();
        }

        private async Task LoadInventory()
        {
            var materials = await _materialEndpoint.GetAll();
            var inventory = await _inventoryEndpoint.GetAll();
            BindableCollection<InventoryDisplayModel> result = new BindableCollection<InventoryDisplayModel>();
            foreach (var item in inventory)
            {
                result.Add(new InventoryDisplayModel
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    PurchaseDate = item.PurchaseDate,
                    PurchasePrice = item.PurchasePrice,
                    Name = materials.Where(x => x.Id == item.Id).First().Name
                });
            }
            Inventory = result;
        }

        private BindableCollection<InventoryDisplayModel> _inventory;
        public BindableCollection<InventoryDisplayModel> Inventory
        {
            get
            {
                return _inventory;
            }
            set
            {
                _inventory = value;
                NotifyOfPropertyChange(() => Inventory);
            }
        }
    }
}
