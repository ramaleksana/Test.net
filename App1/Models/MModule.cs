using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App1.Models
{
    public class MModule
    {
        [Required]
        public string idmodule { get; set; }
        [Required]
        public string module { get; set; }
    }
}