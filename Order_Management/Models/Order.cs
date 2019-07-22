using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order_Management.Models
{
    public class Order
    {
        public int? orderID { get; set; }
        public string buyerName { get; set; }
        public string buyerPhone { get; set; }
        public string buyerEmail { get; set; }
        public string shippingAddress { get; set; }
        public int? orderStatus { get; set; }
        public int? orderItem { get; set; }
        public int? quantity { get; set; }
    }

    public class OrderItem
    {
        public int? orderItemID { get; set; }
        public string orderName { get; set; }
        public int? orderWeight { get; set; }
        public int? orderHeight { get; set; }
        public string orderImage { get; set; }
        public int? orderAvailableQuantity { get; set; }
        public string orderBarCode { get; set; }
        public int? orderStockUnits { get; set; }
    }
    public class ResponseType
    {
        public bool error { get; set; }
        public string message { get; set; }
    }
}