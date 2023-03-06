namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Company
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Company_Name { get; set; }

        [StringLength(200)]
        public string Company_RegNo { get; set; }

        [StringLength(200)]
        public string Company_Address { get; set; }

        [StringLength(200)]
        public string Company_District { get; set; }

        [StringLength(200)]
        public string Company_State { get; set; }

        [StringLength(200)]
        public string Company_Contact { get; set; }

        [StringLength(200)]
        public string Company_Email { get; set; }

        [StringLength(200)]
        public string Username { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}
