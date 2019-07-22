using Order_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Order_Management.Controllers
{
    public class OrderController : ApiController
    {
        [HttpPut]
        [Route("api/orders/insertorder")]
        public void Put ([FromBody]Order order)
        {
            int orderID = spupsert_order(order.buyerName, order.buyerPhone, order.buyerEmail, order.shippingAddress, order.orderStatus, order.orderItem, order.quantity, 0);
        }
    }
}
