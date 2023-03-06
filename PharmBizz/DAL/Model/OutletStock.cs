namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OutletStock
    {
        public int Id { get; set; }

        public int? Outlet_Id { get; set; }

        [StringLength(200)]
        public string Outlet_Name { get; set; }

        public int? Medicine_Id { get; set; }

        [StringLength(200)]
        public string Batch_No { get; set; }

        [StringLength(200)]
        public string Medicine_Name { get; set; }

        [StringLength(200)]
        public string Medicine_Dosage { get; set; }

        public DateTime? Mfg_Date { get; set; }

        public DateTime? Exp_Date { get; set; }

        public int? Quantity { get; set; }

        public int? Price { get; set; }

        public int? Company_Id { get; set; }

        [StringLength(200)]
        public string Company_Name { get; set; }

        [StringLength(50)]
        public string Stock_Status { get; set; }
    }
}
