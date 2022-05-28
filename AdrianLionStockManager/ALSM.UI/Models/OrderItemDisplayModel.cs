using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.Models
{
    public class OrderItemDisplayModel : INotifyPropertyChanged
    {

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                NotifyOfPropertyChanged(nameof(Quantity));
            }
        }
        public decimal Price { get; set; }
        public MaterialDisplayModel Material { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyOfPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
