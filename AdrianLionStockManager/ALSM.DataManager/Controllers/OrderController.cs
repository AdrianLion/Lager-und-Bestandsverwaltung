using ALSM.DataManager.Library.DataAccess;
using ALSM.DataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace ALSM.DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderData _orderData;
        public OrderController(IOrderData orderData)
        {
            _orderData = orderData;
        }
        
        [Route("/api/Order/Add")]
        [HttpPost]
        public void Add(List<MaterialOrderModel> materialOrderModels)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _orderData.AddOrder(userId, materialOrderModels);
        }
    }
}
