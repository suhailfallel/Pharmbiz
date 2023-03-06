using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmBizz.Models
{
    public class ENT_Login
    {
        //[ScaffoldColumn(false)]

        public string Username { get; set; }
        public string Password { get; set; }
    }
}