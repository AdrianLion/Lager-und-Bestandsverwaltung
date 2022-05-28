using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.Library.Models
{
    public class MaterialOrderModel
    {
        public int OrderId { get; set; }
        public int MaterialId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
