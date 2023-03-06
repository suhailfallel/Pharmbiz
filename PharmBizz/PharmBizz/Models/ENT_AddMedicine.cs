using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmBizz.Models
{
    public class ENT_AddMedicine
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Batch_No { get; set; }
        public string Medicine_Name { get; set; }
        public string Dosage { get; set; }
        public string Medicine_Image { get; set; }
        public HttpPostedFileBase MedImage { get; set; }
        public int Company_Id { get; set; }
        public string Company_Name { get; set; }
        public DateTime Date_of_Mfg { get; set; }
        public DateTime Date_of_Exp { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Stock_Status { get; set; }
    }
}