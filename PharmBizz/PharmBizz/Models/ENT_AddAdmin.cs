using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmBizz.Models
{
    public class ENT_AddAdmin
    {
        [ScaffoldColumn(false)]

        public int Reg_Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}