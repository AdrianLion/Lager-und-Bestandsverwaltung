﻿using ALSM.UI.Library.Api;
using ALSM.UI.Library.Models;
using ALSM.UI.Models;
using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.ViewModels
{
    public class OrderViewModel : Screen
    {
        private readonly IMaterialEndpoint _materialEndpoint;
        private readonly IMapper _mapper;

        public OrderViewModel(IMaterialEndpoint materialEndpoint, IMapper mapper)
        {
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
            AvailableMaterials = new BindableCollection<MaterialDisplayModel>(materials);
        }


        private BindableCollection<MaterialDisplayModel> _availableMaterials;

        public BindableCollection<MaterialDisplayModel> AvailableMaterials
        {
            get
            {
                return _availableMaterials;
            }
            set
            {
                _availableMaterials = value;
                NotifyOfPropertyChange(() => AvailableMaterials);
            }
        }

        private BindableCollection<OrderDisplayModel> _orderMaterials = new BindableCollection<OrderDisplayModel>();

        public BindableCollection<OrderDisplayModel> OrderMaterials
        {
            get
            {
                return _orderMaterials;
            }
            set
            {
                _orderMaterials = value;
                NotifyOfPropertyChange(() => OrderMaterials);
            }
        }
        private MaterialDisplayModel _selectedMaterial;

        public MaterialDisplayModel SelectedMaterial
        {
            get { return _selectedMaterial; }
            set
            {
                _selectedMaterial = value;
                NotifyOfPropertyChange(() => SelectedMaterial);
            }
        }
        private int _quantity = 1;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                NotifyOfPropertyChange(() => Quantity);
                NotifyOfPropertyChange(() => CanAddOrderItem);
            }
        }

        private string _price = "0";

        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                string priceString = "";
                foreach (char c in value)
                {
                    if (Char.IsDigit(c) || c == ',')
                    {
                        if (priceString.Contains(',') && c == ',')
                        {
                            continue;
                        }
                        if (priceString.Contains(',') && priceString.Length > 2
                            && priceString.Substring(priceString.IndexOf(',')).Length == 3)
                        {
                            continue;
                        }
                        priceString += c;
                    }
                }
                if (String.IsNullOrEmpty(priceString))
                {
                    priceString = "0";
                }
                
                _price = priceString;
                NotifyOfPropertyChange(() => Price);
                NotifyOfPropertyChange(() => CanAddOrderItem);
            }
        }

        public decimal Total
        {
            get
            {
                return OrderMaterials.Sum(x => x.Quantity * x.Price);
            }
        }

        public bool CanAddOrderItem
        {
            get
            {
                return Quantity > 0 && Decimal.Parse(Price) > 0 && SelectedMaterial != null
                    && Quantity <= SelectedMaterial.QuantityInStock;
            }
        }
        public void AddOrderItem()
        {
            OrderDisplayModel? existingOrder = OrderMaterials
                .FirstOrDefault(x => x.Material == SelectedMaterial && x.Price == Decimal.Parse(Price));

            if (existingOrder is not null && existingOrder.Price == Decimal.Parse(Price))
            {
                existingOrder.Quantity += Quantity;
            }
            else
            {
                OrderMaterials.Add(new OrderDisplayModel
                {
                    Material = SelectedMaterial,
                    Quantity = Quantity,
                    Price = Decimal.Parse(Price),
                });

            }
            SelectedMaterial.QuantityInStock -= Quantity;
            Quantity = 1;
            Price = "0";
            NotifyOfPropertyChange(() => OrderMaterials);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCreateOrder);

        }
        public bool CanCreateOrder
        {
            get
            {
                return OrderMaterials.Count > 0;
            }
        }
        public void CreateOrder()
        {

        }

    }
}
