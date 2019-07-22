using Order_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using AttributeRouting.Web.Http;
//using AttributeRouting.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace Order_Management.Controllers
{
    public class OrderController : ApiController
    {
        OrdersDataContext datacontext = new OrdersDataContext();
        HttpResponseMessage response;
        [Route("OrderUpsert")]
        [HttpPost]
        public HttpResponseMessage OrderUpsert([FromBody]Order order)
        {
            ResponseType responsetype = new ResponseType();
            try
            {
                responsetype.error = false;
                int? intOrderID = 0;
                if (order.orderID == null || order.orderID == 0)
                {
                    datacontext.spUpsert_Order(order.buyerName, order.buyerPhone, order.buyerEmail, order.shippingAddress, order.orderStatus, order.orderItem, order.quantity, 0, ref intOrderID);
                    responsetype.message = "Order inserted successfully";
                }
                else
                {
                    datacontext.spUpsert_Order(order.buyerName, order.buyerPhone, order.buyerEmail, order.shippingAddress, order.orderStatus, order.orderItem, order.quantity, order.orderID, ref intOrderID);
                    responsetype.message = "Order updated successfully";
                }
                response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responsetype));
            }
            catch (Exception ex)
            {
                responsetype.message = ex.Message;
                responsetype.error = true;
                response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responsetype));
            }
            return response;
        }
        [HttpPost]
        [Route("OrderItemUpsert")]
        public HttpResponseMessage OrderItemUpsert([FromBody]OrderItem orderItem)
        {
            ResponseType responsetype = new ResponseType();
            try
            {
                responsetype.error = false;
                int? intOrderID = 0;
                if (orderItem.orderItemID == null || orderItem.orderItemID == 0)
                {
                    datacontext.spUpsert_OrderItem(orderItem.orderName,orderItem.orderWeight, orderItem.orderHeight, orderItem.orderImage, orderItem.orderStockUnits, orderItem.orderBarCode, orderItem.orderAvailableQuantity, 0, ref intOrderID);
                    responsetype.message = "Order Item inserted successfully";
                }
                else
                {
                    datacontext.spUpsert_OrderItem(orderItem.orderName, orderItem.orderWeight, orderItem.orderHeight, orderItem.orderImage, orderItem.orderStockUnits, orderItem.orderBarCode, orderItem.orderAvailableQuantity, orderItem.orderItemID, ref intOrderID);
                    responsetype.message = "Order updated successfully";
                }
                response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responsetype));
            }
            catch (Exception ex)
            {
                responsetype.message = ex.Message;
                responsetype.error = true;
                response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responsetype));
            }
            return response;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(int? id)
        {
            ResponseType responseType = new ResponseType();
            try
            {
                responseType.error = false;
                datacontext.spDelete_Order(id);
                responseType.message = "Order deleted successfully";
            }
            catch(Exception ex)
            {
                responseType.error = true;
                responseType.message = ex.Message;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responseType));
            return response;
        }
        [HttpGet]
        public List<Order> DisplayAllOrders()
        {
            List<spDisplay_AllOrdersResult> ordersList = datacontext.spDisplay_AllOrders().ToList();
            List<Order> newOrdersList = new List<Order>();
            for(int i=0;i<ordersList.Count; i++)
            {
                Order order = new Order();
                order.orderID = ordersList[i].intOrderID;
                order.buyerName = ordersList[i].vcBuyerName;
                order.buyerEmail = ordersList[i].vcBuyerEmail;
                order.buyerPhone = ordersList[i].vcBuyerPhone;
                order.orderStatus = ordersList[i].intOrderStatus;
                order.shippingAddress = ordersList[i].vcShippingAddress;
                order.orderItem = ordersList[i].intOrderItem;
                order.quantity = ordersList[i].intQuantity;
                newOrdersList.Add(order);
            }
            return newOrdersList;
        }
        [HttpGet]
        public Order ViewOrder(int? id)
        {
            spDisplay_OrderResult sp_order = datacontext.spDisplay_Order(id).FirstOrDefault();
                Order order = new Order();
                order.orderID = sp_order.intOrderID;
                order.buyerName =  sp_order.vcBuyerName;
                order.buyerEmail = sp_order.vcBuyerEmail;
                order.buyerPhone = sp_order.vcBuyerPhone;
                order.orderStatus = sp_order.intOrderStatus;
                order.shippingAddress = sp_order.vcShippingAddress;
                order.orderItem = sp_order.intOrderItem;
                order.quantity = sp_order.intQuantity;
            return order;
        }
    }
}
