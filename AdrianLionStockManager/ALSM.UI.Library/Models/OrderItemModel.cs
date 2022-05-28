using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.Library.Models
{
    public class OrderItemModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public MaterialModel Material { get; set; }

    }
}
