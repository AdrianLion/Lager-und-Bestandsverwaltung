using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.Models
{
    public class MaterialDisplayModel : INotifyPropertyChanged
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private int _quantityInStock;
        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set
            {
                _quantityInStock = value;
                NotifyOfPropertyChanged(nameof(QuantityInStock));
            }
        }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyOfPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
