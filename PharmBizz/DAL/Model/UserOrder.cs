namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserOrder")]
    public partial class UserOrder
    {
        public int Id { get; set; }

        public int? Outlet_Id { get; set; }

        [StringLength(200)]
        public string Outlet_Name { get; set; }

        public int? User_Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string District { get; set; }

        [StringLength(200)]
        public string State { get; set; }

        [StringLength(200)]
        public string Contact { get; set; }

        public int? Medicine_Id { get; set; }

        [StringLength(200)]
        public string Medicine_Name { get; set; }

        [StringLength(200)]
        public string Medicine_Dosage { get; set; }

        [StringLength(200)]
        public string Company_Name { get; set; }

        public int? BatchNo { get; set; }

        public int? Quantity { get; set; }

        public int? Price { get; set; }

        public int? TotalPrice { get; set; }

        [StringLength(200)]
        public string OrderStatus { get; set; }
    }
}
