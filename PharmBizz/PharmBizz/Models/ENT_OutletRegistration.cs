using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmBizz.Models
{
    public class ENT_OutletRegistration
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Outlet_Name { get; set; }
        public string Outlet_LicensiName { get; set; }
        public string Outlet_LicenseNum { get; set; }
        public string Outlet_Address { get; set; }
        public string Outlet_Place { get; set; }
        public string Outlet_District { get; set; }
        public string Outlet_State { get; set; }
        public string Outlet_Contact { get; set; }
        public string Outlet_Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}