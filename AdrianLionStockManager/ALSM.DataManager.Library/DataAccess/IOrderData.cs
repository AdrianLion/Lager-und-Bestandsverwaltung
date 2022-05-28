using ALSM.DataManager.Library.Models;
using System.Collections.Generic;

namespace ALSM.DataManager.Library.DataAccess
{
    public interface IOrderData
    {
        void AddOrder(string userId, List<MaterialOrderModel> materialOrderModels);
    }
}