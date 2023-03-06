namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string LandMark { get; set; }

        [StringLength(200)]
        public string District { get; set; }

        [StringLength(200)]
        public string State { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Contact { get; set; }

        [StringLength(200)]
        public string Username { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Status { get; set; }
    }
}
