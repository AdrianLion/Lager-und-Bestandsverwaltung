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
    public class InventoryData : IInventoryData
    {
        private readonly IConfiguration _config;
        private readonly SqlDataAccess _sql;

        public InventoryData(IConfiguration config)
        {
            _config = config;
            _sql = new SqlDataAccess(_config);
        }
        public List<InventoryModel> GetInventory()
        {
            return _sql.Load<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { });
        }
    }
}
