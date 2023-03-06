using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmBizz.Models
{
    public class ENT_CompanyRegistration
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }
        public string Company_Name { get; set; }
        public string Company_RegNo { get; set; }
        public string Company_Address { get; set; }
        public string Company_District { get; set; }
        public string Company_State { get; set; }
        public string Company_Contact { get; set; }
        public string Company_Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}