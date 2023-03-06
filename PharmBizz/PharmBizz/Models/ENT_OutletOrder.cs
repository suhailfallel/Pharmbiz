using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmBizz.Models
{
    public class ENT_OutletOrder
    {
        public int Id { get; set; }
        public int Outlet_Id { get; set; }
        public string Outlet_Name { get; set; }
        public string Outlet_Address { get; set; }
        public int Medicine_Id { get; set; }
        public string Medicine_Name { get; set; }
        public string Medicine_Dosage { get; set; }
        public string Batch_No { get; set; }
        public DateTime Mfg_Date { get; set; }
        public DateTime Exp_Date { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Company_Id { get; set; }
        public string Company_Name { get; set; }
        public string Order_Status { get; set; }

    }
}