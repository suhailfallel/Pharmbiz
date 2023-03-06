using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmBizz.Models
{
    public class ENT_UserOrders
    {
        public int Id { get; set; }
        public int Outlet_Id { get; set; }
        public string Outlet_Name { get; set; }
        public int User_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Contact { get; set; }
        public int Medicine_Id { get; set; }
        public string Medicine_Name { get; set; }
        public string Company_Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public string OrderStatus { get; set; }

    }
}