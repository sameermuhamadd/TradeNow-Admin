using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeNow_Admin.Models
{
    public class OrderModel
    {
        public int Order_Id { get; set; }
        public string Buyer_Id { get; set; }
        public string Seller_Id { get; set; }
        public int Ad_Id { get; set; }
        public string Pickup_Address { get; set; }
        public string Shipping_Address { get; set; }
        public string ContactNum_Buyer { get; set; }
        public string ContactNum_Seller { get; set; }
        public string Order_Type { get; set; }
        public Nullable<decimal> Order_Amount { get; set; }
        public System.DateTime Order_Date { get; set; }
        public string BuyerConfirmed { get; set; }
        public string SellerConfirmed { get; set; }
    }
}