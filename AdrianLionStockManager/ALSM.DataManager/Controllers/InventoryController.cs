using ALSM.DataManager.Library.DataAccess;
using ALSM.DataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ALSM.DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryData _inventoryData;

        public InventoryController(IInventoryData inventoryData)
        {
            _inventoryData = inventoryData;
        }
        [HttpGet]
        [Route("/api/Inventory/GetAll")]
        public List<InventoryModel> GetAll()
        {
            return _inventoryData.GetInventory();
        }
    }
}
