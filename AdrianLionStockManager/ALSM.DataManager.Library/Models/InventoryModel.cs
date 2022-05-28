﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.DataManager.Library.Models
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
