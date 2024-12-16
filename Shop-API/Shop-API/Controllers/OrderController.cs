﻿using Microsoft.AspNetCore.Mvc;
using Shop_API.BusinessLogic.Implementation;
using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.Order;

namespace Shop_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL _orderBL;

        public OrderController(IOrderBL orderBL)
        {
            this._orderBL = orderBL;
        }

        [HttpPost("place-order")]
        public async Task PlaceOrder([FromBody] AddOrderModel placeOrderModel)
        {
            await _orderBL.PlaceOrder(placeOrderModel);
        }

        [HttpGet("get-orders")]
        public async Task<IEnumerable<GetOrdersModel>> GetOrders()
        {
            var orders = await _orderBL.GetOrders();
            return orders;
        }


        [HttpPost("update-status")]
        public async Task UpdateStatus([FromBody] int orderId)
        {
            await _orderBL.UpdateStatus(orderId);
        }
    }
}
