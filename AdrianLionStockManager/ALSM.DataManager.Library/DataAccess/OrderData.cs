using ALSM.DataManager.Library.Internal.DataAccess;
using ALSM.DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.DataManager.Library.DataAccess
{
    public class OrderData : IOrderData
    {
        private readonly IConfiguration _config;
        private readonly SqlDataAccess _sql;
        public OrderData(IConfiguration config)
        {
            _config = config;
            _sql = new SqlDataAccess(_config);
        }
        public void AddOrder(string userId, List<MaterialOrderModel> materialOrderModels)
        {
            dynamic u = new
            {
                UserId = userId
            };
            _sql.Save("dbo.spOrder_Insert", u);
            int orderId = _sql.Load<int, dynamic>("dbo.spOrder_GetLast", new { }).First();
            materialOrderModels.ForEach(x => x.OrderId = orderId);

            foreach (var item in materialOrderModels)
            {
                dynamic m = new
                {
                    OrderId = item.OrderId,
                    MaterialId = item.MaterialId,
                    Quantity = item.Quantity,
                    PurchasePrice = item.PurchasePrice
                };
                _sql.Save("dbo.spMaterialOrder_Insert", m);
            }

        }
    }
}
