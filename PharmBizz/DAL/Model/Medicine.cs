namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicine")]
    public partial class Medicine
    {
        public int Id { get; set; }

        public int? Batch_No { get; set; }

        [StringLength(200)]
        public string Medicine_Name { get; set; }

        [StringLength(200)]
        public string Dosage { get; set; }

        [StringLength(200)]
        public string Medicine_Image { get; set; }

        public int? Company_Id { get; set; }

        [StringLength(200)]
        public string Company_Name { get; set; }

        public DateTime? Date_of_Mfg { get; set; }

        public DateTime? Date_of_Exp { get; set; }

        public int? Price { get; set; }

        public int? Quantity { get; set; }

        [StringLength(200)]
        public string Stock_Status { get; set; }
    }
}
