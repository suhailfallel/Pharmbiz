namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoginCredential
    {
        public int Id { get; set; }

        public int? Reg_Id { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Username { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Role { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}
