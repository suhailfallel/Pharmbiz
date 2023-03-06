namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicalOutlet")]
    public partial class MedicalOutlet
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Outlet_Name { get; set; }

        [StringLength(200)]
        public string Outlet_LicensiName { get; set; }

        [StringLength(200)]
        public string Outlet_LicenseNum { get; set; }

        [StringLength(200)]
        public string Outlet_Address { get; set; }

        [StringLength(200)]
        public string Outlet_Place { get; set; }

        [StringLength(200)]
        public string Outlet_District { get; set; }

        [StringLength(200)]
        public string Outlet_State { get; set; }

        [StringLength(200)]
        public string Outlet_Contact { get; set; }

        [StringLength(200)]
        public string Outlet_Email { get; set; }

        [StringLength(200)]
        public string Username { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}
